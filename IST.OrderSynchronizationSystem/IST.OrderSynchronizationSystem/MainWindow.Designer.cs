namespace IST.OrderSynchronizationSystem
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ApplicationMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipmentMappingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSystemLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideWhenMinimizedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormTabControl = new System.Windows.Forms.TabControl();
            this.ConfigurationTabPage = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PhoneTextbox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MoldingBoxApiKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.MoldinboxKeyTextBox = new System.Windows.Forms.TextBox();
            this.MoldingBoxApiKeyLabel = new System.Windows.Forms.Label();
            this.SynchronizeButton = new System.Windows.Forms.Button();
            this.AutomaticOrderSynchronizeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SyncMoldingBoxIntervalTextbox = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SyncNewOrderTextbox = new System.Windows.Forms.MaskedTextBox();
            this.SynchronizeIntervalMinutesLabel = new System.Windows.Forms.Label();
            this.SynchronizeIntervalLabel = new System.Windows.Forms.Label();
            this.StagingDbGroupBox = new System.Windows.Forms.GroupBox();
            this.CancelStagingButton = new System.Windows.Forms.Button();
            this.StagingServerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveStagingButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StagingDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.StagingPasswordTextBox = new System.Windows.Forms.TextBox();
            this.StagingUsernameTextBox = new System.Windows.Forms.TextBox();
            this.SourceGroupBox = new System.Windows.Forms.GroupBox();
            this.CancelSourceButton = new System.Windows.Forms.Button();
            this.SaveSourceButon = new System.Windows.Forms.Button();
            this.SourcePasswordTextBox = new System.Windows.Forms.TextBox();
            this.SourceUsernameTextBox = new System.Windows.Forms.TextBox();
            this.SourceDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.SourceServerTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.NewOrderTabPage = new System.Windows.Forms.TabPage();
            this.NoOfOrdersLabel = new System.Windows.Forms.Label();
            this.LoadOrderFromStagingGroupBox = new System.Windows.Forms.GroupBox();
            this.DisplayStagingOrderButton = new System.Windows.Forms.Button();
            this.OSSOrdersGroupBox = new System.Windows.Forms.GroupBox();
            this.OssOrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.SyncOrdersWithTHubGroupBox = new System.Windows.Forms.GroupBox();
            this.LoadOrdersFromTHubButton = new System.Windows.Forms.Button();
            this.InFight = new System.Windows.Forms.TabPage();
            this.InFlightOrdersLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OssInFlightGridView = new System.Windows.Forms.DataGridView();
            this.Exception = new System.Windows.Forms.TabPage();
            this.ExceptionOrdersLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OssExceptionGridView = new System.Windows.Forms.DataGridView();
            this.Completed = new System.Windows.Forms.TabPage();
            this.CompletedOrdersLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OssCompletedGridView = new System.Windows.Forms.DataGridView();
            this.OnHold = new System.Windows.Forms.TabPage();
            this.OnHoldOrdersLabel = new System.Windows.Forms.Label();
            this.OnHoldGroupBox = new System.Windows.Forms.GroupBox();
            this.OSSOrderOnHoldGridView = new System.Windows.Forms.DataGridView();
            this.Canceled = new System.Windows.Forms.TabPage();
            this.CancelOrdersLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.OssOrdersCanceledOrders = new System.Windows.Forms.DataGridView();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.ApplicationStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ApplicationMenuStrip.SuspendLayout();
            this.MainFormTabControl.SuspendLayout();
            this.ConfigurationTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.MoldingBoxApiKeyGroupBox.SuspendLayout();
            this.AutomaticOrderSynchronizeSettingsGroupBox.SuspendLayout();
            this.StagingDbGroupBox.SuspendLayout();
            this.SourceGroupBox.SuspendLayout();
            this.NewOrderTabPage.SuspendLayout();
            this.LoadOrderFromStagingGroupBox.SuspendLayout();
            this.OSSOrdersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OssOrdersDataGridView)).BeginInit();
            this.SyncOrdersWithTHubGroupBox.SuspendLayout();
            this.InFight.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OssInFlightGridView)).BeginInit();
            this.Exception.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OssExceptionGridView)).BeginInit();
            this.Completed.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OssCompletedGridView)).BeginInit();
            this.OnHold.SuspendLayout();
            this.OnHoldGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OSSOrderOnHoldGridView)).BeginInit();
            this.Canceled.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OssOrdersCanceledOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.ApplicationStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplicationMenuStrip
            // 
            this.ApplicationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.ApplicationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ApplicationMenuStrip.Name = "ApplicationMenuStrip";
            this.ApplicationMenuStrip.Size = new System.Drawing.Size(1234, 24);
            this.ApplicationMenuStrip.TabIndex = 1;
            this.ApplicationMenuStrip.Text = "Application Menu Strip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shipmentMappingsToolStripMenuItem,
            this.viewSystemLogsToolStripMenuItem,
            this.hideWhenMinimizedToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // shipmentMappingsToolStripMenuItem
            // 
            this.shipmentMappingsToolStripMenuItem.Name = "shipmentMappingsToolStripMenuItem";
            this.shipmentMappingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.shipmentMappingsToolStripMenuItem.Text = "Shipment Mappings";
            this.shipmentMappingsToolStripMenuItem.Click += new System.EventHandler(this.shipmentMappingsToolStripMenuItem_Click);
            // 
            // viewSystemLogsToolStripMenuItem
            // 
            this.viewSystemLogsToolStripMenuItem.Name = "viewSystemLogsToolStripMenuItem";
            this.viewSystemLogsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewSystemLogsToolStripMenuItem.Text = "View System Logs";
            this.viewSystemLogsToolStripMenuItem.Click += new System.EventHandler(this.viewSystemLogsToolStripMenuItem_Click);
            // 
            // hideWhenMinimizedToolStripMenuItem1
            // 
            this.hideWhenMinimizedToolStripMenuItem1.Name = "hideWhenMinimizedToolStripMenuItem1";
            this.hideWhenMinimizedToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.hideWhenMinimizedToolStripMenuItem1.Text = "Hide When &Minimized";
            this.hideWhenMinimizedToolStripMenuItem1.Click += new System.EventHandler(this.hideWhenMinimizedToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorsToolStripMenuItem,
            this.logToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // errorsToolStripMenuItem
            // 
            this.errorsToolStripMenuItem.Name = "errorsToolStripMenuItem";
            this.errorsToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.errorsToolStripMenuItem.Text = "Errors";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // MainFormTabControl
            // 
            this.MainFormTabControl.Controls.Add(this.ConfigurationTabPage);
            this.MainFormTabControl.Controls.Add(this.NewOrderTabPage);
            this.MainFormTabControl.Controls.Add(this.InFight);
            this.MainFormTabControl.Controls.Add(this.Exception);
            this.MainFormTabControl.Controls.Add(this.Completed);
            this.MainFormTabControl.Controls.Add(this.OnHold);
            this.MainFormTabControl.Controls.Add(this.Canceled);
            this.MainFormTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormTabControl.Location = new System.Drawing.Point(0, 24);
            this.MainFormTabControl.Name = "MainFormTabControl";
            this.MainFormTabControl.SelectedIndex = 0;
            this.MainFormTabControl.Size = new System.Drawing.Size(1234, 636);
            this.MainFormTabControl.TabIndex = 5;
            // 
            // ConfigurationTabPage
            // 
            this.ConfigurationTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ConfigurationTabPage.Controls.Add(this.splitter1);
            this.ConfigurationTabPage.Controls.Add(this.groupBox4);
            this.ConfigurationTabPage.Controls.Add(this.MoldingBoxApiKeyGroupBox);
            this.ConfigurationTabPage.Controls.Add(this.SynchronizeButton);
            this.ConfigurationTabPage.Controls.Add(this.AutomaticOrderSynchronizeSettingsGroupBox);
            this.ConfigurationTabPage.Controls.Add(this.StagingDbGroupBox);
            this.ConfigurationTabPage.Controls.Add(this.SourceGroupBox);
            this.ConfigurationTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigurationTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConfigurationTabPage.Name = "ConfigurationTabPage";
            this.ConfigurationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigurationTabPage.Size = new System.Drawing.Size(1226, 610);
            this.ConfigurationTabPage.TabIndex = 0;
            this.ConfigurationTabPage.Text = "Configuration";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(3, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 604);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PhoneTextbox);
            this.groupBox4.Controls.Add(this.phoneLabel);
            this.groupBox4.Controls.Add(this.EmailTextbox);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(8, 252);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 55);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Default Phone/Email ";
            // 
            // PhoneTextbox
            // 
            this.PhoneTextbox.Location = new System.Drawing.Point(302, 19);
            this.PhoneTextbox.Name = "PhoneTextbox";
            this.PhoneTextbox.Size = new System.Drawing.Size(180, 20);
            this.PhoneTextbox.TabIndex = 18;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(245, 23);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(38, 13);
            this.phoneLabel.TabIndex = 17;
            this.phoneLabel.Text = "Phone";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Location = new System.Drawing.Point(69, 20);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(162, 20);
            this.EmailTextbox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Email";
            // 
            // MoldingBoxApiKeyGroupBox
            // 
            this.MoldingBoxApiKeyGroupBox.Controls.Add(this.MoldinboxKeyTextBox);
            this.MoldingBoxApiKeyGroupBox.Controls.Add(this.MoldingBoxApiKeyLabel);
            this.MoldingBoxApiKeyGroupBox.Location = new System.Drawing.Point(8, 178);
            this.MoldingBoxApiKeyGroupBox.Name = "MoldingBoxApiKeyGroupBox";
            this.MoldingBoxApiKeyGroupBox.Size = new System.Drawing.Size(994, 68);
            this.MoldingBoxApiKeyGroupBox.TabIndex = 4;
            this.MoldingBoxApiKeyGroupBox.TabStop = false;
            this.MoldingBoxApiKeyGroupBox.Text = "Molding Box API Key";
            // 
            // MoldinboxKeyTextBox
            // 
            this.MoldinboxKeyTextBox.BackColor = System.Drawing.Color.PowderBlue;
            this.MoldinboxKeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoldinboxKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoldinboxKeyTextBox.ForeColor = System.Drawing.Color.DarkRed;
            this.MoldinboxKeyTextBox.Location = new System.Drawing.Point(69, 33);
            this.MoldinboxKeyTextBox.Name = "MoldinboxKeyTextBox";
            this.MoldinboxKeyTextBox.Size = new System.Drawing.Size(862, 20);
            this.MoldinboxKeyTextBox.TabIndex = 15;
            this.MoldinboxKeyTextBox.Text = "MBLLTAtOr8wKNI2Z44oPj2s81Hea6F";
            // 
            // MoldingBoxApiKeyLabel
            // 
            this.MoldingBoxApiKeyLabel.AutoSize = true;
            this.MoldingBoxApiKeyLabel.Location = new System.Drawing.Point(29, 33);
            this.MoldingBoxApiKeyLabel.Name = "MoldingBoxApiKeyLabel";
            this.MoldingBoxApiKeyLabel.Size = new System.Drawing.Size(30, 15);
            this.MoldingBoxApiKeyLabel.TabIndex = 16;
            this.MoldingBoxApiKeyLabel.Text = "Key:";
            // 
            // SynchronizeButton
            // 
            this.SynchronizeButton.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.PlayImage;
            this.SynchronizeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SynchronizeButton.Location = new System.Drawing.Point(892, 313);
            this.SynchronizeButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.SynchronizeButton.Name = "SynchronizeButton";
            this.SynchronizeButton.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.SynchronizeButton.Size = new System.Drawing.Size(110, 30);
            this.SynchronizeButton.TabIndex = 14;
            this.SynchronizeButton.Text = "Start";
            this.SynchronizeButton.UseVisualStyleBackColor = true;
            this.SynchronizeButton.Click += new System.EventHandler(this.SynchronizeButton_Click);
            // 
            // AutomaticOrderSynchronizeSettingsGroupBox
            // 
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SyncMoldingBoxIntervalTextbox);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.label7);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.label6);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SyncNewOrderTextbox);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeIntervalMinutesLabel);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeIntervalLabel);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutomaticOrderSynchronizeSettingsGroupBox.Location = new System.Drawing.Point(508, 252);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Name = "AutomaticOrderSynchronizeSettingsGroupBox";
            this.AutomaticOrderSynchronizeSettingsGroupBox.Size = new System.Drawing.Size(494, 55);
            this.AutomaticOrderSynchronizeSettingsGroupBox.TabIndex = 3;
            this.AutomaticOrderSynchronizeSettingsGroupBox.TabStop = false;
            this.AutomaticOrderSynchronizeSettingsGroupBox.Text = "Automatic Order Synchronize Settings";
            // 
            // SyncMoldingBoxIntervalTextbox
            // 
            this.SyncMoldingBoxIntervalTextbox.Location = new System.Drawing.Point(420, 22);
            this.SyncMoldingBoxIntervalTextbox.Mask = "000";
            this.SyncMoldingBoxIntervalTextbox.Name = "SyncMoldingBoxIntervalTextbox";
            this.SyncMoldingBoxIntervalTextbox.Size = new System.Drawing.Size(48, 20);
            this.SyncMoldingBoxIntervalTextbox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(384, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "(mins)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Sync to Moldingbox Interval:";
            // 
            // SyncNewOrderTextbox
            // 
            this.SyncNewOrderTextbox.Location = new System.Drawing.Point(170, 22);
            this.SyncNewOrderTextbox.Mask = "000";
            this.SyncNewOrderTextbox.Name = "SyncNewOrderTextbox";
            this.SyncNewOrderTextbox.Size = new System.Drawing.Size(48, 20);
            this.SyncNewOrderTextbox.TabIndex = 13;
            // 
            // SynchronizeIntervalMinutesLabel
            // 
            this.SynchronizeIntervalMinutesLabel.AutoSize = true;
            this.SynchronizeIntervalMinutesLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.SynchronizeIntervalMinutesLabel.Location = new System.Drawing.Point(133, 25);
            this.SynchronizeIntervalMinutesLabel.Name = "SynchronizeIntervalMinutesLabel";
            this.SynchronizeIntervalMinutesLabel.Size = new System.Drawing.Size(34, 13);
            this.SynchronizeIntervalMinutesLabel.TabIndex = 3;
            this.SynchronizeIntervalMinutesLabel.Text = "(mins)";
            // 
            // SynchronizeIntervalLabel
            // 
            this.SynchronizeIntervalLabel.AutoSize = true;
            this.SynchronizeIntervalLabel.Location = new System.Drawing.Point(6, 25);
            this.SynchronizeIntervalLabel.Name = "SynchronizeIntervalLabel";
            this.SynchronizeIntervalLabel.Size = new System.Drawing.Size(131, 13);
            this.SynchronizeIntervalLabel.TabIndex = 1;
            this.SynchronizeIntervalLabel.Text = "Sync New Orders Interval:";
            // 
            // StagingDbGroupBox
            // 
            this.StagingDbGroupBox.Controls.Add(this.CancelStagingButton);
            this.StagingDbGroupBox.Controls.Add(this.StagingServerTextBox);
            this.StagingDbGroupBox.Controls.Add(this.label1);
            this.StagingDbGroupBox.Controls.Add(this.SaveStagingButton);
            this.StagingDbGroupBox.Controls.Add(this.label2);
            this.StagingDbGroupBox.Controls.Add(this.label3);
            this.StagingDbGroupBox.Controls.Add(this.label4);
            this.StagingDbGroupBox.Controls.Add(this.StagingDatabaseTextBox);
            this.StagingDbGroupBox.Controls.Add(this.StagingPasswordTextBox);
            this.StagingDbGroupBox.Controls.Add(this.StagingUsernameTextBox);
            this.StagingDbGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StagingDbGroupBox.Location = new System.Drawing.Point(529, 6);
            this.StagingDbGroupBox.Name = "StagingDbGroupBox";
            this.StagingDbGroupBox.Size = new System.Drawing.Size(473, 166);
            this.StagingDbGroupBox.TabIndex = 2;
            this.StagingDbGroupBox.TabStop = false;
            this.StagingDbGroupBox.Text = "Staging Database";
            // 
            // CancelStagingButton
            // 
            this.CancelStagingButton.BackColor = System.Drawing.Color.DarkGray;
            this.CancelStagingButton.Location = new System.Drawing.Point(369, 128);
            this.CancelStagingButton.Name = "CancelStagingButton";
            this.CancelStagingButton.Size = new System.Drawing.Size(98, 32);
            this.CancelStagingButton.TabIndex = 12;
            this.CancelStagingButton.Text = "Cancel";
            this.CancelStagingButton.UseVisualStyleBackColor = false;
            // 
            // StagingServerTextBox
            // 
            this.StagingServerTextBox.Location = new System.Drawing.Point(78, 29);
            this.StagingServerTextBox.Name = "StagingServerTextBox";
            this.StagingServerTextBox.Size = new System.Drawing.Size(389, 20);
            this.StagingServerTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server:";
            // 
            // SaveStagingButton
            // 
            this.SaveStagingButton.BackColor = System.Drawing.Color.OliveDrab;
            this.SaveStagingButton.Location = new System.Drawing.Point(265, 128);
            this.SaveStagingButton.Name = "SaveStagingButton";
            this.SaveStagingButton.Size = new System.Drawing.Size(98, 32);
            this.SaveStagingButton.TabIndex = 11;
            this.SaveStagingButton.Text = "Save";
            this.SaveStagingButton.UseVisualStyleBackColor = false;
            this.SaveStagingButton.Click += new System.EventHandler(this.SaveStagingButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Usename:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Password:";
            // 
            // StagingDatabaseTextBox
            // 
            this.StagingDatabaseTextBox.BackColor = System.Drawing.Color.PowderBlue;
            this.StagingDatabaseTextBox.Location = new System.Drawing.Point(78, 54);
            this.StagingDatabaseTextBox.Name = "StagingDatabaseTextBox";
            this.StagingDatabaseTextBox.Size = new System.Drawing.Size(389, 20);
            this.StagingDatabaseTextBox.TabIndex = 8;
            // 
            // StagingPasswordTextBox
            // 
            this.StagingPasswordTextBox.BackColor = System.Drawing.Color.PowderBlue;
            this.StagingPasswordTextBox.Location = new System.Drawing.Point(78, 105);
            this.StagingPasswordTextBox.Name = "StagingPasswordTextBox";
            this.StagingPasswordTextBox.PasswordChar = '*';
            this.StagingPasswordTextBox.Size = new System.Drawing.Size(389, 20);
            this.StagingPasswordTextBox.TabIndex = 10;
            // 
            // StagingUsernameTextBox
            // 
            this.StagingUsernameTextBox.Location = new System.Drawing.Point(78, 80);
            this.StagingUsernameTextBox.Name = "StagingUsernameTextBox";
            this.StagingUsernameTextBox.Size = new System.Drawing.Size(389, 20);
            this.StagingUsernameTextBox.TabIndex = 9;
            // 
            // SourceGroupBox
            // 
            this.SourceGroupBox.Controls.Add(this.CancelSourceButton);
            this.SourceGroupBox.Controls.Add(this.SaveSourceButon);
            this.SourceGroupBox.Controls.Add(this.SourcePasswordTextBox);
            this.SourceGroupBox.Controls.Add(this.SourceUsernameTextBox);
            this.SourceGroupBox.Controls.Add(this.SourceDatabaseTextBox);
            this.SourceGroupBox.Controls.Add(this.SourceServerTextBox);
            this.SourceGroupBox.Controls.Add(this.PasswordLabel);
            this.SourceGroupBox.Controls.Add(this.UsernameLabel);
            this.SourceGroupBox.Controls.Add(this.DatabaseLabel);
            this.SourceGroupBox.Controls.Add(this.ServerLabel);
            this.SourceGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceGroupBox.Location = new System.Drawing.Point(8, 6);
            this.SourceGroupBox.Name = "SourceGroupBox";
            this.SourceGroupBox.Size = new System.Drawing.Size(458, 166);
            this.SourceGroupBox.TabIndex = 1;
            this.SourceGroupBox.TabStop = false;
            this.SourceGroupBox.Text = "Source Database (T-Hub)";
            // 
            // CancelSourceButton
            // 
            this.CancelSourceButton.BackColor = System.Drawing.Color.DarkGray;
            this.CancelSourceButton.Location = new System.Drawing.Point(354, 129);
            this.CancelSourceButton.Name = "CancelSourceButton";
            this.CancelSourceButton.Size = new System.Drawing.Size(98, 32);
            this.CancelSourceButton.TabIndex = 6;
            this.CancelSourceButton.Text = "Cancel";
            this.CancelSourceButton.UseVisualStyleBackColor = false;
            // 
            // SaveSourceButon
            // 
            this.SaveSourceButon.BackColor = System.Drawing.Color.OliveDrab;
            this.SaveSourceButon.Location = new System.Drawing.Point(250, 129);
            this.SaveSourceButon.Name = "SaveSourceButon";
            this.SaveSourceButon.Size = new System.Drawing.Size(98, 32);
            this.SaveSourceButon.TabIndex = 5;
            this.SaveSourceButon.Text = "Save";
            this.SaveSourceButon.UseVisualStyleBackColor = false;
            this.SaveSourceButon.Click += new System.EventHandler(this.SaveSourceButon_Click);
            // 
            // SourcePasswordTextBox
            // 
            this.SourcePasswordTextBox.BackColor = System.Drawing.Color.PowderBlue;
            this.SourcePasswordTextBox.Location = new System.Drawing.Point(69, 106);
            this.SourcePasswordTextBox.Name = "SourcePasswordTextBox";
            this.SourcePasswordTextBox.PasswordChar = '*';
            this.SourcePasswordTextBox.Size = new System.Drawing.Size(383, 20);
            this.SourcePasswordTextBox.TabIndex = 4;
            // 
            // SourceUsernameTextBox
            // 
            this.SourceUsernameTextBox.Location = new System.Drawing.Point(69, 80);
            this.SourceUsernameTextBox.Name = "SourceUsernameTextBox";
            this.SourceUsernameTextBox.Size = new System.Drawing.Size(383, 20);
            this.SourceUsernameTextBox.TabIndex = 3;
            // 
            // SourceDatabaseTextBox
            // 
            this.SourceDatabaseTextBox.BackColor = System.Drawing.Color.PowderBlue;
            this.SourceDatabaseTextBox.Location = new System.Drawing.Point(69, 54);
            this.SourceDatabaseTextBox.Name = "SourceDatabaseTextBox";
            this.SourceDatabaseTextBox.Size = new System.Drawing.Size(383, 20);
            this.SourceDatabaseTextBox.TabIndex = 2;
            // 
            // SourceServerTextBox
            // 
            this.SourceServerTextBox.Location = new System.Drawing.Point(69, 29);
            this.SourceServerTextBox.Name = "SourceServerTextBox";
            this.SourceServerTextBox.Size = new System.Drawing.Size(383, 20);
            this.SourceServerTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(3, 110);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswordLabel.TabIndex = 14;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(4, 84);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(55, 13);
            this.UsernameLabel.TabIndex = 13;
            this.UsernameLabel.Text = "Usename:";
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.AutoSize = true;
            this.DatabaseLabel.Location = new System.Drawing.Point(3, 58);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(56, 13);
            this.DatabaseLabel.TabIndex = 12;
            this.DatabaseLabel.Text = "Database:";
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(18, 33);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(41, 13);
            this.ServerLabel.TabIndex = 11;
            this.ServerLabel.Text = "Server:";
            // 
            // NewOrderTabPage
            // 
            this.NewOrderTabPage.BackColor = System.Drawing.Color.Transparent;
            this.NewOrderTabPage.Controls.Add(this.NoOfOrdersLabel);
            this.NewOrderTabPage.Controls.Add(this.LoadOrderFromStagingGroupBox);
            this.NewOrderTabPage.Controls.Add(this.OSSOrdersGroupBox);
            this.NewOrderTabPage.Controls.Add(this.SyncOrdersWithTHubGroupBox);
            this.NewOrderTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewOrderTabPage.Location = new System.Drawing.Point(4, 22);
            this.NewOrderTabPage.Name = "NewOrderTabPage";
            this.NewOrderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NewOrderTabPage.Size = new System.Drawing.Size(1226, 610);
            this.NewOrderTabPage.TabIndex = 1;
            this.NewOrderTabPage.Text = "New";
            // 
            // NoOfOrdersLabel
            // 
            this.NoOfOrdersLabel.AutoSize = true;
            this.NoOfOrdersLabel.Location = new System.Drawing.Point(457, 29);
            this.NoOfOrdersLabel.Name = "NoOfOrdersLabel";
            this.NoOfOrdersLabel.Size = new System.Drawing.Size(115, 15);
            this.NoOfOrdersLabel.TabIndex = 1;
            this.NoOfOrdersLabel.Text = "Total No. of Orders: ";
            // 
            // LoadOrderFromStagingGroupBox
            // 
            this.LoadOrderFromStagingGroupBox.Controls.Add(this.DisplayStagingOrderButton);
            this.LoadOrderFromStagingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadOrderFromStagingGroupBox.Location = new System.Drawing.Point(227, 6);
            this.LoadOrderFromStagingGroupBox.Name = "LoadOrderFromStagingGroupBox";
            this.LoadOrderFromStagingGroupBox.Size = new System.Drawing.Size(215, 55);
            this.LoadOrderFromStagingGroupBox.TabIndex = 7;
            this.LoadOrderFromStagingGroupBox.TabStop = false;
            this.LoadOrderFromStagingGroupBox.Text = "Load Order from Staging";
            // 
            // DisplayStagingOrderButton
            // 
            this.DisplayStagingOrderButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.DisplayStagingOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayStagingOrderButton.ForeColor = System.Drawing.Color.Transparent;
            this.DisplayStagingOrderButton.Location = new System.Drawing.Point(6, 18);
            this.DisplayStagingOrderButton.Name = "DisplayStagingOrderButton";
            this.DisplayStagingOrderButton.Size = new System.Drawing.Size(203, 27);
            this.DisplayStagingOrderButton.TabIndex = 0;
            this.DisplayStagingOrderButton.Text = "Display Staging Orders ";
            this.DisplayStagingOrderButton.UseVisualStyleBackColor = false;
            this.DisplayStagingOrderButton.Click += new System.EventHandler(this.LoadOrderFromStagingButton_Click);
            // 
            // OSSOrdersGroupBox
            // 
            this.OSSOrdersGroupBox.Controls.Add(this.OssOrdersDataGridView);
            this.OSSOrdersGroupBox.Location = new System.Drawing.Point(6, 67);
            this.OSSOrdersGroupBox.Name = "OSSOrdersGroupBox";
            this.OSSOrdersGroupBox.Size = new System.Drawing.Size(1208, 537);
            this.OSSOrdersGroupBox.TabIndex = 7;
            this.OSSOrdersGroupBox.TabStop = false;
            this.OSSOrdersGroupBox.Text = "New Orders";
            // 
            // OssOrdersDataGridView
            // 
            this.OssOrdersDataGridView.AllowUserToAddRows = false;
            this.OssOrdersDataGridView.AllowUserToDeleteRows = false;
            this.OssOrdersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OssOrdersDataGridView.BackgroundColor = System.Drawing.Color.Khaki;
            this.OssOrdersDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.OssOrdersDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.OssOrdersDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OssOrdersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.OssOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OssOrdersDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.OssOrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OssOrdersDataGridView.GridColor = System.Drawing.Color.Black;
            this.OssOrdersDataGridView.Location = new System.Drawing.Point(3, 17);
            this.OssOrdersDataGridView.MultiSelect = false;
            this.OssOrdersDataGridView.Name = "OssOrdersDataGridView";
            this.OssOrdersDataGridView.RowHeadersVisible = false;
            this.OssOrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.OssOrdersDataGridView.Size = new System.Drawing.Size(1202, 517);
            this.OssOrdersDataGridView.TabIndex = 0;
            this.OssOrdersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OssOrdersDataGridView_CellContentClick_1);
            this.OssOrdersDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OssOrdersDataGridView_DataBindingComplete_1);
            // 
            // SyncOrdersWithTHubGroupBox
            // 
            this.SyncOrdersWithTHubGroupBox.Controls.Add(this.LoadOrdersFromTHubButton);
            this.SyncOrdersWithTHubGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncOrdersWithTHubGroupBox.Location = new System.Drawing.Point(6, 6);
            this.SyncOrdersWithTHubGroupBox.Name = "SyncOrdersWithTHubGroupBox";
            this.SyncOrdersWithTHubGroupBox.Size = new System.Drawing.Size(215, 55);
            this.SyncOrdersWithTHubGroupBox.TabIndex = 6;
            this.SyncOrdersWithTHubGroupBox.TabStop = false;
            this.SyncOrdersWithTHubGroupBox.Text = "Syncronize Orders with T-Hub";
            // 
            // LoadOrdersFromTHubButton
            // 
            this.LoadOrdersFromTHubButton.BackColor = System.Drawing.Color.IndianRed;
            this.LoadOrdersFromTHubButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadOrdersFromTHubButton.ForeColor = System.Drawing.Color.Transparent;
            this.LoadOrdersFromTHubButton.Location = new System.Drawing.Point(6, 18);
            this.LoadOrdersFromTHubButton.Name = "LoadOrdersFromTHubButton";
            this.LoadOrdersFromTHubButton.Size = new System.Drawing.Size(203, 27);
            this.LoadOrdersFromTHubButton.TabIndex = 0;
            this.LoadOrdersFromTHubButton.Text = "Load Orders From T-Hub";
            this.LoadOrdersFromTHubButton.UseVisualStyleBackColor = false;
            this.LoadOrdersFromTHubButton.Click += new System.EventHandler(this.SynchronizeOrdersFromTHubButton_Click);
            // 
            // InFight
            // 
            this.InFight.Controls.Add(this.InFlightOrdersLabel);
            this.InFight.Controls.Add(this.groupBox3);
            this.InFight.Location = new System.Drawing.Point(4, 22);
            this.InFight.Name = "InFight";
            this.InFight.Size = new System.Drawing.Size(1226, 610);
            this.InFight.TabIndex = 4;
            this.InFight.Text = "InFlight";
            this.InFight.UseVisualStyleBackColor = true;
            // 
            // InFlightOrdersLabel
            // 
            this.InFlightOrdersLabel.AutoSize = true;
            this.InFlightOrdersLabel.Location = new System.Drawing.Point(9, 586);
            this.InFlightOrdersLabel.Name = "InFlightOrdersLabel";
            this.InFlightOrdersLabel.Size = new System.Drawing.Size(100, 13);
            this.InFlightOrdersLabel.TabIndex = 2;
            this.InFlightOrdersLabel.Text = "Total No. of Orders:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OssInFlightGridView);
            this.groupBox3.Location = new System.Drawing.Point(9, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1205, 580);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "In-Flight Orders";
            // 
            // OssInFlightGridView
            // 
            this.OssInFlightGridView.AllowUserToAddRows = false;
            this.OssInFlightGridView.AllowUserToDeleteRows = false;
            this.OssInFlightGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OssInFlightGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.OssInFlightGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.OssInFlightGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.OssInFlightGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.OssInFlightGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OssInFlightGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OssInFlightGridView.Location = new System.Drawing.Point(3, 16);
            this.OssInFlightGridView.MultiSelect = false;
            this.OssInFlightGridView.Name = "OssInFlightGridView";
            this.OssInFlightGridView.RowHeadersVisible = false;
            this.OssInFlightGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.OssInFlightGridView.Size = new System.Drawing.Size(1199, 561);
            this.OssInFlightGridView.TabIndex = 0;
            this.OssInFlightGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OssInFlightGridView_CellClick);
            this.OssInFlightGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OssInFlightGridView_DataBindingComplete);
            // 
            // Exception
            // 
            this.Exception.Controls.Add(this.ExceptionOrdersLabel);
            this.Exception.Controls.Add(this.groupBox1);
            this.Exception.Location = new System.Drawing.Point(4, 22);
            this.Exception.Name = "Exception";
            this.Exception.Size = new System.Drawing.Size(1226, 610);
            this.Exception.TabIndex = 2;
            this.Exception.Text = "Exception";
            this.Exception.UseVisualStyleBackColor = true;
            // 
            // ExceptionOrdersLabel
            // 
            this.ExceptionOrdersLabel.AutoSize = true;
            this.ExceptionOrdersLabel.Location = new System.Drawing.Point(8, 586);
            this.ExceptionOrdersLabel.Name = "ExceptionOrdersLabel";
            this.ExceptionOrdersLabel.Size = new System.Drawing.Size(100, 13);
            this.ExceptionOrdersLabel.TabIndex = 1;
            this.ExceptionOrdersLabel.Text = "Total No. of Orders:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OssExceptionGridView);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1206, 580);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orders with Exceptions";
            // 
            // OssExceptionGridView
            // 
            this.OssExceptionGridView.AllowUserToAddRows = false;
            this.OssExceptionGridView.AllowUserToDeleteRows = false;
            this.OssExceptionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OssExceptionGridView.BackgroundColor = System.Drawing.Color.Wheat;
            this.OssExceptionGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.OssExceptionGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.OssExceptionGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.OssExceptionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OssExceptionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OssExceptionGridView.Location = new System.Drawing.Point(3, 16);
            this.OssExceptionGridView.MultiSelect = false;
            this.OssExceptionGridView.Name = "OssExceptionGridView";
            this.OssExceptionGridView.ReadOnly = true;
            this.OssExceptionGridView.RowHeadersVisible = false;
            this.OssExceptionGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.OssExceptionGridView.Size = new System.Drawing.Size(1200, 561);
            this.OssExceptionGridView.TabIndex = 0;
            this.OssExceptionGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OssExceptionGridView_CellContentClick);
            this.OssExceptionGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OssExceptionGridView_DataBindingComplete);
            // 
            // Completed
            // 
            this.Completed.Controls.Add(this.CompletedOrdersLabel);
            this.Completed.Controls.Add(this.groupBox2);
            this.Completed.Location = new System.Drawing.Point(4, 22);
            this.Completed.Name = "Completed";
            this.Completed.Size = new System.Drawing.Size(1226, 610);
            this.Completed.TabIndex = 3;
            this.Completed.Text = "Completed";
            this.Completed.UseVisualStyleBackColor = true;
            // 
            // CompletedOrdersLabel
            // 
            this.CompletedOrdersLabel.AutoSize = true;
            this.CompletedOrdersLabel.Location = new System.Drawing.Point(9, 588);
            this.CompletedOrdersLabel.Name = "CompletedOrdersLabel";
            this.CompletedOrdersLabel.Size = new System.Drawing.Size(100, 13);
            this.CompletedOrdersLabel.TabIndex = 2;
            this.CompletedOrdersLabel.Text = "Total No. of Orders:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OssCompletedGridView);
            this.groupBox2.Location = new System.Drawing.Point(9, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1205, 582);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Completed Orders";
            // 
            // OssCompletedGridView
            // 
            this.OssCompletedGridView.AllowUserToAddRows = false;
            this.OssCompletedGridView.AllowUserToDeleteRows = false;
            this.OssCompletedGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OssCompletedGridView.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.OssCompletedGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.OssCompletedGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.OssCompletedGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.OssCompletedGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OssCompletedGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OssCompletedGridView.Location = new System.Drawing.Point(3, 16);
            this.OssCompletedGridView.MultiSelect = false;
            this.OssCompletedGridView.Name = "OssCompletedGridView";
            this.OssCompletedGridView.ReadOnly = true;
            this.OssCompletedGridView.RowHeadersVisible = false;
            this.OssCompletedGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.OssCompletedGridView.Size = new System.Drawing.Size(1199, 563);
            this.OssCompletedGridView.TabIndex = 0;
            this.OssCompletedGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OssCompletedGridView_DataBindingComplete);
            // 
            // OnHold
            // 
            this.OnHold.Controls.Add(this.OnHoldOrdersLabel);
            this.OnHold.Controls.Add(this.OnHoldGroupBox);
            this.OnHold.Location = new System.Drawing.Point(4, 22);
            this.OnHold.Name = "OnHold";
            this.OnHold.Size = new System.Drawing.Size(1226, 610);
            this.OnHold.TabIndex = 5;
            this.OnHold.Text = "On-Hold";
            this.OnHold.UseVisualStyleBackColor = true;
            // 
            // OnHoldOrdersLabel
            // 
            this.OnHoldOrdersLabel.AutoSize = true;
            this.OnHoldOrdersLabel.Location = new System.Drawing.Point(9, 590);
            this.OnHoldOrdersLabel.Name = "OnHoldOrdersLabel";
            this.OnHoldOrdersLabel.Size = new System.Drawing.Size(94, 13);
            this.OnHoldOrdersLabel.TabIndex = 2;
            this.OnHoldOrdersLabel.Text = "Total No. of Ordes";
            // 
            // OnHoldGroupBox
            // 
            this.OnHoldGroupBox.Controls.Add(this.OSSOrderOnHoldGridView);
            this.OnHoldGroupBox.Location = new System.Drawing.Point(9, 3);
            this.OnHoldGroupBox.Name = "OnHoldGroupBox";
            this.OnHoldGroupBox.Size = new System.Drawing.Size(1205, 584);
            this.OnHoldGroupBox.TabIndex = 1;
            this.OnHoldGroupBox.TabStop = false;
            this.OnHoldGroupBox.Text = "On-Hold Orders";
            // 
            // OSSOrderOnHoldGridView
            // 
            this.OSSOrderOnHoldGridView.AllowUserToAddRows = false;
            this.OSSOrderOnHoldGridView.AllowUserToDeleteRows = false;
            this.OSSOrderOnHoldGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OSSOrderOnHoldGridView.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.OSSOrderOnHoldGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.OSSOrderOnHoldGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.OSSOrderOnHoldGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.OSSOrderOnHoldGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OSSOrderOnHoldGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OSSOrderOnHoldGridView.Location = new System.Drawing.Point(3, 16);
            this.OSSOrderOnHoldGridView.MultiSelect = false;
            this.OSSOrderOnHoldGridView.Name = "OSSOrderOnHoldGridView";
            this.OSSOrderOnHoldGridView.ReadOnly = true;
            this.OSSOrderOnHoldGridView.RowHeadersVisible = false;
            this.OSSOrderOnHoldGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.OSSOrderOnHoldGridView.Size = new System.Drawing.Size(1199, 565);
            this.OSSOrderOnHoldGridView.TabIndex = 0;
            this.OSSOrderOnHoldGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OSSOrderOnHoldGridView_DataBindingComplete);
            // 
            // Canceled
            // 
            this.Canceled.Controls.Add(this.CancelOrdersLabel);
            this.Canceled.Controls.Add(this.groupBox5);
            this.Canceled.Location = new System.Drawing.Point(4, 22);
            this.Canceled.Name = "Canceled";
            this.Canceled.Size = new System.Drawing.Size(1226, 610);
            this.Canceled.TabIndex = 6;
            this.Canceled.Text = "Canceled";
            this.Canceled.UseVisualStyleBackColor = true;
            // 
            // CancelOrdersLabel
            // 
            this.CancelOrdersLabel.AutoSize = true;
            this.CancelOrdersLabel.Location = new System.Drawing.Point(9, 588);
            this.CancelOrdersLabel.Name = "CancelOrdersLabel";
            this.CancelOrdersLabel.Size = new System.Drawing.Size(100, 13);
            this.CancelOrdersLabel.TabIndex = 2;
            this.CancelOrdersLabel.Text = "Total No. of Orders:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.OssOrdersCanceledOrders);
            this.groupBox5.Location = new System.Drawing.Point(9, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1205, 582);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Canceled Orders";
            // 
            // OssOrdersCanceledOrders
            // 
            this.OssOrdersCanceledOrders.AllowUserToAddRows = false;
            this.OssOrdersCanceledOrders.AllowUserToDeleteRows = false;
            this.OssOrdersCanceledOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OssOrdersCanceledOrders.BackgroundColor = System.Drawing.Color.Pink;
            this.OssOrdersCanceledOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.OssOrdersCanceledOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.OssOrdersCanceledOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OssOrdersCanceledOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OssOrdersCanceledOrders.Location = new System.Drawing.Point(3, 16);
            this.OssOrdersCanceledOrders.MultiSelect = false;
            this.OssOrdersCanceledOrders.Name = "OssOrdersCanceledOrders";
            this.OssOrdersCanceledOrders.ReadOnly = true;
            this.OssOrdersCanceledOrders.RowHeadersVisible = false;
            this.OssOrdersCanceledOrders.Size = new System.Drawing.Size(1199, 563);
            this.OssOrdersCanceledOrders.TabIndex = 0;
            this.OssOrdersCanceledOrders.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OssOrdersCanceledOrders_DataBindingComplete);
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.FormErrorProvider.ContainerControl = this;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Order Synchronization System.";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(93, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem1.Text = "Exit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatus.Text = "Ready";
            // 
            // ToolStripButton
            // 
            this.ToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripButton.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.loading1;
            this.ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton.Name = "ToolStripButton";
            this.ToolStripButton.Size = new System.Drawing.Size(32, 20);
            this.ToolStripButton.Text = "Refresh";
            this.ToolStripButton.ButtonClick += new System.EventHandler(this.ToolStripButton_ButtonClick);
            // 
            // ApplicationStatusStrip
            // 
            this.ApplicationStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus,
            this.ToolStripButton});
            this.ApplicationStatusStrip.Location = new System.Drawing.Point(0, 660);
            this.ApplicationStatusStrip.Name = "ApplicationStatusStrip";
            this.ApplicationStatusStrip.Size = new System.Drawing.Size(1234, 22);
            this.ApplicationStatusStrip.TabIndex = 50;
            this.ApplicationStatusStrip.Text = "Application Status Strip";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 682);
            this.Controls.Add(this.MainFormTabControl);
            this.Controls.Add(this.ApplicationStatusStrip);
            this.Controls.Add(this.ApplicationMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ApplicationMenuStrip;
            this.MinimumSize = new System.Drawing.Size(1250, 720);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSS  (Order Synchronization System)";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.ApplicationMenuStrip.ResumeLayout(false);
            this.ApplicationMenuStrip.PerformLayout();
            this.MainFormTabControl.ResumeLayout(false);
            this.ConfigurationTabPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.MoldingBoxApiKeyGroupBox.ResumeLayout(false);
            this.MoldingBoxApiKeyGroupBox.PerformLayout();
            this.AutomaticOrderSynchronizeSettingsGroupBox.ResumeLayout(false);
            this.AutomaticOrderSynchronizeSettingsGroupBox.PerformLayout();
            this.StagingDbGroupBox.ResumeLayout(false);
            this.StagingDbGroupBox.PerformLayout();
            this.SourceGroupBox.ResumeLayout(false);
            this.SourceGroupBox.PerformLayout();
            this.NewOrderTabPage.ResumeLayout(false);
            this.NewOrderTabPage.PerformLayout();
            this.LoadOrderFromStagingGroupBox.ResumeLayout(false);
            this.OSSOrdersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OssOrdersDataGridView)).EndInit();
            this.SyncOrdersWithTHubGroupBox.ResumeLayout(false);
            this.InFight.ResumeLayout(false);
            this.InFight.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OssInFlightGridView)).EndInit();
            this.Exception.ResumeLayout(false);
            this.Exception.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OssExceptionGridView)).EndInit();
            this.Completed.ResumeLayout(false);
            this.Completed.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OssCompletedGridView)).EndInit();
            this.OnHold.ResumeLayout(false);
            this.OnHold.PerformLayout();
            this.OnHoldGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OSSOrderOnHoldGridView)).EndInit();
            this.Canceled.ResumeLayout(false);
            this.Canceled.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OssOrdersCanceledOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.ApplicationStatusStrip.ResumeLayout(false);
            this.ApplicationStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ApplicationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.TabControl MainFormTabControl;
        private System.Windows.Forms.TabPage ConfigurationTabPage;
        private System.Windows.Forms.GroupBox StagingDbGroupBox;
        private System.Windows.Forms.GroupBox SourceGroupBox;
        private System.Windows.Forms.TabPage NewOrderTabPage;
        private System.Windows.Forms.Button SaveSourceButon;
        private System.Windows.Forms.TextBox SourcePasswordTextBox;
        private System.Windows.Forms.TextBox SourceUsernameTextBox;
        private System.Windows.Forms.TextBox SourceDatabaseTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.TabPage Exception;
        private System.Windows.Forms.GroupBox AutomaticOrderSynchronizeSettingsGroupBox;
        private System.Windows.Forms.Label SynchronizeIntervalMinutesLabel;
        private System.Windows.Forms.Label SynchronizeIntervalLabel;
        private System.Windows.Forms.Button SynchronizeButton;
        private System.Windows.Forms.TextBox StagingServerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveStagingButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StagingDatabaseTextBox;
        private System.Windows.Forms.TextBox StagingPasswordTextBox;
        private System.Windows.Forms.TextBox StagingUsernameTextBox;
        private System.Windows.Forms.Button CancelStagingButton;
        private System.Windows.Forms.Button CancelSourceButton;
        private System.Windows.Forms.TextBox SourceServerTextBox;
        private System.Windows.Forms.ErrorProvider FormErrorProvider;
        private System.Windows.Forms.MaskedTextBox SyncNewOrderTextbox;
        private System.Windows.Forms.GroupBox SyncOrdersWithTHubGroupBox;
        private System.Windows.Forms.Button LoadOrdersFromTHubButton;
        private System.Windows.Forms.GroupBox OSSOrdersGroupBox;
        private System.Windows.Forms.DataGridView OssOrdersDataGridView;
        private System.Windows.Forms.GroupBox LoadOrderFromStagingGroupBox;
        private System.Windows.Forms.Button DisplayStagingOrderButton;
        private System.Windows.Forms.Label NoOfOrdersLabel;
        private System.Windows.Forms.GroupBox MoldingBoxApiKeyGroupBox;
        private System.Windows.Forms.TextBox MoldinboxKeyTextBox;
        private System.Windows.Forms.Label MoldingBoxApiKeyLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView OssExceptionGridView;
        private System.Windows.Forms.TabPage Completed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView OssCompletedGridView;
        private System.Windows.Forms.TabPage InFight;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView OssInFlightGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox PhoneTextbox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TabPage OnHold;
        private System.Windows.Forms.GroupBox OnHoldGroupBox;
        private System.Windows.Forms.DataGridView OSSOrderOnHoldGridView;
        private System.Windows.Forms.TabPage Canceled;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView OssOrdersCanceledOrders;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.StatusStrip ApplicationStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripSplitButton ToolStripButton;
        private System.Windows.Forms.Label OnHoldOrdersLabel;
        private System.Windows.Forms.Label CancelOrdersLabel;
        private System.Windows.Forms.Label CompletedOrdersLabel;
        private System.Windows.Forms.Label ExceptionOrdersLabel;
        private System.Windows.Forms.Label InFlightOrdersLabel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipmentMappingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideWhenMinimizedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewSystemLogsToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox SyncMoldingBoxIntervalTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

