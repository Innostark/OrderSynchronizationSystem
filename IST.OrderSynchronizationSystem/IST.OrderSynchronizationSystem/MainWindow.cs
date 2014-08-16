using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.Models;
using IST.OrderSynchronizationSystem.Properties;
using System.Configuration;

namespace IST.OrderSynchronizationSystem
{
    public partial class MainWindow : Form
    {
        private bool _autoSyncActive;
        private int _autoSyncFrequency;
        private readonly AutoSynchOrder _autoSyncOrder;
        delegate void SetTextCallback(string text);
        private OssDatabase _orderSyncronizationDatabase;
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
        private DataTable _ossOrders = null;


        public MainWindow(bool programState)
        {
            InitializeComponent();
            this.LoadConfigurationFromAppConfig();
            this.InitializeDatabaseParameters();
            _autoSyncActive = programState;
            _autoSyncFrequency = 0;
            _autoSyncOrder = new AutoSynchOrder();            
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
            InitializeDatabaseParameters();

            if (!VarifySourceDatabase())
            {
                toolStripStatus.Text = Resources.MainWindow_UnableToConnection_SourceDatabase;
                return;
            }
            if (!VarifyStagingDatabase())
            {
                toolStripStatus.Text = Resources.MainWindow_UnableToConnection_StagingDatabase;
                return;
            }
            StartPauseToggleButton(true);
            _autoSyncFrequency = int.Parse(maskedTextBox1.Text);

            StartThread();

        }

        private void PauseAutoSychronization()
        {
            StartPauseToggleButton(false);
            StopThread();
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
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                FormErrorProvider.SetError(maskedTextBox1, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            int minutes;
            if (!string.IsNullOrEmpty(maskedTextBox1.Text) && int.TryParse(maskedTextBox1.Text, out minutes))
            {
                if (minutes > 999 || minutes < 5)
                {
                    FormErrorProvider.SetError(maskedTextBox1, Resources.MainWindow_MinutesRange);
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
            Task.Factory.StartNew(() => _autoSyncOrder.Process(this, _autoSyncFrequency));
        }
        private void StopThread()
        {
            _autoSyncOrder.cancellationTokenSource.Cancel();
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
                toolStripStatus.Text = text;
        }

        private bool VarifySourceDatabase()
        {
            toolStripStatus.Text = Resources.MainWindow_VarifySourceDatabase_Checking_source_database;
            return _orderSyncronizationDatabase.VarifySourceDatabase();
        }
        private bool VarifyStagingDatabase()
        {
            toolStripStatus.Text = Resources.MainWindow_VarifySourceDatabase_Checking_Staging_database;
            return _orderSyncronizationDatabase.VarifySourceDatabase();
        }

        private void SynchronizeOrdersFromTHubButton_Click(object sender, EventArgs e)
        {
            var ossShipments = new List<OssShipment>();
            try
            {
                //Check source database
                if (!VarifySourceDatabase())
                {
                    toolStripStatus.Text = Resources.MainWindow_UnableToConnection_SourceDatabase;
                    return;
                }
                //Check Staging database
                if (!VarifyStagingDatabase())
                {
                    toolStripStatus.Text = Resources.MainWindow_UnableToConnection_StagingDatabase;
                    return;
                }

                ossShipments = this._orderSyncronizationDatabase.LoadShipmentsFromThub();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}{1}{2}", "Error while loading orders form T-Hub.", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this._orderSyncronizationDatabase.InsertShipmentsToStaging(ossShipments);

        }

        private void SaveSourceButon_Click(object sender, EventArgs e)
        {
            this.SetDatabaseSettings("Source");
        }

        private void SaveStagingButton_Click(object sender, EventArgs e)
        {
            this.SetDatabaseSettings("Staging");
        }

        private void SetDatabaseSettings(string dbSettings)
        {
            var readyToSave = true;
            var errorText = String.Empty;

            var server = (dbSettings == "Source" ? SourceServerTextBox.Text : StagingServerTextBox.Text);
            var database = (dbSettings == "Source" ? SourceDatabaseTextBox.Text : StagingDatabaseTextBox.Text);
            var username = (dbSettings == "Source" ? SourceUsernameTextBox.Text : StagingUsernameTextBox.Text);
            var password = (dbSettings == "Source" ? SourcePasswordTextBox.Text : StagingPasswordTextBox.Text);

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
                var applicationSettings = (AppSettingsSection) applicationConfigurations.GetSection("appSettings");
                if (applicationSettings != null)
                {
                    applicationSettings.Settings[dbSettings + "ServerName"].Value = server;
                    applicationSettings.Settings[dbSettings + "DatabaseName"].Value = database;
                    applicationSettings.Settings[dbSettings + "UserName"].Value = username;
                    applicationSettings.Settings[dbSettings + "Password"].Value = password;
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
                MessageBox.Show(this, errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.MainFormTabControl.SelectTab(this.OSSOrderTabPage);
        }

        private void LoadConfigurationFromAppConfig()
        {
            Configuration applicationConfigurations = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add an Application Setting.
            var applicationSettings = (AppSettingsSection) applicationConfigurations.GetSection("appSettings");
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
            }
        }

        private void LoadOrderFromStagingButton_Click(object sender, EventArgs e)
        {
            this._ossOrders = this._orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders");
            this.OssOrdersDataGridView.DataSource = this._ossOrders;

            this.OssOrdersDataGridView.Columns[0].Visible = false;
            this.OssOrdersDataGridView.Columns[1].Visible = false;
            this.OssOrdersDataGridView.Columns[2].HeaderText = "Order #";
            this.OssOrdersDataGridView.Columns[3].HeaderText = "Created On";
            this.OssOrdersDataGridView.Columns[4].Visible = false;
            this.OssOrdersDataGridView.Columns[5].HeaderText = "MB Sent";
            this.OssOrdersDataGridView.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.OssOrdersDataGridView.Columns[6].HeaderText = "MB Sent On";
            this.OssOrdersDataGridView.Columns[7].Visible = false;
            this.OssOrdersDataGridView.Columns[8].HeaderText = "Shipment Id";
            this.OssOrdersDataGridView.Columns[9].HeaderText = "MB Shipment Id";
            this.OssOrdersDataGridView.Columns[10].Visible = false;
            this.OssOrdersDataGridView.Columns[11].Visible = false;
            this.OssOrdersDataGridView.Columns[12].Visible = false;
            this.OssOrdersDataGridView.Columns[13].Visible = false;


            var sendToMoldingBoxButtonColumn = new DataGridViewButtonColumn();
            sendToMoldingBoxButtonColumn.HeaderText = "Send To MB";
            sendToMoldingBoxButtonColumn.Text = "Send >";
            sendToMoldingBoxButtonColumn.Name = "btnSendShipMentToMB";
            sendToMoldingBoxButtonColumn.ToolTipText = "Click to submit order to ModingBox for processing.";
            sendToMoldingBoxButtonColumn.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 6.25F, FontStyle.Bold);
            sendToMoldingBoxButtonColumn.UseColumnTextForButtonValue = true;
            sendToMoldingBoxButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            OssOrdersDataGridView.Columns.Add(sendToMoldingBoxButtonColumn);

        }

        private void OssOrdersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var row = this._ossOrders.Rows[e.RowIndex];

                //Manual Send to Molding Box
                MessageBox.Show("Implement the send to Molding Box, Order Reference # " + row["THubOrderReferenceNo"].ToString());
            }
        }
    }
}
