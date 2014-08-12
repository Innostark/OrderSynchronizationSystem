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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ApplicationMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Configuration = new System.Windows.Forms.TabPage();
            this.ManualOrderSynchronizeStartGroupBox = new System.Windows.Forms.GroupBox();
            this.SendToMoldingBoxButton = new System.Windows.Forms.Button();
            this.AutomaticOrderSynchronizeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SynchronizeIntervalMinutesLabel = new System.Windows.Forms.Label();
            this.SynchronizeIntervalLabel = new System.Windows.Forms.Label();
            this.SynchronizeButton = new System.Windows.Forms.Button();
            this.StagingDbGroupBox = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.StagingServerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StagingDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.StagingPasswordTextBox = new System.Windows.Forms.TextBox();
            this.StagingUserNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButon = new System.Windows.Forms.Button();
            this.SourcePasswordTextBox = new System.Windows.Forms.TextBox();
            this.SourceUsernameTextBox = new System.Windows.Forms.TextBox();
            this.SourceDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.SourceServerTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.THubOrders = new System.Windows.Forms.TabPage();
            this.THubOrdersGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ApplicationStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ApplicationMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Configuration.SuspendLayout();
            this.ManualOrderSynchronizeStartGroupBox.SuspendLayout();
            this.AutomaticOrderSynchronizeSettingsGroupBox.SuspendLayout();
            this.StagingDbGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.THubOrders.SuspendLayout();
            this.THubOrdersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.ApplicationMenuStrip.Size = new System.Drawing.Size(971, 24);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Configuration);
            this.tabControl1.Controls.Add(this.THubOrders);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 427);
            this.tabControl1.TabIndex = 5;
            // 
            // Configuration
            // 
            this.Configuration.BackColor = System.Drawing.Color.Gainsboro;
            this.Configuration.Controls.Add(this.ManualOrderSynchronizeStartGroupBox);
            this.Configuration.Controls.Add(this.AutomaticOrderSynchronizeSettingsGroupBox);
            this.Configuration.Controls.Add(this.StagingDbGroupBox);
            this.Configuration.Controls.Add(this.groupBox1);
            this.Configuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Configuration.Location = new System.Drawing.Point(4, 22);
            this.Configuration.Name = "Configuration";
            this.Configuration.Padding = new System.Windows.Forms.Padding(3);
            this.Configuration.Size = new System.Drawing.Size(963, 401);
            this.Configuration.TabIndex = 0;
            this.Configuration.Text = "Configuration";
            // 
            // ManualOrderSynchronizeStartGroupBox
            // 
            this.ManualOrderSynchronizeStartGroupBox.Controls.Add(this.SendToMoldingBoxButton);
            this.ManualOrderSynchronizeStartGroupBox.Location = new System.Drawing.Point(8, 189);
            this.ManualOrderSynchronizeStartGroupBox.Name = "ManualOrderSynchronizeStartGroupBox";
            this.ManualOrderSynchronizeStartGroupBox.Size = new System.Drawing.Size(450, 55);
            this.ManualOrderSynchronizeStartGroupBox.TabIndex = 4;
            this.ManualOrderSynchronizeStartGroupBox.TabStop = false;
            this.ManualOrderSynchronizeStartGroupBox.Text = "Manual Order Synchronize";
            // 
            // SendToMoldingBoxButton
            // 
            this.SendToMoldingBoxButton.BackColor = System.Drawing.Color.DarkOrange;
            this.SendToMoldingBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToMoldingBoxButton.ForeColor = System.Drawing.Color.Transparent;
            this.SendToMoldingBoxButton.Location = new System.Drawing.Point(6, 18);
            this.SendToMoldingBoxButton.Name = "SendToMoldingBoxButton";
            this.SendToMoldingBoxButton.Size = new System.Drawing.Size(438, 27);
            this.SendToMoldingBoxButton.TabIndex = 0;
            this.SendToMoldingBoxButton.Text = "Send To MoldingBox";
            this.SendToMoldingBoxButton.UseVisualStyleBackColor = false;
            // 
            // AutomaticOrderSynchronizeSettingsGroupBox
            // 
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.maskedTextBox1);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeIntervalMinutesLabel);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeIntervalLabel);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Controls.Add(this.SynchronizeButton);
            this.AutomaticOrderSynchronizeSettingsGroupBox.Location = new System.Drawing.Point(483, 189);
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
            this.maskedTextBox1.Size = new System.Drawing.Size(48, 21);
            this.maskedTextBox1.TabIndex = 13;
            // 
            // SynchronizeIntervalMinutesLabel
            // 
            this.SynchronizeIntervalMinutesLabel.AutoSize = true;
            this.SynchronizeIntervalMinutesLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.SynchronizeIntervalMinutesLabel.Location = new System.Drawing.Point(119, 25);
            this.SynchronizeIntervalMinutesLabel.Name = "SynchronizeIntervalMinutesLabel";
            this.SynchronizeIntervalMinutesLabel.Size = new System.Drawing.Size(42, 15);
            this.SynchronizeIntervalMinutesLabel.TabIndex = 3;
            this.SynchronizeIntervalMinutesLabel.Text = "(mins)";
            // 
            // SynchronizeIntervalLabel
            // 
            this.SynchronizeIntervalLabel.AutoSize = true;
            this.SynchronizeIntervalLabel.Location = new System.Drawing.Point(6, 25);
            this.SynchronizeIntervalLabel.Name = "SynchronizeIntervalLabel";
            this.SynchronizeIntervalLabel.Size = new System.Drawing.Size(119, 15);
            this.SynchronizeIntervalLabel.TabIndex = 1;
            this.SynchronizeIntervalLabel.Text = "Synchronize Interval:";
            // 
            // SynchronizeButton
            // 
            this.SynchronizeButton.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.PlayImage;
            this.SynchronizeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SynchronizeButton.Location = new System.Drawing.Point(328, 16);
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
            this.StagingDbGroupBox.Controls.Add(this.button3);
            this.StagingDbGroupBox.Controls.Add(this.StagingServerTextBox);
            this.StagingDbGroupBox.Controls.Add(this.label1);
            this.StagingDbGroupBox.Controls.Add(this.button2);
            this.StagingDbGroupBox.Controls.Add(this.label2);
            this.StagingDbGroupBox.Controls.Add(this.label3);
            this.StagingDbGroupBox.Controls.Add(this.label4);
            this.StagingDbGroupBox.Controls.Add(this.StagingDatabaseTextBox);
            this.StagingDbGroupBox.Controls.Add(this.StagingPasswordTextBox);
            this.StagingDbGroupBox.Controls.Add(this.StagingUserNameTextBox);
            this.StagingDbGroupBox.Location = new System.Drawing.Point(483, 6);
            this.StagingDbGroupBox.Name = "StagingDbGroupBox";
            this.StagingDbGroupBox.Size = new System.Drawing.Size(462, 175);
            this.StagingDbGroupBox.TabIndex = 2;
            this.StagingDbGroupBox.TabStop = false;
            this.StagingDbGroupBox.Text = "Staging Database";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(328, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 32);
            this.button3.TabIndex = 12;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // StagingServerTextBox
            // 
            this.StagingServerTextBox.Location = new System.Drawing.Point(122, 31);
            this.StagingServerTextBox.Name = "StagingServerTextBox";
            this.StagingServerTextBox.Size = new System.Drawing.Size(304, 21);
            this.StagingServerTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Usename:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Password:";
            // 
            // StagingDatabaseTextBox
            // 
            this.StagingDatabaseTextBox.Location = new System.Drawing.Point(122, 56);
            this.StagingDatabaseTextBox.Name = "StagingDatabaseTextBox";
            this.StagingDatabaseTextBox.Size = new System.Drawing.Size(304, 21);
            this.StagingDatabaseTextBox.TabIndex = 8;
            // 
            // StagingPasswordTextBox
            // 
            this.StagingPasswordTextBox.Location = new System.Drawing.Point(122, 108);
            this.StagingPasswordTextBox.Name = "StagingPasswordTextBox";
            this.StagingPasswordTextBox.PasswordChar = '*';
            this.StagingPasswordTextBox.Size = new System.Drawing.Size(304, 21);
            this.StagingPasswordTextBox.TabIndex = 10;
            // 
            // StagingUserNameTextBox
            // 
            this.StagingUserNameTextBox.Location = new System.Drawing.Point(122, 82);
            this.StagingUserNameTextBox.Name = "StagingUserNameTextBox";
            this.StagingUserNameTextBox.Size = new System.Drawing.Size(304, 21);
            this.StagingUserNameTextBox.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SaveButon);
            this.groupBox1.Controls.Add(this.SourcePasswordTextBox);
            this.groupBox1.Controls.Add(this.SourceUsernameTextBox);
            this.groupBox1.Controls.Add(this.SourceDatabaseTextBox);
            this.groupBox1.Controls.Add(this.SourceServerTextBox);
            this.groupBox1.Controls.Add(this.PasswordLabel);
            this.groupBox1.Controls.Add(this.UsernameLabel);
            this.groupBox1.Controls.Add(this.DatabaseLabel);
            this.groupBox1.Controls.Add(this.ServerLabel);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Database ";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(306, 132);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(98, 32);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButon
            // 
            this.SaveButon.Location = new System.Drawing.Point(202, 132);
            this.SaveButon.Name = "SaveButon";
            this.SaveButon.Size = new System.Drawing.Size(98, 32);
            this.SaveButon.TabIndex = 5;
            this.SaveButon.Text = "Save";
            this.SaveButon.UseVisualStyleBackColor = true;
            // 
            // SourcePasswordTextBox
            // 
            this.SourcePasswordTextBox.Location = new System.Drawing.Point(90, 104);
            this.SourcePasswordTextBox.Name = "SourcePasswordTextBox";
            this.SourcePasswordTextBox.PasswordChar = '*';
            this.SourcePasswordTextBox.Size = new System.Drawing.Size(314, 21);
            this.SourcePasswordTextBox.TabIndex = 4;
            // 
            // SourceUsernameTextBox
            // 
            this.SourceUsernameTextBox.Location = new System.Drawing.Point(90, 78);
            this.SourceUsernameTextBox.Name = "SourceUsernameTextBox";
            this.SourceUsernameTextBox.Size = new System.Drawing.Size(314, 21);
            this.SourceUsernameTextBox.TabIndex = 3;
            // 
            // SourceDatabaseTextBox
            // 
            this.SourceDatabaseTextBox.Location = new System.Drawing.Point(90, 52);
            this.SourceDatabaseTextBox.Name = "SourceDatabaseTextBox";
            this.SourceDatabaseTextBox.Size = new System.Drawing.Size(314, 21);
            this.SourceDatabaseTextBox.TabIndex = 2;
            // 
            // SourceServerTextBox
            // 
            this.SourceServerTextBox.Location = new System.Drawing.Point(90, 27);
            this.SourceServerTextBox.Name = "SourceServerTextBox";
            this.SourceServerTextBox.Size = new System.Drawing.Size(314, 21);
            this.SourceServerTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(24, 108);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(64, 15);
            this.PasswordLabel.TabIndex = 14;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(25, 82);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(64, 15);
            this.UsernameLabel.TabIndex = 13;
            this.UsernameLabel.Text = "Usename:";
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.AutoSize = true;
            this.DatabaseLabel.Location = new System.Drawing.Point(24, 56);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(63, 15);
            this.DatabaseLabel.TabIndex = 12;
            this.DatabaseLabel.Text = "Database:";
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(39, 31);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(45, 15);
            this.ServerLabel.TabIndex = 11;
            this.ServerLabel.Text = "Server:";
            // 
            // THubOrders
            // 
            this.THubOrders.Controls.Add(this.THubOrdersGroupBox);
            this.THubOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.THubOrders.Location = new System.Drawing.Point(4, 22);
            this.THubOrders.Name = "THubOrders";
            this.THubOrders.Padding = new System.Windows.Forms.Padding(3);
            this.THubOrders.Size = new System.Drawing.Size(963, 401);
            this.THubOrders.TabIndex = 1;
            this.THubOrders.Text = "T-Hub Orders";
            this.THubOrders.UseVisualStyleBackColor = true;
            // 
            // THubOrdersGroupBox
            // 
            this.THubOrdersGroupBox.Controls.Add(this.dataGridView1);
            this.THubOrdersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.THubOrdersGroupBox.Location = new System.Drawing.Point(3, 3);
            this.THubOrdersGroupBox.Name = "THubOrdersGroupBox";
            this.THubOrdersGroupBox.Size = new System.Drawing.Size(957, 395);
            this.THubOrdersGroupBox.TabIndex = 0;
            this.THubOrdersGroupBox.TabStop = false;
            this.THubOrdersGroupBox.Text = "T-Hub Orders";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(963, 401);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Order Shipped";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
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
            this.ApplicationStatusStrip.Location = new System.Drawing.Point(0, 451);
            this.ApplicationStatusStrip.Name = "ApplicationStatusStrip";
            this.ApplicationStatusStrip.Size = new System.Drawing.Size(971, 22);
            this.ApplicationStatusStrip.TabIndex = 50;
            this.ApplicationStatusStrip.Text = "Application Status Strip";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 473);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ApplicationStatusStrip);
            this.Controls.Add(this.ApplicationMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ApplicationMenuStrip;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSS  (Order Synchronization System)";
            this.ApplicationMenuStrip.ResumeLayout(false);
            this.ApplicationMenuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Configuration.ResumeLayout(false);
            this.ManualOrderSynchronizeStartGroupBox.ResumeLayout(false);
            this.AutomaticOrderSynchronizeSettingsGroupBox.ResumeLayout(false);
            this.AutomaticOrderSynchronizeSettingsGroupBox.PerformLayout();
            this.StagingDbGroupBox.ResumeLayout(false);
            this.StagingDbGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.THubOrders.ResumeLayout(false);
            this.THubOrdersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Configuration;
        private System.Windows.Forms.GroupBox StagingDbGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage THubOrders;
        private System.Windows.Forms.Button SaveButon;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox StagingDatabaseTextBox;
        private System.Windows.Forms.TextBox StagingPasswordTextBox;
        private System.Windows.Forms.TextBox StagingUserNameTextBox;
        private System.Windows.Forms.GroupBox ManualOrderSynchronizeStartGroupBox;
        private System.Windows.Forms.Button SendToMoldingBoxButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox THubOrdersGroupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox SourceServerTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        public System.Windows.Forms.StatusStrip ApplicationStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
    }
}

