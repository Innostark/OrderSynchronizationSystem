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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ApplicationMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stagingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synchronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderSynchronizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicationStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Configuration = new System.Windows.Forms.TabPage();
            this.THubOrders = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StagingDbGroupBox = new System.Windows.Forms.GroupBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButon = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseTextBox = new System.Windows.Forms.TextBox();
            this.ServerTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.AutomaticSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SynchronizeIntervalMinutesLabel = new System.Windows.Forms.Label();
            this.SynchronizeIntervalTextBox = new System.Windows.Forms.TextBox();
            this.SynchronizeIntervalLabel = new System.Windows.Forms.Label();
            this.SynchronizeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SendToMoldingBoxButton = new System.Windows.Forms.Button();
            this.ManualSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.ApplicationMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Configuration.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.StagingDbGroupBox.SuspendLayout();
            this.AutomaticSettingsGroupBox.SuspendLayout();
            this.ManualSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplicationMenuStrip
            // 
            this.ApplicationMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.synchronizeToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.ApplicationMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.ApplicationMenuStrip.Name = "ApplicationMenuStrip";
            this.ApplicationMenuStrip.Size = new System.Drawing.Size(1023, 24);
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
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceToolStripMenuItem,
            this.stagingToolStripMenuItem});
            this.connectionToolStripMenuItem.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.ConnectionImage;
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.SourceImage;
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.sourceToolStripMenuItem.Text = "Source";
            this.sourceToolStripMenuItem.Click += new System.EventHandler(this.sourceToolStripMenuItem_Click);
            // 
            // stagingToolStripMenuItem
            // 
            this.stagingToolStripMenuItem.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.StagingImage;
            this.stagingToolStripMenuItem.Name = "stagingToolStripMenuItem";
            this.stagingToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.stagingToolStripMenuItem.Text = "Staging";
            this.stagingToolStripMenuItem.Click += new System.EventHandler(this.stagingToolStripMenuItem_Click);
            // 
            // synchronizeToolStripMenuItem
            // 
            this.synchronizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderSynchronizerToolStripMenuItem});
            this.synchronizeToolStripMenuItem.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.Synchronization;
            this.synchronizeToolStripMenuItem.Name = "synchronizeToolStripMenuItem";
            this.synchronizeToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.synchronizeToolStripMenuItem.Text = "Synchronize";
            // 
            // orderSynchronizerToolStripMenuItem
            // 
            this.orderSynchronizerToolStripMenuItem.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.THubToMoldingBoxSynchronizeImage;
            this.orderSynchronizerToolStripMenuItem.Name = "orderSynchronizerToolStripMenuItem";
            this.orderSynchronizerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.orderSynchronizerToolStripMenuItem.Text = "Order Synchronizer";
            this.orderSynchronizerToolStripMenuItem.Click += new System.EventHandler(this.orderSynchronizerToolStripMenuItem_Click);
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
            // ApplicationStatusStrip
            // 
            this.ApplicationStatusStrip.Location = new System.Drawing.Point(0, 451);
            this.ApplicationStatusStrip.Name = "ApplicationStatusStrip";
            this.ApplicationStatusStrip.Size = new System.Drawing.Size(1023, 22);
            this.ApplicationStatusStrip.TabIndex = 3;
            this.ApplicationStatusStrip.Text = "Application Status Strip";
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
            this.tabControl1.Size = new System.Drawing.Size(1023, 427);
            this.tabControl1.TabIndex = 5;
            // 
            // Configuration
            // 
            this.Configuration.BackColor = System.Drawing.Color.Gainsboro;
            this.Configuration.Controls.Add(this.ManualSettingsGroupBox);
            this.Configuration.Controls.Add(this.AutomaticSettingsGroupBox);
            this.Configuration.Controls.Add(this.StagingDbGroupBox);
            this.Configuration.Controls.Add(this.groupBox1);
            this.Configuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Configuration.Location = new System.Drawing.Point(4, 22);
            this.Configuration.Name = "Configuration";
            this.Configuration.Padding = new System.Windows.Forms.Padding(3);
            this.Configuration.Size = new System.Drawing.Size(1015, 401);
            this.Configuration.TabIndex = 0;
            this.Configuration.Text = "Configuration";
            // 
            // THubOrders
            // 
            this.THubOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.THubOrders.Location = new System.Drawing.Point(4, 22);
            this.THubOrders.Name = "THubOrders";
            this.THubOrders.Padding = new System.Windows.Forms.Padding(3);
            this.THubOrders.Size = new System.Drawing.Size(1015, 401);
            this.THubOrders.TabIndex = 1;
            this.THubOrders.Text = "T-Hub Orders";
            this.THubOrders.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SaveButon);
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Controls.Add(this.UsernameTextBox);
            this.groupBox1.Controls.Add(this.DatabaseTextBox);
            this.groupBox1.Controls.Add(this.ServerTextBox);
            this.groupBox1.Controls.Add(this.PasswordLabel);
            this.groupBox1.Controls.Add(this.UsernameLabel);
            this.groupBox1.Controls.Add(this.DatabaseLabel);
            this.groupBox1.Controls.Add(this.ServerLabel);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 187);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Database ";
            // 
            // StagingDbGroupBox
            // 
            this.StagingDbGroupBox.Controls.Add(this.button3);
            this.StagingDbGroupBox.Controls.Add(this.textBox1);
            this.StagingDbGroupBox.Controls.Add(this.label1);
            this.StagingDbGroupBox.Controls.Add(this.button2);
            this.StagingDbGroupBox.Controls.Add(this.label2);
            this.StagingDbGroupBox.Controls.Add(this.label3);
            this.StagingDbGroupBox.Controls.Add(this.label4);
            this.StagingDbGroupBox.Controls.Add(this.textBox2);
            this.StagingDbGroupBox.Controls.Add(this.textBox4);
            this.StagingDbGroupBox.Controls.Add(this.textBox3);
            this.StagingDbGroupBox.Location = new System.Drawing.Point(424, 6);
            this.StagingDbGroupBox.Name = "StagingDbGroupBox";
            this.StagingDbGroupBox.Size = new System.Drawing.Size(432, 187);
            this.StagingDbGroupBox.TabIndex = 2;
            this.StagingDbGroupBox.TabStop = false;
            this.StagingDbGroupBox.Text = "Staging Database";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(286, 139);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(98, 32);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButon
            // 
            this.SaveButon.Location = new System.Drawing.Point(182, 139);
            this.SaveButon.Name = "SaveButon";
            this.SaveButon.Size = new System.Drawing.Size(98, 32);
            this.SaveButon.TabIndex = 20;
            this.SaveButon.Text = "Save";
            this.SaveButon.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(90, 104);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(294, 21);
            this.PasswordTextBox.TabIndex = 18;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(90, 78);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(294, 21);
            this.UsernameTextBox.TabIndex = 17;
            // 
            // DatabaseTextBox
            // 
            this.DatabaseTextBox.Location = new System.Drawing.Point(90, 52);
            this.DatabaseTextBox.Name = "DatabaseTextBox";
            this.DatabaseTextBox.Size = new System.Drawing.Size(294, 21);
            this.DatabaseTextBox.TabIndex = 16;
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(90, 27);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(294, 21);
            this.ServerTextBox.TabIndex = 15;
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
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1267, 629);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Order Shipped";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // AutomaticSettingsGroupBox
            // 
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeIntervalMinutesLabel);
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeIntervalTextBox);
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeIntervalLabel);
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeButton);
            this.AutomaticSettingsGroupBox.Location = new System.Drawing.Point(424, 199);
            this.AutomaticSettingsGroupBox.Name = "AutomaticSettingsGroupBox";
            this.AutomaticSettingsGroupBox.Size = new System.Drawing.Size(432, 55);
            this.AutomaticSettingsGroupBox.TabIndex = 3;
            this.AutomaticSettingsGroupBox.TabStop = false;
            this.AutomaticSettingsGroupBox.Text = "Automatic Settings";
            // 
            // SynchronizeIntervalMinutesLabel
            // 
            this.SynchronizeIntervalMinutesLabel.AutoSize = true;
            this.SynchronizeIntervalMinutesLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.SynchronizeIntervalMinutesLabel.Location = new System.Drawing.Point(235, 24);
            this.SynchronizeIntervalMinutesLabel.Name = "SynchronizeIntervalMinutesLabel";
            this.SynchronizeIntervalMinutesLabel.Size = new System.Drawing.Size(34, 15);
            this.SynchronizeIntervalMinutesLabel.TabIndex = 3;
            this.SynchronizeIntervalMinutesLabel.Text = "mins";
            // 
            // SynchronizeIntervalTextBox
            // 
            this.SynchronizeIntervalTextBox.Location = new System.Drawing.Point(131, 21);
            this.SynchronizeIntervalTextBox.Name = "SynchronizeIntervalTextBox";
            this.SynchronizeIntervalTextBox.Size = new System.Drawing.Size(87, 21);
            this.SynchronizeIntervalTextBox.TabIndex = 2;
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
            this.SynchronizeButton.Location = new System.Drawing.Point(341, 19);
            this.SynchronizeButton.Name = "SynchronizeButton";
            this.SynchronizeButton.Size = new System.Drawing.Size(85, 26);
            this.SynchronizeButton.TabIndex = 0;
            this.SynchronizeButton.Text = "Start";
            this.SynchronizeButton.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 21);
            this.textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(122, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(294, 21);
            this.textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 82);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(294, 21);
            this.textBox3.TabIndex = 17;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(122, 108);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(294, 21);
            this.textBox4.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(214, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 32);
            this.button2.TabIndex = 20;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(318, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 32);
            this.button3.TabIndex = 21;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // SendToMoldingBoxButton
            // 
            this.SendToMoldingBoxButton.BackColor = System.Drawing.Color.DarkOrange;
            this.SendToMoldingBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToMoldingBoxButton.ForeColor = System.Drawing.Color.Transparent;
            this.SendToMoldingBoxButton.Location = new System.Drawing.Point(6, 18);
            this.SendToMoldingBoxButton.Name = "SendToMoldingBoxButton";
            this.SendToMoldingBoxButton.Size = new System.Drawing.Size(188, 27);
            this.SendToMoldingBoxButton.TabIndex = 0;
            this.SendToMoldingBoxButton.Text = "Send To MoldingBox";
            this.SendToMoldingBoxButton.UseVisualStyleBackColor = false;
            // 
            // ManualSettingsGroupBox
            // 
            this.ManualSettingsGroupBox.Controls.Add(this.SendToMoldingBoxButton);
            this.ManualSettingsGroupBox.Location = new System.Drawing.Point(8, 199);
            this.ManualSettingsGroupBox.Name = "ManualSettingsGroupBox";
            this.ManualSettingsGroupBox.Size = new System.Drawing.Size(410, 55);
            this.ManualSettingsGroupBox.TabIndex = 4;
            this.ManualSettingsGroupBox.TabStop = false;
            this.ManualSettingsGroupBox.Text = "Manual Settings";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 473);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.StagingDbGroupBox.ResumeLayout(false);
            this.StagingDbGroupBox.PerformLayout();
            this.AutomaticSettingsGroupBox.ResumeLayout(false);
            this.AutomaticSettingsGroupBox.PerformLayout();
            this.ManualSettingsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ApplicationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stagingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synchronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderSynchronizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ApplicationStatusStrip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Configuration;
        private System.Windows.Forms.GroupBox StagingDbGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage THubOrders;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButon;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox DatabaseTextBox;
        private System.Windows.Forms.TextBox ServerTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox AutomaticSettingsGroupBox;
        private System.Windows.Forms.Label SynchronizeIntervalMinutesLabel;
        private System.Windows.Forms.TextBox SynchronizeIntervalTextBox;
        private System.Windows.Forms.Label SynchronizeIntervalLabel;
        private System.Windows.Forms.Button SynchronizeButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox ManualSettingsGroupBox;
        private System.Windows.Forms.Button SendToMoldingBoxButton;
    }
}

