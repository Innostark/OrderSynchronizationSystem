using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.GUI;
using IST.OrderSynchronizationSystem.MBAPI;
using IST.OrderSynchronizationSystem.Models;
using IST.OrderSynchronizationSystem.MoldingBox;
using IST.OrderSynchronizationSystem.Properties;
using System.Configuration;
using Newtonsoft.Json;

namespace IST.OrderSynchronizationSystem
{
    public partial class MainWindow : Form
    {
        private bool _autoSyncActive;
        private int _autoSyncFrequency;
        private int _autoSyncMbFrequency;
        private readonly AutoSynchOrder _autoSyncOrder;
        delegate void SetTextCallback(string text);

        private delegate void RefreshNewOrderGrid();

        


        private delegate void SetGridColumnsVisibility(DataGridView gridView, OssOrdersGridTypes gridType);
        public OssDatabase _orderSyncronizationDatabase;
        private OSSConnection _sourceConnectionVariables;
        private OSSConnection _stagingConnectionVariables;
        private string _sourceServer = String.Empty;
        private string _sourceDatabsae = String.Empty;
        private string _sourceUsername = String.Empty;
        private string _sourcePassword = String.Empty;
        private string _stagingServer = String.Empty;
        private string _stagingDatabase = String.Empty;
        private string _stagingUsername = String.Empty;
        private string _stagingPassword = String.Empty;
        private string _defaultEmail = String.Empty;
        private string _defaultPhone = String.Empty;
        private DataTable _ossOrders = null;
        private ShippingMethod[] shipmentMethods;
        private bool hideWhenMinimized;
        public string apiKey;
        private const string RePostString = "Re-Post";
        private const string CancelString = "Cancel";
        private const string ReloadString = "Reload";
        private const string SyncWithMb = "Sync With MB";
        public MainWindow(bool programState)
        {
            InitializeComponent();
            LoadConfigurationFromAppConfig();
            InitializeDatabaseParameters();
            _autoSyncActive = programState;
            _autoSyncFrequency = 0;
            _autoSyncMbFrequency = 0;
            _autoSyncOrder = new AutoSynchOrder();
            reloadGridsDelegate = new ReloadGridsDelegate(ReloadAllGrid);
        }

        private void InitializeDatabaseParameters()
        {
            _sourceConnectionVariables = new OSSConnection
            {
                ServerName = _sourceServer,
                DatabaseName = _sourceDatabsae ,
                UserName = _sourceUsername,
                Password = _sourcePassword
            };
            _stagingConnectionVariables = new OSSConnection
            {
                ServerName = _stagingServer,
                DatabaseName = _stagingDatabase,
                UserName = _stagingUsername,
                Password = _stagingPassword
            };
            _orderSyncronizationDatabase = new OssDatabase(_sourceConnectionVariables, _stagingConnectionVariables);
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_autoSyncActive)
            {
                _autoSyncOrder.cancellationTokenSource.Cancel();
            }
            Close();
        }
        private void SynchronizeButton_Click(object sender, EventArgs e)
        {
            if (!_autoSyncActive)
            {
                StartAutoSychronization();
            }
            else
            {
                PauseAutoSychronization();
            }
        }

        private void StartPauseToggleButton(bool startSychronization)
        {
            if (startSychronization)
            {
                SynchronizeButton.Image = Resources.PauseImage;
                SynchronizeButton.Text = Resources.MainWindow_StartPauseToggle_Pause;
                _autoSyncActive = true;
            }
            else
            {
                SynchronizeButton.Image = Resources.PlayImage;
                _autoSyncActive = false;
                SynchronizeButton.Text = Resources.MainWindow_StartPauseToggle_Start;
            }
        }

        private void StartAutoSychronization()
        {
            
            if (!ValidateInput())
                return;
            ApplicationStatusUpdate("Please wait while we start Auto Synchronization.");
            InitializeDatabaseParameters();

            if (!VarifySourceDatabase())
            {
                ApplicationStatusUpdate(Resources.MainWindow_UnableToConnection_SourceDatabase);
                return;
            }
            if (!VarifyStagingDatabase())
            {
                ApplicationStatusUpdate(Resources.MainWindow_UnableToConnection_StagingDatabase);
                return;
            }
            
            _autoSyncFrequency = int.Parse(SyncNewOrderTextbox.Text);
            _autoSyncMbFrequency = int.Parse(SyncMoldingBoxIntervalTextbox.Text);
            apiKey = MoldinboxKeyTextBox.Text;
            ClearAllGrids();
            EnableDisableFieldsForAutoSync(false);            
            StartThread();
            
            StartPauseToggleButton(true);            
            ApplicationStatusUpdate("Auto synchronization started.");
        }

        

        private void PauseAutoSychronization()
        {
            StopThread();
            EnableDisableFieldsForAutoSync(true);
            
            StartPauseToggleButton(false);
            ApplicationStatusUpdate("Auto synchronization stopped.");
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(SourceServerTextBox.Text))
            {
                FormErrorProvider.SetError(SourceServerTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourceDatabaseTextBox.Text))
            {
                FormErrorProvider.SetError(SourceDatabaseTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourceUsernameTextBox.Text))
            {
                FormErrorProvider.SetError(SourceUsernameTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourcePasswordTextBox.Text))
            {
                FormErrorProvider.SetError(SourcePasswordTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourcePasswordTextBox.Text))
            {
                FormErrorProvider.SetError(SourcePasswordTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }

            if (string.IsNullOrEmpty(StagingServerTextBox.Text))
            {
                FormErrorProvider.SetError(StagingServerTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(StagingDatabaseTextBox.Text))
            {
                FormErrorProvider.SetError(StagingDatabaseTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(StagingUsernameTextBox.Text))
            {
                FormErrorProvider.SetError(StagingUsernameTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourcePasswordTextBox.Text))
            {
                FormErrorProvider.SetError(SourcePasswordTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SyncNewOrderTextbox.Text))
            {
                FormErrorProvider.SetError(SyncNewOrderTextbox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            int minutes;
            if (!string.IsNullOrEmpty(SyncNewOrderTextbox.Text) && int.TryParse(SyncNewOrderTextbox.Text, out minutes))
            {
                if (minutes > 999 || minutes < 2)
                {
                    FormErrorProvider.SetError(SyncNewOrderTextbox, Resources.MainWindow_MinutesRange);
                    isValid = false;
                }                
            }
            if (string.IsNullOrEmpty(SyncMoldingBoxIntervalTextbox.Text))
            {
                FormErrorProvider.SetError(SyncMoldingBoxIntervalTextbox, Resources.MainWindow_Required_Field);
                isValid = false;
            }            
            if (!string.IsNullOrEmpty(SyncMoldingBoxIntervalTextbox.Text) && int.TryParse(SyncMoldingBoxIntervalTextbox.Text, out minutes))
            {
                if (minutes > 999 || minutes < 2)
                {
                    FormErrorProvider.SetError(SyncMoldingBoxIntervalTextbox, Resources.MainWindow_MinutesRange);
                    isValid = false;
                }
            }
            if (isValid)
            {
                FormErrorProvider.Clear();
            }

            return isValid;
        }

        private void StartThread()
        {
            Task.Factory.StartNew(() => _autoSyncOrder.Process(this, _autoSyncFrequency), TaskCreationOptions.AttachedToParent);
            Task.Factory.StartNew(() => _autoSyncOrder.ProcessMb(this, _autoSyncMbFrequency), TaskCreationOptions.AttachedToParent);
        }
        private void StopThread(bool formClosing = false)
        {
            _autoSyncOrder.cancellationTokenSource.Cancel();
            if (!formClosing)
            {
                ClearAllGrids();
            }
        }
        public void ApplicationStatusUpdate(string text)
        {
            SetApplicationStatusText(text);
        }
        private void SetApplicationStatusText(string text)
        {
            if (ApplicationStatusStrip.InvokeRequired)
            {
                SetTextCallback d = SetApplicationStatusText;
                Invoke(d, new object[] {text});
            }
            else
            {
                ShowNotificationText(text);
                toolStripStatus.Text = text;
            }
        }

        private bool VarifySourceDatabase()
        {
            ApplicationStatusUpdate(Resources.MainWindow_VarifySourceDatabase_Checking_source_database);
            return _orderSyncronizationDatabase.VarifySourceDatabase();
        }
        private bool VarifyStagingDatabase()
        {
            ApplicationStatusUpdate(Resources.MainWindow_VarifySourceDatabase_Checking_Staging_database);
            return _orderSyncronizationDatabase.VarifySourceDatabase();
        }
        private void SetDatabaseSettings(string dbSettings)
        {
            bool readyToSave = true;
            string errorText = String.Empty;

            string server = (dbSettings == "Source" ? SourceServerTextBox.Text : StagingServerTextBox.Text);
            string database = (dbSettings == "Source" ? SourceDatabaseTextBox.Text : StagingDatabaseTextBox.Text);
            string username = (dbSettings == "Source" ? SourceUsernameTextBox.Text : StagingUsernameTextBox.Text);
            string password = (dbSettings == "Source" ? SourcePasswordTextBox.Text : StagingPasswordTextBox.Text);

            if (string.IsNullOrEmpty(EmailTextbox.Text))
            {
                readyToSave = false;
                errorText = "Please provide a valid default email.";
            }
            if (string.IsNullOrEmpty(PhoneTextbox.Text))
            {
                readyToSave = false;
                errorText = "Please provide a valid default phone.";
            }
            if (String.IsNullOrWhiteSpace(server))
            {
                readyToSave = false;
                errorText = "Please provide a valid " + dbSettings + " Server.";
            }
            if (String.IsNullOrWhiteSpace(database))
            {
                readyToSave = false;
                errorText += (String.IsNullOrWhiteSpace(errorText) ? String.Empty : Environment.NewLine) +
                             "Please provide a valid " + dbSettings + " Database.";
            }
            if (String.IsNullOrWhiteSpace(username))
            {
                readyToSave = false;
                errorText += (String.IsNullOrWhiteSpace(errorText) ? String.Empty : Environment.NewLine) +
                             "Please provide a valid " + dbSettings + " User name.";
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                readyToSave = false;
                errorText += (String.IsNullOrWhiteSpace(errorText) ? String.Empty : Environment.NewLine) +
                             "Please provide a valid " + dbSettings + " Password.";
            }

            if (readyToSave)
            {
                Configuration applicationConfigurations = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Add an Application Setting.
                AppSettingsSection applicationSettings = (AppSettingsSection)applicationConfigurations.GetSection("appSettings");
                if (applicationSettings != null)
                {
                    applicationSettings.Settings[dbSettings + "ServerName"].Value = server;
                    applicationSettings.Settings[dbSettings + "DatabaseName"].Value = database;
                    applicationSettings.Settings[dbSettings + "UserName"].Value = username;
                    applicationSettings.Settings[dbSettings + "Password"].Value = password;
                    applicationSettings.Settings["DefaultEmail"].Value = EmailTextbox.Text;
                    applicationSettings.Settings["DefaultPhone"].Value = PhoneTextbox.Text;
                }

                // Save the changes in App.config file.
                applicationConfigurations.Save(ConfigurationSaveMode.Modified);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("connectionStrings");

                if (dbSettings.Equals("Source"))
                {
                    _sourceServer = server;
                    _sourceDatabsae = database;
                    _sourceUsername = username;
                    _sourcePassword = password;
                }
                else if (dbSettings.Equals("Staging"))
                {
                    _stagingServer = server;
                    _stagingServer = database;
                    _stagingUsername = username;
                    _stagingPassword = password;
                }

            }
            else
            {
                if (!_autoSyncActive)
                {
                    MessageBox.Show(this, errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SynchronizeOrdersFromTHubButton_Click(object sender, EventArgs e)
        {
            List<OssShipment> ossShipments = new List<OssShipment>();
            try
            {
                //Check source database
                if (!VarifySourceDatabase())
                {
                    ApplicationStatusUpdate(Resources.MainWindow_UnableToConnection_SourceDatabase);
                    return;
                }
                //Check Staging database
                if (!VarifyStagingDatabase())
                {
                    ApplicationStatusUpdate(Resources.MainWindow_UnableToConnection_StagingDatabase);
                    return;
                }

                ossShipments = _orderSyncronizationDatabase.LoadShipmentsFromThub();
            }
            catch (Exception ex)
            {
                if (!_autoSyncActive)
                {
                    MessageBox.Show(
                        String.Format("{0}{1}{2}", "Error while loading orders form T-Hub.", Environment.NewLine,
                            ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _orderSyncronizationDatabase.InsertShipmentsToStaging(ossShipments);
            OssShipment firstOrDefault = ossShipments.OrderByDescending(ossShipment => ossShipment.ThubOrderId).FirstOrDefault();
            if (firstOrDefault != null)
            {
                _orderSyncronizationDatabase.GetOrSetMaximumOrderIdFetched(firstOrDefault.ThubOrderId);
            }            
            ApplicationStatusUpdate("Manual synchronization complete.");
        }

        private void SaveSourceButon_Click(object sender, EventArgs e)
        {
            SetDatabaseSettings("Source");
        }

        private void SaveStagingButton_Click(object sender, EventArgs e)
        {
            SetDatabaseSettings("Staging");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            MainFormTabControl.SelectTab(NewOrderTabPage);
        }

        private void LoadOrderFromStagingButton_Click(object sender, EventArgs e)
        {
            RefreshNewOrdersGrid();
        }

        private void RefreshNewOrdersGrid()
        {
            if (OssOrdersDataGridView.InvokeRequired)
            {
                RefreshNewOrderGrid d = RefreshNewOrdersGrid;
                Invoke(d, new object[] {});
            }
            else
            {
                _ossOrders = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.New);
                if (_ossOrders.Rows.Count > 0)
                {
                    OssOrdersDataGridView.DataSource = _ossOrders;
                    SetOssOrderDataGridHeaderTextAndColumnVisibility(OssOrdersDataGridView, OssOrdersGridTypes.New);
                    if (!_autoSyncActive)
                    {
                        if (OssOrdersDataGridView.ColumnCount == 20)
                        {
                            AddSendButtonToGridView(OssOrdersDataGridView);
                        }
                        EnableDisableSendToMoldingBoxButton(OssOrdersDataGridView);
                    }
                }
                else
                {
                    OssOrdersDataGridView.DataBindings.Clear();
                    if (!_autoSyncActive)
                    {
                        MessageBox.Show("No New Order available is T-Hub.", "Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                NoOfOrdersLabel.Text = "No. of Order: " + _ossOrders.Rows.Count;
            }
        }
        
        private void DisableSentToMoldingBoxButton(DataGridViewDisableButtonCell sendToMbButtonCell)
        {
            sendToMbButtonCell.Enabled = false;
            OssOrdersDataGridView.InvalidateCell(sendToMbButtonCell);
        }

        private void SetSendToMoldingBoxCheckBox(DataGridView gridView, DataGridViewCellEventArgs eventArgs)
        {

            DataGridViewCheckBoxCell mbSentCell =
                (DataGridViewCheckBoxCell)
                    gridView.Rows[eventArgs.RowIndex].Cells[
                        gridView.Rows[eventArgs.RowIndex].Cells.IndexOf(
                            gridView.Rows[eventArgs.RowIndex].Cells["SentToMB"])];
            if (mbSentCell != null && !((bool) mbSentCell.Value))
            {
                mbSentCell.Value = true;
            }

        }

        private void LoadConfigurationFromAppConfig()
        {
            Configuration applicationConfigurations = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add an Application Setting.
            AppSettingsSection applicationSettings = (AppSettingsSection) applicationConfigurations.GetSection("appSettings");
            if (applicationSettings != null)
            {
                //Source
                _sourceServer = applicationSettings.Settings["SourceServerName"].Value;
                SourceServerTextBox.Text = _sourceServer;
                _sourceDatabsae = applicationSettings.Settings["SourceDatabaseName"].Value;
                SourceDatabaseTextBox.Text = _sourceDatabsae;
                _sourceUsername = applicationSettings.Settings["SourceUserName"].Value;
                SourceUsernameTextBox.Text = _sourceUsername;
                _sourcePassword = applicationSettings.Settings["SourcePassword"].Value;
                SourcePasswordTextBox.Text = _sourcePassword;
                //Staging
                _stagingServer = applicationSettings.Settings["StagingServerName"].Value;
                StagingServerTextBox.Text = _stagingServer;
                _stagingDatabase = applicationSettings.Settings["StagingDatabaseName"].Value;
                StagingDatabaseTextBox.Text = _stagingDatabase;
                _stagingUsername = applicationSettings.Settings["StagingUserName"].Value;
                StagingUsernameTextBox.Text = _stagingUsername;
                _stagingPassword = applicationSettings.Settings["StagingPassword"].Value;
                StagingPasswordTextBox.Text = _stagingPassword;

                _defaultEmail = applicationSettings.Settings["DefaultEmail"].Value;
                EmailTextbox.Text = _defaultEmail;

                _defaultPhone = applicationSettings.Settings["DefaultPhone"].Value;
                PhoneTextbox.Text = _defaultPhone;
            }
        }

        private void EnableDisableSendToMoldingBoxButton(DataGridView gridview)
        {
            foreach (DataGridViewRow ossOrdersDataGridRow in gridview.Rows)
            {                
                DataGridViewCheckBoxCell mbSentCell = (DataGridViewCheckBoxCell)ossOrdersDataGridRow.Cells[ossOrdersDataGridRow.Cells.IndexOf(ossOrdersDataGridRow.Cells["SentToMB"])];
                if (mbSentCell != null && ((bool) mbSentCell.Value))
                {
                    DataGridViewDisableButtonCell sendToMbButtonCell =
                        (DataGridViewDisableButtonCell)
                            ossOrdersDataGridRow.Cells[
                                ossOrdersDataGridRow.Cells.IndexOf(ossOrdersDataGridRow.Cells["btnSendShipMentToMB"])];
                    sendToMbButtonCell.Enabled = false;
                }
            }
        }

        private void AddSendButtonToGridView(DataGridView gridView)
        {
            DataGridViewDisableButtonColumn sendToMoldingBoxButtonColumn = new DataGridViewDisableButtonColumn();
            sendToMoldingBoxButtonColumn.HeaderText = "Send To MB";
            sendToMoldingBoxButtonColumn.Text = "Send >";
            sendToMoldingBoxButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sendToMoldingBoxButtonColumn.Name = "btnSendShipMentToMB";
            sendToMoldingBoxButtonColumn.ToolTipText = "Click to submit order to ModingBox for processing.";
            sendToMoldingBoxButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            sendToMoldingBoxButtonColumn.UseColumnTextForButtonValue = true;
            sendToMoldingBoxButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridView.Columns.Insert(15, sendToMoldingBoxButtonColumn);
        }
        
        private void AddReloadButtonToGridView(DataGridView gridView)
        {
            DataGridViewDisableButtonColumn sendToMoldingBoxButtonColumn = new DataGridViewDisableButtonColumn();
            sendToMoldingBoxButtonColumn.HeaderText = ReloadString;
            sendToMoldingBoxButtonColumn.Text = ReloadString;
            sendToMoldingBoxButtonColumn.MinimumWidth = 100;
            sendToMoldingBoxButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sendToMoldingBoxButtonColumn.Name = "btnReload";
            sendToMoldingBoxButtonColumn.ToolTipText = "Click to reload order.";
            sendToMoldingBoxButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            sendToMoldingBoxButtonColumn.UseColumnTextForButtonValue = true;
            sendToMoldingBoxButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns.Insert(19, sendToMoldingBoxButtonColumn);
        }
        private void AddPostAgainButtonToGridView(DataGridView gridView)
        {
            DataGridViewDisableButtonColumn sendToMoldingBoxButtonColumn = new DataGridViewDisableButtonColumn();
            sendToMoldingBoxButtonColumn.HeaderText = RePostString;
            sendToMoldingBoxButtonColumn.Text = RePostString;
            sendToMoldingBoxButtonColumn.MinimumWidth = 100;
            sendToMoldingBoxButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sendToMoldingBoxButtonColumn.Name = "btnRepost";
            sendToMoldingBoxButtonColumn.ToolTipText = "Click to re-post order.";
            sendToMoldingBoxButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            sendToMoldingBoxButtonColumn.UseColumnTextForButtonValue = true;
            sendToMoldingBoxButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns.Insert(20, sendToMoldingBoxButtonColumn);
        }
        
        private void AddCancelButtonToGridView(DataGridView gridView)
        {
            DataGridViewDisableButtonColumn sendToMoldingBoxButtonColumn = new DataGridViewDisableButtonColumn();
            sendToMoldingBoxButtonColumn.HeaderText = CancelString;
            sendToMoldingBoxButtonColumn.Text = CancelString;
            sendToMoldingBoxButtonColumn.MinimumWidth = 100;
            sendToMoldingBoxButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sendToMoldingBoxButtonColumn.Name = "btnCancel";
            sendToMoldingBoxButtonColumn.ToolTipText = "Click to cancel order.";
            sendToMoldingBoxButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            sendToMoldingBoxButtonColumn.UseColumnTextForButtonValue = true;
            sendToMoldingBoxButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridView.Columns.Insert(21, sendToMoldingBoxButtonColumn);
        }
        private void AddSyncButtonToGridView(DataGridView gridView)
        {
            DataGridViewDisableButtonColumn synchwithMoldingBoxButtonColumn = new DataGridViewDisableButtonColumn();
            synchwithMoldingBoxButtonColumn.HeaderText = SyncWithMb;
            synchwithMoldingBoxButtonColumn.Text = SyncWithMb;
            synchwithMoldingBoxButtonColumn.MinimumWidth = 100;
            synchwithMoldingBoxButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            synchwithMoldingBoxButtonColumn.Name = "btnSyncToMb";
            synchwithMoldingBoxButtonColumn.ToolTipText = "Click to Sync with Molding Box.";
            synchwithMoldingBoxButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            synchwithMoldingBoxButtonColumn.UseColumnTextForButtonValue = true;
            synchwithMoldingBoxButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridView.Columns.Insert(19, synchwithMoldingBoxButtonColumn);
        }
        private void SetOssOrderDataGridHeaderTextAndColumnVisibility(DataGridView gridView, OssOrdersGridTypes gridType)
        {

            if (gridView.InvokeRequired)
            {
                SetGridColumnsVisibility d = SetOssOrderDataGridHeaderTextAndColumnVisibility;
                Invoke(d, new object[] {gridView, gridType});
            }
            else
            {
                switch (gridType)
                {
                    case OssOrdersGridTypes.New:
                    {
                        #region New

                        if (gridView.Columns["THubOrderReferenceNo"] != null)
                        {
                            gridView.Columns["THubOrderReferenceNo"].HeaderText = "Order Ref #";
                            gridView.Columns["THubOrderReferenceNo"].ReadOnly = true;
                            gridView.Columns["THubOrderReferenceNo"].Width = 100;
                        }
                        if (gridView.Columns["CreatedOn"] != null)
                        {
                            gridView.Columns["CreatedOn"].HeaderText = "OSS Created On";
                            gridView.Columns["CreatedOn"].ReadOnly = true;
                            gridView.Columns["CreatedOn"].Width = 150;
                        }
                        if (gridView.Columns["THubCompleteOrder"] != null)
                        {
                            gridView.Columns["THubCompleteOrder"].HeaderText = "Complete Order";
                            gridView.Columns["THubCompleteOrder"].ReadOnly = true;
                            gridView.Columns["THubCompleteOrder"].MinimumWidth = 600;
                        }
                        if (gridView.Columns["OSSOrderId"] != null)
                            gridView.Columns["OSSOrderId"].Visible = false;
                        if (gridView.Columns["THubOrderId"] != null)
                            gridView.Columns["THubOrderId"].Visible = false;
                        if (gridView.Columns["OrderStatus"] != null)
                            gridView.Columns["OrderStatus"].Visible = false;
                        if (gridView.Columns["SentToMB"] != null)
                            gridView.Columns["SentToMB"].Visible = false;
                        if (gridView.Columns["SentToMBOn"] != null)
                            gridView.Columns["SentToMBOn"].Visible = false;
                        if (gridView.Columns["MBPostShipmentMessage"] != null)
                            gridView.Columns["MBPostShipmentMessage"].Visible = false;
                        if (gridView.Columns["MBPostShipmentResponseMessage"] != null)
                            gridView.Columns["MBPostShipmentResponseMessage"].Visible = false;
                        if (gridView.Columns["MBSuccessfullyReceived"] != null)
                            gridView.Columns["MBSuccessfullyReceived"].Visible = false;
                        if (gridView.Columns["MBShipmentSubmitError"] != null)
                            gridView.Columns["MBShipmentSubmitError"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThub"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThub"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThubOn"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThubOn"].Visible = false;
                        if (gridView.Columns["MBShipmentId"] != null)
                            gridView.Columns["MBShipmentId"].Visible = false;
                        if (gridView.Columns["LastSyncWithMBOn"] != null)
                            gridView.Columns["LastSyncWithMBOn"].Visible = false;
                        if (gridView.Columns["THubUpdatedOn"] != null)
                            gridView.Columns["THubUpdatedOn"].Visible = false;
                        if (gridView.Columns["MBTrackingNumber"] != null)
                            gridView.Columns["MBTrackingNumber"].Visible = false;
                        if (gridView.Columns["CancelMessage"] != null)
                            gridView.Columns["CancelMessage"].Visible = false;
                        if (gridView.Columns["MBShipmentMethod"] != null)
                            gridView.Columns["MBShipmentMethod"].Visible = false;

                        #endregion

                        break;
                    }
                    case OssOrdersGridTypes.Processing:
                    {
                        #region Processing

                        if (gridView.Columns["CreatedOn"] != null)
                        {
                            gridView.Columns["CreatedOn"].HeaderText = "OSS Created On";
                            gridView.Columns["CreatedOn"].ReadOnly = true;
                            gridView.Columns["CreatedOn"].MinimumWidth = 150;
                        }
                        if (gridView.Columns["THubOrderReferenceNo"] != null)
                        {
                            gridView.Columns["THubOrderReferenceNo"].HeaderText = "Order Ref #";
                            gridView.Columns["THubOrderReferenceNo"].ReadOnly = true;
                            gridView.Columns["THubOrderReferenceNo"].MinimumWidth = 100;
                        }
                        if (gridView.Columns["MBShipmentId"] != null)
                        {
                            gridView.Columns["MBShipmentId"].HeaderText = "MB Shipment Id";
                            gridView.Columns["MBShipmentId"].MinimumWidth = 150;
                            gridView.Columns["MBShipmentId"].ReadOnly = true;
                        }
                        if (gridView.Columns["SentToMBOn"] != null)
                        {
                            gridView.Columns["SentToMBOn"].HeaderText = "Posted On";
                            gridView.Columns["SentToMBOn"].ReadOnly = true;
                            gridView.Columns["SentToMBOn"].MinimumWidth = 150;
                        }
                        if (gridView.Columns["LastSyncWithMBOn"] != null)
                        {
                            gridView.Columns["LastSyncWithMBOn"].HeaderText = "Last Sync with MB On";
                            gridView.Columns["LastSyncWithMBOn"].ReadOnly = true;
                            gridView.Columns["LastSyncWithMBOn"].MinimumWidth = 150;
                        }
                        if (gridView.Columns["THubCompleteOrder"] != null)
                            gridView.Columns["THubCompleteOrder"].Visible = false;
                        if (gridView.Columns["OSSOrderId"] != null)
                            gridView.Columns["OSSOrderId"].Visible = false;
                        if (gridView.Columns["THubOrderId"] != null)
                            gridView.Columns["THubOrderId"].Visible = false;
                        if (gridView.Columns["SentToMB"] != null)
                            gridView.Columns["SentToMB"].Visible = false;
                        if (gridView.Columns["MBPostShipmentMessage"] != null)
                            gridView.Columns["MBPostShipmentMessage"].Visible = false;
                        if (gridView.Columns["MBPostShipmentResponseMessage"] != null)
                            gridView.Columns["MBPostShipmentResponseMessage"].Visible = false;
                        if (gridView.Columns["MBSuccessfullyReceived"] != null)
                            gridView.Columns["MBSuccessfullyReceived"].Visible = false;
                        if (gridView.Columns["MBShipmentSubmitError"] != null)
                            gridView.Columns["MBShipmentSubmitError"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThub"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThub"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThubOn"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThubOn"].Visible = false;
                        if (gridView.Columns["OrderStatus"] != null)
                            gridView.Columns["OrderStatus"].Visible = false;
                        if (gridView.Columns["THubUpdatedOn"] != null)
                            gridView.Columns["THubUpdatedOn"].Visible = false;
                        if (gridView.Columns["MBTrackingNumber"] != null)
                            gridView.Columns["MBTrackingNumber"].Visible = false;
                        if (gridView.Columns["CancelMessage"] != null)
                            gridView.Columns["CancelMessage"].Visible = false;
                        if (gridView.Columns["MBShipmentMethod"] != null)
                            gridView.Columns["MBShipmentMethod"].Visible = false;
                        
                        #endregion

                        break;
                    }
                    case OssOrdersGridTypes.Exception:
                    {
                        #region Exception

                        if (gridView.Columns["CreatedOn"] != null)
                        {
                            gridView.Columns["CreatedOn"].HeaderText = "OSS Created On";
                            gridView.Columns["CreatedOn"].ReadOnly = true;
                            gridView.Columns["CreatedOn"].MinimumWidth = 120;
                        }
                        if (gridView.Columns["THubOrderReferenceNo"] != null)
                        {
                            gridView.Columns["THubOrderReferenceNo"].HeaderText = "Order Ref #";
                            gridView.Columns["THubOrderReferenceNo"].ReadOnly = true;
                            gridView.Columns["THubOrderReferenceNo"].MinimumWidth = 100;
                        }
                        if (gridView.Columns["MBShipmentSubmitError"] != null)
                        {
                            gridView.Columns["MBShipmentSubmitError"].HeaderText = "Error Message";
                            gridView.Columns["MBShipmentSubmitError"].ReadOnly = true;
                            gridView.Columns["MBShipmentSubmitError"].MinimumWidth = 400;
                        }
                        if (gridView.Columns["SentToMBOn"] != null)
                        {
                            gridView.Columns["SentToMBOn"].HeaderText = "Posted On";
                            gridView.Columns["SentToMBOn"].ReadOnly = true;
                            gridView.Columns["SentToMBOn"].MinimumWidth = 100;
                        }
                        if (gridView.Columns["THubCompleteOrder"] != null)
                            gridView.Columns["THubCompleteOrder"].Visible = false;
                        if (gridView.Columns["OSSOrderId"] != null)
                            gridView.Columns["OSSOrderId"].Visible = false;
                        if (gridView.Columns["THubOrderId"] != null)
                            gridView.Columns["THubOrderId"].Visible = false;
                        if (gridView.Columns["SentToMB"] != null)
                            gridView.Columns["SentToMB"].Visible = false;
                        if (gridView.Columns["MBPostShipmentMessage"] != null)
                            gridView.Columns["MBPostShipmentMessage"].Visible = false;
                        if (gridView.Columns["MBPostShipmentResponseMessage"] != null)
                            gridView.Columns["MBPostShipmentResponseMessage"].Visible = false;
                        if (gridView.Columns["MBSuccessfullyReceived"] != null)
                            gridView.Columns["MBSuccessfullyReceived"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThub"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThub"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThubOn"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThubOn"].Visible = false;
                        if (gridView.Columns["OrderStatus"] != null)
                            gridView.Columns["OrderStatus"].Visible = false;
                        if (gridView.Columns["MBShipmentId"] != null)
                            gridView.Columns["MBShipmentId"].Visible = false;
                        if (gridView.Columns["LastSyncWithMBOn"] != null)
                            gridView.Columns["LastSyncWithMBOn"].Visible = false;
                        if (gridView.Columns["THubUpdatedOn"] != null)
                            gridView.Columns["THubUpdatedOn"].Visible = false;
                        if (gridView.Columns["MBTrackingNumber"] != null)
                            gridView.Columns["MBTrackingNumber"].Visible = false;
                        if (gridView.Columns["CancelMessage"] != null)
                            gridView.Columns["CancelMessage"].Visible = false;
                        if (gridView.Columns["MBShipmentMethod"] != null)
                            gridView.Columns["MBShipmentMethod"].Visible = false;

                        #endregion

                        break;
                    }
                    case OssOrdersGridTypes.Completed:
                    {
                        #region Completed

                        if (gridView.Columns["CreatedOn"] != null)
                        {
                            gridView.Columns["CreatedOn"].HeaderText = "OSS Created On";
                            gridView.Columns["CreatedOn"].ReadOnly = true;
                            //gridView.Columns["CreatedOn"].Width = 110;
                        }
                        if (gridView.Columns["THubOrderReferenceNo"] != null)
                        {
                            gridView.Columns["THubOrderReferenceNo"].HeaderText = "Order Ref #";
                            gridView.Columns["THubOrderReferenceNo"].ReadOnly = true;
                            //gridView.Columns["THubOrderReferenceNo"].Width = 110;
                        }

                        if (gridView.Columns["SentToMBOn"] != null)
                        {
                            gridView.Columns["SentToMBOn"].HeaderText = "Posted On";
                            gridView.Columns["SentToMBOn"].ReadOnly = true;
                            //gridView.Columns["SentToMBOn"].Width = 100;
                        }
                        if (gridView.Columns["MBShipmentId"] != null)
                        {
                            gridView.Columns["MBShipmentId"].HeaderText = "MB Shipment Id";
                            gridView.Columns["MBShipmentId"].ReadOnly = true;
                            //gridView.Columns["MBShipmentId"].Width = 150;
                        }
                        if (gridView.Columns["LastSyncWithMBOn"] != null)
                        {
                            gridView.Columns["LastSyncWithMBOn"].HeaderText = "Last Sync with MB On";
                            gridView.Columns["LastSyncWithMBOn"].ReadOnly = true;
                            //gridView.Columns["LastSyncWithMBOn"].Width = 150;
                        }
                        if (gridView.Columns["THubUpdatedOn"] != null)
                        {
                            gridView.Columns["THubUpdatedOn"].HeaderText = "T-Hub Updated On";
                            gridView.Columns["THubUpdatedOn"].ReadOnly = true;
                            //gridView.Columns["THubUpdatedOn"].Width = 150;
                        }
                        if (gridView.Columns["MBTrackingNumber"] != null)
                        {
                            gridView.Columns["MBTrackingNumber"].HeaderText = "Tracking Number";
                            gridView.Columns["MBTrackingNumber"].ReadOnly = true;
                            //gridView.Columns["MBTrackingNumber"].Width = 150;                        
                        }
                        if (gridView.Columns["MBShipmentSubmitError"] != null)
                            gridView.Columns["MBShipmentSubmitError"].Visible = false;
                        if (gridView.Columns["THubCompleteOrder"] != null)
                            gridView.Columns["THubCompleteOrder"].Visible = false;
                        if (gridView.Columns["OSSOrderId"] != null)
                            gridView.Columns["OSSOrderId"].Visible = false;
                        if (gridView.Columns["THubOrderId"] != null)
                            gridView.Columns["THubOrderId"].Visible = false;
                        if (gridView.Columns["SentToMB"] != null)
                            gridView.Columns["SentToMB"].Visible = false;
                        if (gridView.Columns["MBPostShipmentMessage"] != null)
                            gridView.Columns["MBPostShipmentMessage"].Visible = false;
                        if (gridView.Columns["MBPostShipmentResponseMessage"] != null)
                            gridView.Columns["MBPostShipmentResponseMessage"].Visible = false;
                        if (gridView.Columns["MBSuccessfullyReceived"] != null)
                            gridView.Columns["MBSuccessfullyReceived"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThub"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThub"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThubOn"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThubOn"].Visible = false;
                        if (gridView.Columns["OrderStatus"] != null)
                            gridView.Columns["OrderStatus"].Visible = false;
                        if (gridView.Columns["CancelMessage"] != null)
                            gridView.Columns["CancelMessage"].Visible = false;
                        if (gridView.Columns["MBShipmentMethod"] != null)
                            gridView.Columns["MBShipmentMethod"].Visible = false;

                        #endregion

                        break;
                    }
                    case OssOrdersGridTypes.OnHold:
                    {
                        #region On Hold

                        if (gridView.Columns["CreatedOn"] != null)
                        {
                            gridView.Columns["CreatedOn"].HeaderText = "OSS Created On";
                            gridView.Columns["CreatedOn"].ReadOnly = true;
                            gridView.Columns["CreatedOn"].Width = 150;
                        }
                        if (gridView.Columns["THubOrderReferenceNo"] != null)
                        {
                            gridView.Columns["THubOrderReferenceNo"].HeaderText = "Order Ref #";
                            gridView.Columns["THubOrderReferenceNo"].ReadOnly = true;
                            gridView.Columns["THubOrderReferenceNo"].Width = 100;
                        }
                        if (gridView.Columns["MBShipmentSubmitError"] != null)
                            gridView.Columns["MBShipmentSubmitError"].Visible = false;
                        if (gridView.Columns["SentToMBOn"] != null)
                        {
                            gridView.Columns["SentToMBOn"].HeaderText = "Posted On";
                            gridView.Columns["SentToMBOn"].ReadOnly = true;
                            gridView.Columns["SentToMBOn"].Width = 150;
                        }
                        if (gridView.Columns["MBShipmentId"] != null)
                        {
                            gridView.Columns["MBShipmentId"].HeaderText = "MB Shipment Id";
                            gridView.Columns["MBShipmentId"].ReadOnly = true;
                            gridView.Columns["MBShipmentId"].Width = 150;
                        }
                        if (gridView.Columns["LastSyncWithMBOn"] != null)
                        {
                            gridView.Columns["LastSyncWithMBOn"].HeaderText = "Last Sync with MB On";
                            gridView.Columns["LastSyncWithMBOn"].ReadOnly = true;
                            gridView.Columns["LastSyncWithMBOn"].Width = 150;
                        }
                        if (gridView.Columns["THubCompleteOrder"] != null)
                            gridView.Columns["THubCompleteOrder"].Visible = false;
                        if (gridView.Columns["OSSOrderId"] != null)
                            gridView.Columns["OSSOrderId"].Visible = false;
                        if (gridView.Columns["THubOrderId"] != null)
                            gridView.Columns["THubOrderId"].Visible = false;
                        if (gridView.Columns["SentToMB"] != null)
                            gridView.Columns["SentToMB"].Visible = false;
                        if (gridView.Columns["MBPostShipmentMessage"] != null)
                            gridView.Columns["MBPostShipmentMessage"].Visible = false;
                        if (gridView.Columns["MBPostShipmentResponseMessage"] != null)
                            gridView.Columns["MBPostShipmentResponseMessage"].Visible = false;
                        if (gridView.Columns["MBSuccessfullyReceived"] != null)
                            gridView.Columns["MBSuccessfullyReceived"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThub"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThub"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThubOn"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThubOn"].Visible = false;
                        if (gridView.Columns["OrderStatus"] != null)
                            gridView.Columns["OrderStatus"].Visible = false;
                        if (gridView.Columns["THubUpdatedOn"] != null)
                            gridView.Columns["THubUpdatedOn"].Visible = false;
                        if (gridView.Columns["MBTrackingNumber"] != null)
                            gridView.Columns["MBTrackingNumber"].Visible = false;
                        if (gridView.Columns["CancelMessage"] != null)
                            gridView.Columns["CancelMessage"].Visible = false;
                        if (gridView.Columns["MBShipmentMethod"] != null)
                            gridView.Columns["MBShipmentMethod"].Visible = false;

                        #endregion

                        break;
                    }
                    case OssOrdersGridTypes.Cancelled:
                    {
                        #region Canceled

                        if (gridView.Columns["CreatedOn"] != null)
                        {
                            gridView.Columns["CreatedOn"].HeaderText = "OSS Created On";
                            gridView.Columns["CreatedOn"].ReadOnly = true;
                            gridView.Columns["CreatedOn"].MinimumWidth = 110;
                        }
                        if (gridView.Columns["THubOrderReferenceNo"] != null)
                        {
                            gridView.Columns["THubOrderReferenceNo"].HeaderText = "Order Ref #";
                            gridView.Columns["THubOrderReferenceNo"].ReadOnly = true;
                            gridView.Columns["THubOrderReferenceNo"].MinimumWidth = 110;
                        }
                        if (gridView.Columns["MBShipmentSubmitError"] != null)
                        {
                            gridView.Columns["MBShipmentSubmitError"].HeaderText = "MB Shipment Error";
                            gridView.Columns["MBShipmentSubmitError"].ReadOnly = true;
                            gridView.Columns["MBShipmentSubmitError"].MinimumWidth = 250;
                        }
                        if (gridView.Columns["SentToMBOn"] != null)
                        {
                            gridView.Columns["SentToMBOn"].HeaderText = "Posted On";
                            gridView.Columns["SentToMBOn"].ReadOnly = true;
                            gridView.Columns["SentToMBOn"].MinimumWidth = 110;
                        }
                        if (gridView.Columns["MBShipmentId"] != null)
                        {
                            gridView.Columns["MBShipmentId"].HeaderText = "MB Shipment Id";
                            gridView.Columns["MBShipmentId"].ReadOnly = true;
                            gridView.Columns["MBShipmentId"].MinimumWidth = 150;
                        }
                        if (gridView.Columns["LastSyncWithMBOn"] != null)
                        {
                            gridView.Columns["LastSyncWithMBOn"].HeaderText = "Last Sync with MB On";
                            gridView.Columns["LastSyncWithMBOn"].ReadOnly = true;
                            gridView.Columns["LastSyncWithMBOn"].MinimumWidth = 100;
                        }
                        if (gridView.Columns["CancelMessage"] != null)
                        {
                            gridView.Columns["CancelMessage"].HeaderText = "Cancel Message";
                            gridView.Columns["CancelMessage"].ReadOnly = true;
                            gridView.Columns["CancelMessage"].MinimumWidth = 250;
                        }
                        if (gridView.Columns["THubCompleteOrder"] != null)
                            gridView.Columns["THubCompleteOrder"].Visible = false;
                        if (gridView.Columns["OSSOrderId"] != null)
                            gridView.Columns["OSSOrderId"].Visible = false;
                        if (gridView.Columns["THubOrderId"] != null)
                            gridView.Columns["THubOrderId"].Visible = false;
                        if (gridView.Columns["SentToMB"] != null)
                            gridView.Columns["SentToMB"].Visible = false;
                        if (gridView.Columns["MBPostShipmentMessage"] != null)
                            gridView.Columns["MBPostShipmentMessage"].Visible = false;
                        if (gridView.Columns["MBPostShipmentResponseMessage"] != null)
                            gridView.Columns["MBPostShipmentResponseMessage"].Visible = false;
                        if (gridView.Columns["MBSuccessfullyReceived"] != null)
                            gridView.Columns["MBSuccessfullyReceived"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThub"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThub"].Visible = false;
                        if (gridView.Columns["MBShipmentIdSubmitedToThubOn"] != null)
                            gridView.Columns["MBShipmentIdSubmitedToThubOn"].Visible = false;
                        if (gridView.Columns["OrderStatus"] != null)
                            gridView.Columns["OrderStatus"].Visible = false;
                        if (gridView.Columns["THubUpdatedOn"] != null)
                            gridView.Columns["THubUpdatedOn"].Visible = false;
                        if (gridView.Columns["MBTrackingNumber"] != null)
                            gridView.Columns["MBTrackingNumber"].Visible = false;
                        if (gridView.Columns["MBShipmentMethod"] != null)
                            gridView.Columns["MBShipmentMethod"].Visible = false;

                        #endregion

                        break;
                    }
                }
                
            }
        }        
        

        private void OssOrdersDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            apiKey = MoldinboxKeyTextBox.Text;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && !String.IsNullOrWhiteSpace(apiKey))
            {                
                if (((DataGridView)sender).Name == OssOrdersDataGridView.Name)
                {
                    HandleSendToMoldingBox(e, senderGrid);
                }
                else if (((DataGridView) sender).Name == OssExceptionGridView.Name)
                {
                    HandleExceptionGridActions(e, senderGrid);
                }
                else if (((DataGridView) sender).Name == OssInFlightGridView.Name)
                {
                    SyncWithMoldingBox(((DataTable)senderGrid.DataSource).Rows[e.RowIndex]);
                }
            }
        }
        
        private void HandleSendToMoldingBox(DataGridViewCellEventArgs e, DataGridView senderGrid)        
        {
            MBAPISoapClient client = MoldingBoxHelper.GetMoldingBoxClient();
            DataGridViewDisableButtonCell sendToMbButtonCell = (DataGridViewDisableButtonCell)senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (sendToMbButtonCell.Enabled)
            {
                if (shipmentMethods == null || !shipmentMethods.Any())
                {
                    shipmentMethods = client.Retrieve_Merchant_Shipping_Methods(apiKey);
                }
                DataRow ossOrderRow = ((DataTable) senderGrid.DataSource).Rows[e.RowIndex];

                string orderJsonString = ossOrderRow["THubCompleteOrder"].ToString();
                if (!String.IsNullOrWhiteSpace(orderJsonString))
                {
                    OssShipment[] shipments = new OssShipment[1]
                    {
                        JsonConvert.DeserializeObject<OssShipment>(orderJsonString)
                    };

                    string MBShipmentMethod = MapShipment(shipments[0], shipmentMethods);
                    if (string.IsNullOrEmpty(MBShipmentMethod))
                        return;
                    Shipment[] shipmentToPost = new Shipment[1];
                    foreach (OssShipment ossShipment in shipments.ToList())
                    {
                        shipmentToPost[0] = CreateFrom(ossShipment);
                    }
                    DateTime shipmentRequestSentOn = DateTime.Now;
                    Response[] responses = MoldingBoxHelper.PostShipment(client, apiKey, shipmentToPost);
                    SetOrderStatus(ossOrderRow, shipmentRequestSentOn, MBShipmentMethod, responses, shipments);
                    _orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);
                    senderGrid.DataBindings.Clear();
                    senderGrid.DataSource = _ossOrders;
                }
                SetSendToMoldingBoxCheckBox(senderGrid, e);
                DisableSentToMoldingBoxButton(sendToMbButtonCell);
            }
        }
        private void RepostShipmentToBoldingBox(DataRow ossOrderRow)
        {
            apiKey = MoldinboxKeyTextBox.Text; 
            MBAPISoapClient client = MoldingBoxHelper.GetMoldingBoxClient();
            string orderJsonString = ossOrderRow["THubCompleteOrder"].ToString();
            if (!string.IsNullOrWhiteSpace(orderJsonString))
            {
                if (shipmentMethods == null || !shipmentMethods.Any())
                {
                    shipmentMethods = client.Retrieve_Merchant_Shipping_Methods(apiKey);
                }

                OssShipment[] shipments = new OssShipment[1]
                    {
                        JsonConvert.DeserializeObject<OssShipment>(orderJsonString)
                    };
                string MBShipmentMethod = MapShipment(shipments[0], shipmentMethods);
                if (string.IsNullOrEmpty(MBShipmentMethod))
                    return;
                Shipment[] shipmentToPost = new Shipment[1];
                shipmentToPost[0] = CreateFrom(shipments[0]);
                DateTime shipmentRequestSentOn = DateTime.Now;
                Response[] responses = MoldingBoxHelper.PostShipment(client, apiKey, shipmentToPost);
                SetOrderStatus(ossOrderRow, shipmentRequestSentOn, MBShipmentMethod, responses, shipments);
                _orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);                
            }
        }
        private void HandleExceptionGridActions(DataGridViewCellEventArgs e, DataGridView senderGrid)
        {            
            DataGridViewDisableButtonCell sendToMbButtonCell = (DataGridViewDisableButtonCell)senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (sendToMbButtonCell.FormattedValue == CancelString)
            {
                CancelMessageForm cancelMessageForm = new CancelMessageForm();
                DialogResult results = cancelMessageForm.ShowDialog(this);
                if (cancelMessageForm.Result == DialogResult.OK)
                {
                    DataRow ossOrderRow = ((DataTable)senderGrid.DataSource).Rows[e.RowIndex];
                    ossOrderRow["CancelMessage"] = cancelMessageForm.CancelMessageString;
                    ossOrderRow["OrderStatus"] = (int)OSSOrderStatus.Canceled;
                    _orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);                    
                }
            }
            else if (sendToMbButtonCell.Value == ReloadString)
            {
                DataRow ossOrderRow = ((DataTable)senderGrid.DataSource).Rows[e.RowIndex];
                _orderSyncronizationDatabase.ReloadShipmentToStaging(long.Parse(ossOrderRow["THubOrderId"].ToString()));
            }
            else if (sendToMbButtonCell.Value == RePostString)
            {
                RepostShipmentToBoldingBox(((DataTable) senderGrid.DataSource).Rows[e.RowIndex]);
            }            
            DataTable ossExceptionDataTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.Exception);
            senderGrid.DataBindings.Clear();
            senderGrid.DataSource = ossExceptionDataTable;
        }
        private void SyncWithMoldingBox(DataRow ossOrderRow)
        {
            string mbShipmentID = ossOrderRow["MBShipmentId"].ToString();
            string orderId = ossOrderRow["THubOrderId"].ToString();
            string orderChannelRefNumber = ossOrderRow["THubOrderReferenceNo"].ToString();
            string mbShipmentMethod = ossOrderRow["MBShipmentMethod"].ToString();
            apiKey = MoldinboxKeyTextBox.Text;
            MBAPISoapClient client = MoldingBoxHelper.GetMoldingBoxClient();
            StatusResponse[] statusResponse = client.Retrieve_Shipment_Status(apiKey, new ArrayOfInt() { int.Parse(mbShipmentID) });
            if (statusResponse[0].ShipmentExists)
            {
                if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.Completed) // Handle in processing
                {
                    _orderSyncronizationDatabase.UpdateOrderTrackingAndOssStatus(statusResponse[0], long.Parse(orderId), orderChannelRefNumber, mbShipmentMethod);                    
                }
                else if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.InFlight || statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.Recieved)
                {
                    _orderSyncronizationDatabase.UpdateLastSyncDateOfOrder(long.Parse(orderId));
                }
                else if (statusResponse[0].ShipmentStatusID == (int) OSSOrderStatus.OnHold)
                {
                    _orderSyncronizationDatabase.UpdateOrderStatusCanceledOrOnHold(long.Parse(orderId),
                        OSSOrderStatus.OnHold);
                }
                else if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.Canceled)
                {
                    _orderSyncronizationDatabase.UpdateOrderStatusCanceledOrOnHold(long.Parse(orderId), OSSOrderStatus.Canceled);
                }
            }            
        }
        private void SetOrderStatus(DataRow ossOrderRow, DateTime shipmentRequestSentOn, string MBShipmentMethod, Response[] responses, OssShipment[] shipments)
        {            
            Response response = responses[0];
            if (response.MBShipmentID == 0)
            {
                ossOrderRow["SentToMB"] = false;
                ossOrderRow["OrderStatus"] = (int) OSSOrderStatus.Exception;
                ossOrderRow["MBShipmentSubmitError"] = response.ErrorMessage;
            }
            else
            {
                ossOrderRow["SentToMB"] = true;
                ossOrderRow["OrderStatus"] = (int)OSSOrderStatus.InFlight;                
                ossOrderRow["MBShipmentId"] = response.MBShipmentID.ToString();
                ossOrderRow["MBShipmentSubmitError"] = string.Empty;
            }
            ossOrderRow["MBShipmentMethod"] = MBShipmentMethod;
            ossOrderRow["SentToMBOn"] = shipmentRequestSentOn;
            ossOrderRow["MBPostShipmentMessage"] = JsonConvert.SerializeObject(new OssShipmentMessage(apiKey, shipments));
            ossOrderRow["MBPostShipmentResponseMessage"] = JsonConvert.SerializeObject(responses);
            ossOrderRow["MBSuccessfullyReceived"] = response.SuccessfullyReceived;            
            ossOrderRow["CancelMessage"] = string.Empty;
            
        }
        private string MapShipment(OssShipment shipment, ShippingMethod[] moldingBoxShippingMethods)
        {
            string destinationMapping = _orderSyncronizationDatabase.LoadShipmentMethodMapping(true, shipment.WebShipMethod);
            if (string.IsNullOrEmpty(destinationMapping))
            {
                CreateMappingForm form = new CreateMappingForm(_orderSyncronizationDatabase, shipment.WebShipMethod, moldingBoxShippingMethods);
                DialogResult result = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    shipment.ShippingMethodID = form.MbShipMethodId;
                    return form.MbShipMethod;
                }
            }
            else
            {
                ShippingMethod mbShipMethod = moldingBoxShippingMethods.FirstOrDefault(mb => mb.Method == destinationMapping);
                if (mbShipMethod != null)
                {
                    shipment.ShippingMethodID = mbShipMethod.ID;
                    return mbShipMethod.Method;
                }
                
            }
            return string.Empty;
        }

        private Shipment CreateFrom(OssShipment source)
        {
            return new Shipment
            {
                Address1 = source.Address1,
                Address2 = source.Address2,
                CODAmount = source.CODAmount,
                City = source.City,
                Company = source.Company,
                Country = source.Country,
                Custom1 = source.Custom1,
                Custom2 = source.Custom2,
                Custom3 = source.Custom3,
                Custom4 = source.Custom4,
                Custom5 = source.Custom5,
                Custom6 = source.Custom6,
                Email = source.Email,                
                FirstName = source.FirstName,
                Items = source.Items,
                LastName = source.LastName,
                OrderID = source.OrderID,
                Orderdate = source.Orderdate,
                Phone = source.Phone,
                ShippingMethodID = source.ShippingMethodID,
                State = source.State,
                Zip = source.Zip
            };
        }

        #region Exception Handlers

        private void ExceptionRefresh()
        {
            DataTable ossExceptionDataTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.Exception);
            if (ossExceptionDataTable.Rows.Count > 0)
            {
                OssExceptionGridView.DataSource = ossExceptionDataTable;
                if (!_autoSyncActive)
                {
                    if (OssExceptionGridView.ColumnCount == 20)
                    {
                        AddReloadButtonToGridView(OssExceptionGridView);
                        AddPostAgainButtonToGridView(OssExceptionGridView);
                        AddCancelButtonToGridView(OssExceptionGridView);

                    }
                }
                SetOssOrderDataGridHeaderTextAndColumnVisibility(OssExceptionGridView, OssOrdersGridTypes.Exception);
            }
            else
            {
                OssExceptionGridView.DataBindings.Clear();
                if (!_autoSyncActive)
                {
                    MessageBox.Show("No Exception Order available in T-Hub.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ExceptionOrdersLabel.Text = "Total No. of Orders: " + ossExceptionDataTable.Rows.Count;
        }
        
        #endregion
        #region Processing Handlers
        private void InFlightRefresh()
        {
            DataTable ossInFlightDataTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.InFlight);
            if (ossInFlightDataTable.Rows.Count > 0)
            {
                OssInFlightGridView.DataSource = ossInFlightDataTable;
                if (!_autoSyncActive)
                {
                    if (OssInFlightGridView.ColumnCount == 20)
                    {
                        AddSyncButtonToGridView(OssInFlightGridView);
                    }
                }
                SetOssOrderDataGridHeaderTextAndColumnVisibility(OssInFlightGridView, OssOrdersGridTypes.Processing);   
            }
            else
            {
                OssInFlightGridView.DataBindings.Clear();
                if (!_autoSyncActive)
                {
                    MessageBox.Show("No In-Flight Order available in T-Hub.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            InFlightOrdersLabel.Text = "Total No. of Orders: " + ossInFlightDataTable.Rows.Count;
        }
        private void OssInFlightGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OssOrdersDataGridView_CellContentClick_1(sender, e);
        }
        
        #endregion
        #region Fulfilled Handlers
        private void CompleteRefresh()
        {
            DataTable ossCompletedDataTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.Completed);
            if (ossCompletedDataTable.Rows.Count > 0)
            {
                OssCompletedGridView.DataSource = ossCompletedDataTable;
                SetOssOrderDataGridHeaderTextAndColumnVisibility(OssCompletedGridView, OssOrdersGridTypes.Completed);
            }
            else
            {
                OssCompletedGridView.DataBindings.Clear();
                if (!_autoSyncActive)
                {
                    MessageBox.Show("No Completed Order available in T-Hub.", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            CompletedOrdersLabel.Text = "Total No. of Orders: " + ossCompletedDataTable.Rows.Count;
        }
        
        private void OssExceptionGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OssOrdersDataGridView_CellContentClick_1(sender, e);
        }
        #endregion
        #region On-Hold Handlers
        private void OnHoldRefresh()
        {
            DataTable ossOnHoldDatasource = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.OnHold);
            if (ossOnHoldDatasource.Rows.Count > 0)
            {
                OSSOrderOnHoldGridView.DataSource = ossOnHoldDatasource;
                SetOssOrderDataGridHeaderTextAndColumnVisibility(OSSOrderOnHoldGridView, OssOrdersGridTypes.OnHold);
            }
            else
            {
                OSSOrderOnHoldGridView.DataBindings.Clear();
                if (!_autoSyncActive)
                {
                    MessageBox.Show("No On-Hold Order available in T-Hub.", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            OnHoldOrdersLabel.Text = "Total No. of Orders: " + ossOnHoldDatasource.Rows.Count;
        }
        
        #endregion
        #region Cancel handlers
        
        private void CancelRefresh()
        {
            DataTable ossCanceledTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.Canceled);
            if (ossCanceledTable.Rows.Count > 0)
            {
                OssOrdersCanceledOrders.DataSource = ossCanceledTable;
                SetOssOrderDataGridHeaderTextAndColumnVisibility(OssOrdersCanceledOrders, OssOrdersGridTypes.Cancelled);
            }
            else
            {
                OssOrdersCanceledOrders.DataBindings.Clear();
                if (!_autoSyncActive)
                {
                    MessageBox.Show("No Canceled Order available in T-Hub.", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            CancelOrdersLabel.Text = "Total No. of Orders: " + ossCanceledTable.Rows.Count;
        }
        #endregion
        private void MainWindow_Resize(object sender, EventArgs e)
        {            
            notifyIcon.BalloonTipText = "Running";
            notifyIcon.BalloonTipTitle = "Order Synchronization System.";
            if (hideWhenMinimized && this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000);
                ShowInTaskbar = false;
            }
            else if (FormWindowState.Normal == WindowState)
            {
                notifyIcon.Visible = false;
                Show();
                ShowInTaskbar = true;
            }
        }

        private void ShowNotificationText(string text)
        {
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipTitle = "Order Synchronization System.";
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3000);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;            
        }

        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_autoSyncActive)
            {
                _autoSyncOrder.cancellationTokenSource.Cancel();
            }
            Close();
        }

        

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void shipmentMappingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipmentMappingForm shimepForm = new ShipmentMappingForm(_orderSyncronizationDatabase);
            shimepForm.ShowDialog(this);
        }

        private void hideWhenMinimizedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                hideWhenMinimized = ((ToolStripMenuItem)sender).Checked = false;
            }
            else
            {
                hideWhenMinimized = ((ToolStripMenuItem)sender).Checked = true;
            }
        }

        private void viewSystemLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLogForm logForm = new ViewLogForm(_orderSyncronizationDatabase);
            logForm.ShowDialog(this);
        }

        public void ClearAllGrids()
        {
            OssOrdersDataGridView.DataBindings.Clear();
            OssExceptionGridView.DataBindings.Clear();
            OssInFlightGridView.DataBindings.Clear();
            OssOrdersCanceledOrders.DataBindings.Clear();
            OssCompletedGridView.DataBindings.Clear();
            OSSOrderOnHoldGridView.DataBindings.Clear();
        }

        public void ReloadAllGrid()
        {
            LoadOrderFromStagingButton_Click(null, null);
            InFlightRefresh();
            ExceptionRefresh();
            CompleteRefresh();
            OnHoldRefresh();
            CancelRefresh();
        }
        public void EnableDisableFieldsForAutoSync(bool enableOrDisable)
        {
            ToolStripButton.Enabled = enableOrDisable;
            SourceDatabaseTextBox.Enabled =
                SourcePasswordTextBox.Enabled =
                    SourceUsernameTextBox.Enabled = SourceServerTextBox.Enabled = enableOrDisable;
            StagingDatabaseTextBox.Enabled =
                StagingPasswordTextBox.Enabled =
                    StagingUsernameTextBox.Enabled = StagingServerTextBox.Enabled = enableOrDisable;
            SaveSourceButon.Enabled = CancelSourceButton.Enabled = enableOrDisable;
            SaveStagingButton.Enabled = CancelStagingButton.Enabled = enableOrDisable;
            EmailTextbox.Enabled =
                PhoneTextbox.Enabled =
                    SyncMoldingBoxIntervalTextbox.Enabled = SyncNewOrderTextbox.Enabled = enableOrDisable;
            
        }

        private void ToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            switch (MainFormTabControl.SelectedTab.Name)
            {
                case "NewOrderTabPage":
                    {
                        LoadOrderFromStagingButton_Click(null, null);
                        break;
                    }
                case "InFight":
                    {
                        InFlightRefresh();
                        break;
                    }
                case "Exception":
                    {
                        ExceptionRefresh();
                        break;
                    }
                case "Completed":
                    {
                        CompleteRefresh();
                        break;
                    }
                case "OnHold":
                    {
                        OnHoldRefresh();
                        break;
                    }
                case "Canceled":
                    {
                        CancelRefresh();
                        break;
                    }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopThread();
        }
        public delegate void ReloadGridsDelegate();
        public ReloadGridsDelegate reloadGridsDelegate;

        
        private void MainFormTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (_autoSyncActive)
            {
                this.MainFormTabControl.SelectedIndex = 0;
            }
        }
    }
}
