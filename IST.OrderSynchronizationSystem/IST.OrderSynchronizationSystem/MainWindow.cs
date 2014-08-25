using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private ShippingMethod[] shipmentMethods;

        public MainWindow(bool programState)
        {
            InitializeComponent();
            LoadConfigurationFromAppConfig();
            InitializeDatabaseParameters();
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
        private void SetDatabaseSettings(string dbSettings)
        {
            bool readyToSave = true;
            string errorText = String.Empty;

            string server = (dbSettings == "Source" ? SourceServerTextBox.Text : StagingServerTextBox.Text);
            string database = (dbSettings == "Source" ? SourceDatabaseTextBox.Text : StagingDatabaseTextBox.Text);
            string username = (dbSettings == "Source" ? SourceUsernameTextBox.Text : StagingUsernameTextBox.Text);
            string password = (dbSettings == "Source" ? SourcePasswordTextBox.Text : StagingPasswordTextBox.Text);

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

        private void SynchronizeOrdersFromTHubButton_Click(object sender, EventArgs e)
        {
            List<OssShipment> ossShipments = new List<OssShipment>();
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

                ossShipments = _orderSyncronizationDatabase.LoadShipmentsFromThub();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}{1}{2}", "Error while loading orders form T-Hub.", Environment.NewLine, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _orderSyncronizationDatabase.InsertShipmentsToStaging(ossShipments);

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
            _ossOrders = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.New);
            if (_ossOrders.Rows.Count > 0)
            {
                OssOrdersDataGridView.DataSource = _ossOrders;
            }
            else
            {
                MessageBox.Show("No New Order available is T-Hub.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            NoOfOrdersLabel.Text = "No. of Order: " + _ossOrders.Rows.Count.ToString();
        }


        private void DisableSentToMoldingBoxButton(DataGridViewDisableButtonCell sendToMbButtonCell)
        {
            sendToMbButtonCell.Enabled = false;
            OssOrdersDataGridView.InvalidateCell(sendToMbButtonCell);
        }

        private void SetSendToMoldingBoxCheckBox(DataGridViewCellEventArgs eventArgs)
        {
            if (OssOrdersDataGridView.ColumnCount == 15)
            {
                DataGridViewCheckBoxCell mbSentCell = (DataGridViewCheckBoxCell) OssOrdersDataGridView.Rows[eventArgs.RowIndex].Cells[6];
                if (mbSentCell != null && !((bool) mbSentCell.Value))
                {
                    mbSentCell.Value = true;
                }
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
            }
        }

        private void EnableDisableSendToMoldingBoxButton()
        {
            foreach (DataGridViewRow ossOrdersDataGridRow in OssOrdersDataGridView.Rows)
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

        private void AddDisableSendButtonToOssOrderDataGridView()
        {
            DataGridViewDisableButtonColumn sendToMoldingBoxButtonColumn = new DataGridViewDisableButtonColumn();
            sendToMoldingBoxButtonColumn.HeaderText = "Send To MB";
            sendToMoldingBoxButtonColumn.Text = "Send >";
            sendToMoldingBoxButtonColumn.Name = "btnSendShipMentToMB";
            sendToMoldingBoxButtonColumn.ToolTipText = "Click to submit order to ModingBox for processing.";
            sendToMoldingBoxButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            sendToMoldingBoxButtonColumn.UseColumnTextForButtonValue = true;
            sendToMoldingBoxButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            OssOrdersDataGridView.Columns.Insert(15, sendToMoldingBoxButtonColumn);
        }

        private void SetOssOrderDataGridHeaderTextAndColumnVisibility(DataGridView gridView)
        {
            if (gridView.Columns["OSSOrderId"] != null)
                gridView.Columns["OSSOrderId"].Visible = false;

            if (gridView.Columns["THubOrderId"] != null)
            {
                gridView.Columns["THubOrderId"].Visible = false;
            }
            if (gridView.Columns["THubOrderReferenceNo"] != null)
            {
                gridView.Columns["THubOrderReferenceNo"].HeaderText = "Order Ref #";
                gridView.Columns["THubOrderReferenceNo"].ReadOnly = true;
            }
            if (gridView.Columns["CreatedOn"] != null)
            {
                gridView.Columns["CreatedOn"].HeaderText = "OSS Created On";
                gridView.Columns["CreatedOn"].ReadOnly = true;
            }
            if (gridView.Columns["THubCompleteOrder"] != null)
            {
                gridView.Columns["THubCompleteOrder"].Visible = false;
            }
            if (gridView.Columns["SentToMB"] != null)
            {
                gridView.Columns["SentToMB"].HeaderText = "Sent";
                gridView.Columns["SentToMB"].ReadOnly = true;
            }
            if (gridView.Columns["SentToMBOn"] != null)
            {
                gridView.Columns["SentToMBOn"].HeaderText = "Sent On";
                gridView.Columns["SentToMBOn"].ReadOnly = true;
            }
            if (gridView.Columns["MBPostShipmentMessage"] != null)
            {
                gridView.Columns["MBPostShipmentMessage"].Visible = false;
            }
            if (gridView.Columns["MBPostShipmentResponseMessage"] != null)
            {
                gridView.Columns["MBPostShipmentResponseMessage"].Visible = false;
            }
            if (gridView.Columns["MBSuccessfullyReceived"] != null)
            {
                gridView.Columns["MBSuccessfullyReceived"].Visible = false;
            }
            if (gridView.Columns["MBShipmentId"] != null)
            {
                gridView.Columns["MBShipmentId"].HeaderText = "MB Shipment Id";
                gridView.Columns["MBShipmentId"].ReadOnly = true;
            }
            if (gridView.Columns["MBShipmentSubmitError"] != null)
            {
                gridView.Columns["MBShipmentSubmitError"].HeaderText = "MB Shipment Error";
                gridView.Columns["MBShipmentSubmitError"].ReadOnly = true;
            }
            if (gridView.Columns["MBShipmentIdSubmitedToThub"] != null)
            {
                gridView.Columns["MBShipmentIdSubmitedToThub"].Visible = false;
            }
            if (gridView.Columns["MBShipmentIdSubmitedToThubOn"] != null)
            {
                gridView.Columns["MBShipmentIdSubmitedToThubOn"].Visible = false;
            }
            if (gridView.Columns["OrderStatus"] != null)
            {
                gridView.Columns["OrderStatus"].HeaderText = "Status";
                gridView.Columns["OrderStatus"].ReadOnly = true;
            }
        }

        private void OssOrdersDataGridView_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetOssOrderDataGridHeaderTextAndColumnVisibility((DataGridView)sender);
            if (OssOrdersDataGridView.ColumnCount == 15)
            {
                //Format columns and add send button column                
                AddDisableSendButtonToOssOrderDataGridView();                
            }
            EnableDisableSendToMoldingBoxButton();
        }

        private void SendToMoldingBoxButton_Click(object sender, EventArgs e)
        {

        }

        private DataTable ShipmentMapping;

        private void OssOrdersDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            string apiKey = MoldinboxKeyTextBox.Text;            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && !String.IsNullOrWhiteSpace(apiKey))
            {
                MBAPISoapClient client = MoldingBoxHelper.GetMoldingBoxClient();
                shipmentMethods = client.Retrieve_Shipping_Methods();
                DataRow row = _ossOrders.Rows[e.RowIndex];
                
                DataGridViewDisableButtonCell sendToMbButtonCell = (DataGridViewDisableButtonCell)OssOrdersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (sendToMbButtonCell.Enabled)
                {
                    DataRow ossOrderRow = _ossOrders.Rows[e.RowIndex];
                    
                    string orderJsonString = ossOrderRow["THubCompleteOrder"].ToString();
                    if (!String.IsNullOrWhiteSpace(orderJsonString))
                    {
                        OssShipment[] shipments = new OssShipment[1]
                        {
                            JsonConvert.DeserializeObject<OssShipment>(orderJsonString)
                        };

                        MapShipment(shipments[0], shipmentMethods);
                        Shipment [] shipmentToPost = new Shipment[1];
                        foreach (OssShipment ossShipment in shipments.ToList())
                        {
                            shipmentToPost[0] = CreateFrom(ossShipment);
                        }
                        DateTime shipmentRequestSentOn = DateTime.Now;
                        Response[] responses = MoldingBoxHelper.PostShipment(client, apiKey, shipmentToPost);
                        SetOrderStatus(ossOrderRow, shipmentRequestSentOn, responses, shipments, apiKey);
                        _orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);
                        OssOrdersDataGridView.DataBindings.Clear();
                        OssOrdersDataGridView.DataSource = _ossOrders;                        
                    }
                    SetSendToMoldingBoxCheckBox(e);
                    DisableSentToMoldingBoxButton(sendToMbButtonCell);
                }
            }
        }

        private void SetOrderStatus(DataRow ossOrderRow, DateTime shipmentRequestSentOn, Response[] responses, OssShipment[] shipments, string apiKey)
        {
            
            Response response = responses[0];
            if (response.MBShipmentID == 0)
            {
                ossOrderRow["OrderStatus"] = (int) OSSOrderStatus.Exception;
                ossOrderRow["MBShipmentSubmitError"] = response.ErrorMessage;
            }
            else
            {
                ossOrderRow["OrderStatus"] = (int)OSSOrderStatus.InFlight;
                ossOrderRow["SentToMB"] = true;
                ossOrderRow["SentToMBOn"] = shipmentRequestSentOn;
                ossOrderRow["MBShipmentId"] = response.MBShipmentID.ToString();
            }
            ossOrderRow["MBPostShipmentMessage"] = JsonConvert.SerializeObject(new OssShipmentMessage(apiKey, shipments));
            ossOrderRow["MBPostShipmentResponseMessage"] = JsonConvert.SerializeObject(responses);
            ossOrderRow["MBSuccessfullyReceived"] = response.SuccessfullyReceived;
        }
        private void MapShipment(OssShipment shipment, ShippingMethod[] moldingBoxShippingMethods)
        {

            string destinationMapping = _orderSyncronizationDatabase.LoadShipmentMethodMapping(true, shipment.WebShipMethod);
            if (string.IsNullOrEmpty(destinationMapping))
            {
                CreateMappingForm form = new CreateMappingForm(_orderSyncronizationDatabase, shipment.WebShipMethod,
                    moldingBoxShippingMethods);
                DialogResult result = form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    shipment.ShippingMethodID = form.MbShipMethodId;
                }
            }
            else
            {
                ShippingMethod mbShipMethod = moldingBoxShippingMethods.FirstOrDefault(mb => mb.Method == destinationMapping);
                if (mbShipMethod != null)
                {
                    shipment.ShippingMethodID = mbShipMethod.ID;
                }
            }
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

        private void ExceptionRefresh_Click(object sender, EventArgs e)
        {
            DataTable ossExceptionDataTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.Exception);
            if (ossExceptionDataTable.Rows.Count > 0)
            {
                OssExceptionGridView.DataSource = ossExceptionDataTable;
            }
            else
            {
                MessageBox.Show("No Exception Order available in T-Hub.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OssExceptionGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetOssOrderDataGridHeaderTextAndColumnVisibility((DataGridView) sender);
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            DataTable ossCompletedDataTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.Completed);
            if (ossCompletedDataTable.Rows.Count > 0)
            {
                OssCompletedGridView.DataSource = ossCompletedDataTable;
            }
            else
            {
                MessageBox.Show("No Completed Order available in T-Hub.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OssCompletedGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetOssOrderDataGridHeaderTextAndColumnVisibility((DataGridView)sender);
        }

        

        private void InFlightRefresh_Click(object sender, EventArgs e)
        {
            DataTable ossInFlightDataTable = _orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrders", OSSOrderStatus.InFlight);
            if (ossInFlightDataTable.Rows.Count > 0)
            {
                OssInFlightGridView.DataSource = ossInFlightDataTable;
            }
            else
            {
                MessageBox.Show("No In-Flight Order available in T-Hub.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OssInFlightGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetOssOrderDataGridHeaderTextAndColumnVisibility((DataGridView)sender);
        }
    }
}
