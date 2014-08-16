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
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormTabControl = new System.Windows.Forms.TabControl();
            this.ConfigurationTabPage = new System.Windows.Forms.TabPage();
            this.AutomaticOrderSynchronizeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SynchronizeIntervalMinutesLabel = new System.Windows.Forms.Label();
            this.SynchronizeIntervalLabel = new System.Windows.Forms.Label();
            this.SynchronizeButton = new System.Windows.Forms.Button();
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
            this.OSSOrderTabPage = new System.Windows.Forms.TabPage();
            this.LoadOrderFromStagingGroupBox = new System.Windows.Forms.GroupBox();
            this.LoadOrderFromStagingButton = new System.Windows.Forms.Button();
            this.OSSOrdersGroupBox = new System.Windows.Forms.GroupBox();
            this.OssOrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.SyncOrdersWithTHubGroupBox = new System.Windows.Forms.GroupBox();
            this.SynchronizeOrdersFromTHubButton = new System.Windows.Forms.Button();
            this.ManualSendToMoldingBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.SendToMoldingBoxButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.FormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ApplicationStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ApplicationMenuStrip.SuspendLayout();
            this.MainFormTabControl.SuspendLayout();
            this.ConfigurationTabPage.SuspendLayout();
            this.AutomaticOrderSynchronizeSettingsGroupBox.SuspendLayout();
            this.StagingDbGroupBox.SuspendLayout();
            this.SourceGroupBox.SuspendLayout();
            this.OSSOrderTabPage.SuspendLayout();
            this.LoadOrderFromStagingGroupBox.SuspendLayout();
            this.OSSOrdersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OssOrdersDataGridView)).BeginInit();
            this.SyncOrdersWithTHubGroupBox.SuspendLayout();
            this.ManualSendToMoldingBoxGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).BeginInit();
            this.ApplicationStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplicationMenuStrip
            // 
            this.ApplicationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.ApplicationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ApplicationMenuStrip.Name = "ApplicationMenuStrip";
            this.ApplicationMenuStrip.Size = new System.Drawing.Size(958, 24);
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
            this.MainFormTabControl.Controls.Add(this.OSSOrderTabPage);
            this.MainFormTabControl.Controls.Add(this.tabPage1);
            this.MainFormTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormTabControl.Location = new System.Drawing.Point(0, 24);
            this.MainFormTabControl.Name = "MainFormTabControl";
            this.MainFormTabControl.SelectedIndex = 0;
            this.MainFormTabControl.Size = new System.Drawing.Size(958, 584);
            this.MainFormTabControl.TabIndex = 5;
            // 
            // ConfigurationTabPage
            // 
            this.ConfigurationTabPage.BackColor = System.Drawing.Color.Transparent;
            this.ConfigurationTabPage.Controls.Add(this.AutomaticOrderSynchronizeSettingsGroupBox);
            this.ConfigurationTabPage.Controls.Add(this.StagingDbGroupBox);
            this.ConfigurationTabPage.Controls.Add(this.SourceGroupBox);
            this.ConfigurationTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfigurationTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConfigurationTabPage.Name = "ConfigurationTabPage";
            this.ConfigurationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigurationTabPage.Size = new System.Drawing.Size(950, 558);
            this.ConfigurationTabPage.TabIndex = 0;
            this.ConfigurationTabPage.Text = "Configuration";
            // 
            // AutomaticOrderSynchronizeSettingsGroupBox
            // 
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.maskedTextBox1);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeIntervalMinutesLabel);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeIntervalLabel);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeButton);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutomaticOrderSynchronizeSettingsGroupBox.Location = new System.Drawing.Point(4, 178);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Name = "AutomaticOrderSynchronizeSettingsGroupBox";
            this.AutomaticOrderSynchronizeSettingsGroupBox.Size = new System.Drawing.Size(462, 55);
            this.AutomaticOrderSynchronizeSettingsGroupBox.TabIndex = 3;
            this.AutomaticOrderSynchronizeSettingsGroupBox.TabStop = false;
            this.AutomaticOrderSynchronizeSettingsGroupBox.Text = "Automatic Order Synchronize Settings";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(167, 21);
            this.maskedTextBox1.Mask = "000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBox1.TabIndex = 13;
            // 
            // SynchronizeIntervalMinutesLabel
            // 
            this.SynchronizeIntervalMinutesLabel.AutoSize = true;
            this.SynchronizeIntervalMinutesLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.SynchronizeIntervalMinutesLabel.Location = new System.Drawing.Point(119, 25);
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
            this.SynchronizeIntervalLabel.Size = new System.Drawing.Size(106, 13);
            this.SynchronizeIntervalLabel.TabIndex = 1;
            this.SynchronizeIntervalLabel.Text = "Synchronize Interval:";
            // 
            // SynchronizeButton
            // 
            this.SynchronizeButton.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.PlayImage;
            this.SynchronizeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SynchronizeButton.Location = new System.Drawing.Point(346, 16);
            this.SynchronizeButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.SynchronizeButton.Name = "SynchronizeButton";
            this.SynchronizeButton.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.SynchronizeButton.Size = new System.Drawing.Size(110, 30);
            this.SynchronizeButton.TabIndex = 14;
            this.SynchronizeButton.Text = "Start";
            this.SynchronizeButton.UseVisualStyleBackColor = true;
            this.SynchronizeButton.Click += new System.EventHandler(this.SynchronizeButton_Click);
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
            this.StagingDbGroupBox.Location = new System.Drawing.Point(472, 6);
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
            // OSSOrderTabPage
            // 
            this.OSSOrderTabPage.BackColor = System.Drawing.Color.Transparent;
            this.OSSOrderTabPage.Controls.Add(this.LoadOrderFromStagingGroupBox);
            this.OSSOrderTabPage.Controls.Add(this.OSSOrdersGroupBox);
            this.OSSOrderTabPage.Controls.Add(this.SyncOrdersWithTHubGroupBox);
            this.OSSOrderTabPage.Controls.Add(this.ManualSendToMoldingBoxGroupBox);
            this.OSSOrderTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSSOrderTabPage.Location = new System.Drawing.Point(4, 22);
            this.OSSOrderTabPage.Name = "OSSOrderTabPage";
            this.OSSOrderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OSSOrderTabPage.Size = new System.Drawing.Size(950, 558);
            this.OSSOrderTabPage.TabIndex = 1;
            this.OSSOrderTabPage.Text = "T-Hub Orders";
            // 
            // LoadOrderFromStagingGroupBox
            // 
            this.LoadOrderFromStagingGroupBox.Controls.Add(this.LoadOrderFromStagingButton);
            this.LoadOrderFromStagingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadOrderFromStagingGroupBox.Location = new System.Drawing.Point(227, 6);
            this.LoadOrderFromStagingGroupBox.Name = "LoadOrderFromStagingGroupBox";
            this.LoadOrderFromStagingGroupBox.Size = new System.Drawing.Size(215, 55);
            this.LoadOrderFromStagingGroupBox.TabIndex = 7;
            this.LoadOrderFromStagingGroupBox.TabStop = false;
            this.LoadOrderFromStagingGroupBox.Text = "Load Order from Staging";
            // 
            // LoadOrderFromStagingButton
            // 
            this.LoadOrderFromStagingButton.BackColor = System.Drawing.Color.DarkKhaki;
            this.LoadOrderFromStagingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadOrderFromStagingButton.ForeColor = System.Drawing.Color.Transparent;
            this.LoadOrderFromStagingButton.Location = new System.Drawing.Point(6, 18);
            this.LoadOrderFromStagingButton.Name = "LoadOrderFromStagingButton";
            this.LoadOrderFromStagingButton.Size = new System.Drawing.Size(203, 27);
            this.LoadOrderFromStagingButton.TabIndex = 0;
            this.LoadOrderFromStagingButton.Text = "Load Orders from Staging";
            this.LoadOrderFromStagingButton.UseVisualStyleBackColor = false;
            this.LoadOrderFromStagingButton.Click += new System.EventHandler(this.LoadOrderFromStagingButton_Click);
            // 
            // OSSOrdersGroupBox
            // 
            this.OSSOrdersGroupBox.Controls.Add(this.OssOrdersDataGridView);
            this.OSSOrdersGroupBox.Location = new System.Drawing.Point(6, 67);
            this.OSSOrdersGroupBox.Name = "OSSOrdersGroupBox";
            this.OSSOrdersGroupBox.Size = new System.Drawing.Size(938, 488);
            this.OSSOrdersGroupBox.TabIndex = 7;
            this.OSSOrdersGroupBox.TabStop = false;
            this.OSSOrdersGroupBox.Text = "Orders";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OssOrdersDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.OssOrdersDataGridView.GridColor = System.Drawing.Color.Black;
            this.OssOrdersDataGridView.Location = new System.Drawing.Point(6, 20);
            this.OssOrdersDataGridView.MultiSelect = false;
            this.OssOrdersDataGridView.Name = "OssOrdersDataGridView";
            this.OssOrdersDataGridView.RowHeadersVisible = false;
            this.OssOrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.OssOrdersDataGridView.Size = new System.Drawing.Size(926, 462);
            this.OssOrdersDataGridView.TabIndex = 0;
            this.OssOrdersDataGridView.CellContentClick += OssOrdersDataGridView_CellContentClick;
            // 
            // SyncOrdersWithTHubGroupBox
            // 
            this.SyncOrdersWithTHubGroupBox.Controls.Add(this.SynchronizeOrdersFromTHubButton);
            this.SyncOrdersWithTHubGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncOrdersWithTHubGroupBox.Location = new System.Drawing.Point(6, 6);
            this.SyncOrdersWithTHubGroupBox.Name = "SyncOrdersWithTHubGroupBox";
            this.SyncOrdersWithTHubGroupBox.Size = new System.Drawing.Size(215, 55);
            this.SyncOrdersWithTHubGroupBox.TabIndex = 6;
            this.SyncOrdersWithTHubGroupBox.TabStop = false;
            this.SyncOrdersWithTHubGroupBox.Text = "Syncronize Orders with T-Hub";
            // 
            // SynchronizeOrdersFromTHubButton
            // 
            this.SynchronizeOrdersFromTHubButton.BackColor = System.Drawing.Color.IndianRed;
            this.SynchronizeOrdersFromTHubButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SynchronizeOrdersFromTHubButton.ForeColor = System.Drawing.Color.Transparent;
            this.SynchronizeOrdersFromTHubButton.Location = new System.Drawing.Point(6, 18);
            this.SynchronizeOrdersFromTHubButton.Name = "SynchronizeOrdersFromTHubButton";
            this.SynchronizeOrdersFromTHubButton.Size = new System.Drawing.Size(203, 27);
            this.SynchronizeOrdersFromTHubButton.TabIndex = 0;
            this.SynchronizeOrdersFromTHubButton.Text = "Synchronize Orders with T-Hub";
            this.SynchronizeOrdersFromTHubButton.UseVisualStyleBackColor = false;
            this.SynchronizeOrdersFromTHubButton.Click += new System.EventHandler(this.SynchronizeOrdersFromTHubButton_Click);
            // 
            // ManualSendToMoldingBoxGroupBox
            // 
            this.ManualSendToMoldingBoxGroupBox.Controls.Add(this.SendToMoldingBoxButton);
            this.ManualSendToMoldingBoxGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManualSendToMoldingBoxGroupBox.Location = new System.Drawing.Point(481, 6);
            this.ManualSendToMoldingBoxGroupBox.Name = "ManualSendToMoldingBoxGroupBox";
            this.ManualSendToMoldingBoxGroupBox.Size = new System.Drawing.Size(463, 55);
            this.ManualSendToMoldingBoxGroupBox.TabIndex = 5;
            this.ManualSendToMoldingBoxGroupBox.TabStop = false;
            this.ManualSendToMoldingBoxGroupBox.Text = "Manual Send to MoldingBox";
            // 
            // SendToMoldingBoxButton
            // 
            this.SendToMoldingBoxButton.BackColor = System.Drawing.Color.DarkOrange;
            this.SendToMoldingBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToMoldingBoxButton.ForeColor = System.Drawing.Color.Transparent;
            this.SendToMoldingBoxButton.Location = new System.Drawing.Point(6, 18);
            this.SendToMoldingBoxButton.Name = "SendToMoldingBoxButton";
            this.SendToMoldingBoxButton.Size = new System.Drawing.Size(451, 27);
            this.SendToMoldingBoxButton.TabIndex = 0;
            this.SendToMoldingBoxButton.Text = "Send All Orders To MoldingBox";
            this.SendToMoldingBoxButton.UseVisualStyleBackColor = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(950, 558);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FormErrorProvider
            // 
            this.FormErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.FormErrorProvider.ContainerControl = this;
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatus.Text = "Ready";
            // 
            // ApplicationStatusStrip
            // 
            this.ApplicationStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.ApplicationStatusStrip.Location = new System.Drawing.Point(0, 608);
            this.ApplicationStatusStrip.Name = "ApplicationStatusStrip";
            this.ApplicationStatusStrip.Size = new System.Drawing.Size(958, 22);
            this.ApplicationStatusStrip.TabIndex = 50;
            this.ApplicationStatusStrip.Text = "Application Status Strip";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 630);
            this.Controls.Add(this.MainFormTabControl);
            this.Controls.Add(this.ApplicationStatusStrip);
            this.Controls.Add(this.ApplicationMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ApplicationMenuStrip;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSS  (Order Synchronization System)";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ApplicationMenuStrip.ResumeLayout(false);
            this.ApplicationMenuStrip.PerformLayout();
            this.MainFormTabControl.ResumeLayout(false);
            this.ConfigurationTabPage.ResumeLayout(false);
            this.AutomaticOrderSynchronizeSettingsGroupBox.ResumeLayout(false);
            this.AutomaticOrderSynchronizeSettingsGroupBox.PerformLayout();
            this.StagingDbGroupBox.ResumeLayout(false);
            this.StagingDbGroupBox.PerformLayout();
            this.SourceGroupBox.ResumeLayout(false);
            this.SourceGroupBox.PerformLayout();
            this.OSSOrderTabPage.ResumeLayout(false);
            this.LoadOrderFromStagingGroupBox.ResumeLayout(false);
            this.OSSOrdersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OssOrdersDataGridView)).EndInit();
            this.SyncOrdersWithTHubGroupBox.ResumeLayout(false);
            this.ManualSendToMoldingBoxGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormErrorProvider)).EndInit();
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
        private System.Windows.Forms.TabPage OSSOrderTabPage;
        private System.Windows.Forms.Button SaveSourceButon;
        private System.Windows.Forms.TextBox SourcePasswordTextBox;
        private System.Windows.Forms.TextBox SourceUsernameTextBox;
        private System.Windows.Forms.TextBox SourceDatabaseTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.TabPage tabPage1;
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
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        public System.Windows.Forms.StatusStrip ApplicationStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.GroupBox ManualSendToMoldingBoxGroupBox;
        private System.Windows.Forms.Button SendToMoldingBoxButton;
        private System.Windows.Forms.GroupBox SyncOrdersWithTHubGroupBox;
        private System.Windows.Forms.Button SynchronizeOrdersFromTHubButton;
        private System.Windows.Forms.GroupBox OSSOrdersGroupBox;
        private System.Windows.Forms.DataGridView OssOrdersDataGridView;
        private System.Windows.Forms.GroupBox LoadOrderFromStagingGroupBox;
        private System.Windows.Forms.Button LoadOrderFromStagingButton;
    }
}

