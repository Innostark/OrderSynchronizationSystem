namespace IST.OrderSynchronizationSystem
{
    partial class OrderSynchronizerTHubToMoldingBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderSynchronizerTHubToMoldingBoxForm));
            this.AutomaticSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SynchronizeIntervalMinutesLabel = new System.Windows.Forms.Label();
            this.SynchronizeIntervalTextBox = new System.Windows.Forms.TextBox();
            this.SynchronizeIntervalLabel = new System.Windows.Forms.Label();
            this.SynchronizeButton = new System.Windows.Forms.Button();
            this.OrdersGoupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ManualSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.SendToMoldingBoxButton = new System.Windows.Forms.Button();
            this.AutomaticSettingsGroupBox.SuspendLayout();
            this.OrdersGoupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ManualSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutomaticSettingsGroupBox
            // 
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeIntervalMinutesLabel);
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeIntervalTextBox);
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeIntervalLabel);
            this.AutomaticSettingsGroupBox.Controls.Add(this.SynchronizeButton);
            this.AutomaticSettingsGroupBox.Location = new System.Drawing.Point(209, 2);
            this.AutomaticSettingsGroupBox.Name = "AutomaticSettingsGroupBox";
            this.AutomaticSettingsGroupBox.Size = new System.Drawing.Size(282, 46);
            this.AutomaticSettingsGroupBox.TabIndex = 0;
            this.AutomaticSettingsGroupBox.TabStop = false;
            this.AutomaticSettingsGroupBox.Text = "Automatic Settings";
            // 
            // SynchronizeIntervalMinutesLabel
            // 
            this.SynchronizeIntervalMinutesLabel.AutoSize = true;
            this.SynchronizeIntervalMinutesLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.SynchronizeIntervalMinutesLabel.Location = new System.Drawing.Point(166, 20);
            this.SynchronizeIntervalMinutesLabel.Name = "SynchronizeIntervalMinutesLabel";
            this.SynchronizeIntervalMinutesLabel.Size = new System.Drawing.Size(28, 13);
            this.SynchronizeIntervalMinutesLabel.TabIndex = 3;
            this.SynchronizeIntervalMinutesLabel.Text = "mins";
            // 
            // SynchronizeIntervalTextBox
            // 
            this.SynchronizeIntervalTextBox.Location = new System.Drawing.Point(116, 16);
            this.SynchronizeIntervalTextBox.Name = "SynchronizeIntervalTextBox";
            this.SynchronizeIntervalTextBox.Size = new System.Drawing.Size(47, 20);
            this.SynchronizeIntervalTextBox.TabIndex = 2;
            // 
            // SynchronizeIntervalLabel
            // 
            this.SynchronizeIntervalLabel.AutoSize = true;
            this.SynchronizeIntervalLabel.Location = new System.Drawing.Point(7, 20);
            this.SynchronizeIntervalLabel.Name = "SynchronizeIntervalLabel";
            this.SynchronizeIntervalLabel.Size = new System.Drawing.Size(106, 13);
            this.SynchronizeIntervalLabel.TabIndex = 1;
            this.SynchronizeIntervalLabel.Text = "Synchronize Interval:";
            // 
            // SynchronizeButton
            // 
            this.SynchronizeButton.Image = global::IST.OrderSynchronizationSystem.Properties.Resources.PlayImage;
            this.SynchronizeButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.SynchronizeButton.Location = new System.Drawing.Point(200, 15);
            this.SynchronizeButton.Name = "SynchronizeButton";
            this.SynchronizeButton.Size = new System.Drawing.Size(75, 23);
            this.SynchronizeButton.TabIndex = 0;
            this.SynchronizeButton.Text = "Start";
            this.SynchronizeButton.UseVisualStyleBackColor = true;
            this.SynchronizeButton.Click += new System.EventHandler(this.SynchronizeButton_Click);
            // 
            // OrdersGoupBox
            // 
            this.OrdersGoupBox.Controls.Add(this.dataGridView1);
            this.OrdersGoupBox.Location = new System.Drawing.Point(3, 54);
            this.OrdersGoupBox.Name = "OrdersGoupBox";
            this.OrdersGoupBox.Size = new System.Drawing.Size(1057, 538);
            this.OrdersGoupBox.TabIndex = 1;
            this.OrdersGoupBox.TabStop = false;
            this.OrdersGoupBox.Text = "Orders (from T-Hub)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1045, 513);
            this.dataGridView1.TabIndex = 0;
            // 
            // ManualSettingsGroupBox
            // 
            this.ManualSettingsGroupBox.Controls.Add(this.SendToMoldingBoxButton);
            this.ManualSettingsGroupBox.Location = new System.Drawing.Point(3, 2);
            this.ManualSettingsGroupBox.Name = "ManualSettingsGroupBox";
            this.ManualSettingsGroupBox.Size = new System.Drawing.Size(200, 46);
            this.ManualSettingsGroupBox.TabIndex = 1;
            this.ManualSettingsGroupBox.TabStop = false;
            this.ManualSettingsGroupBox.Text = "Manual Settings";
            // 
            // SendToMoldingBoxButton
            // 
            this.SendToMoldingBoxButton.BackColor = System.Drawing.Color.DarkOrange;
            this.SendToMoldingBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToMoldingBoxButton.ForeColor = System.Drawing.Color.Transparent;
            this.SendToMoldingBoxButton.Location = new System.Drawing.Point(6, 14);
            this.SendToMoldingBoxButton.Name = "SendToMoldingBoxButton";
            this.SendToMoldingBoxButton.Size = new System.Drawing.Size(188, 27);
            this.SendToMoldingBoxButton.TabIndex = 0;
            this.SendToMoldingBoxButton.Text = "Send To MoldingBox";
            this.SendToMoldingBoxButton.UseVisualStyleBackColor = false;
            // 
            // OrderSynchronizerTHubToMoldingBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 595);
            this.Controls.Add(this.ManualSettingsGroupBox);
            this.Controls.Add(this.OrdersGoupBox);
            this.Controls.Add(this.AutomaticSettingsGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderSynchronizerTHubToMoldingBoxForm";
            this.Text = "Order Synchronizer (T-Hub > MoldingBox)";
            this.AutomaticSettingsGroupBox.ResumeLayout(false);
            this.AutomaticSettingsGroupBox.PerformLayout();
            this.OrdersGoupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ManualSettingsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AutomaticSettingsGroupBox;
        private System.Windows.Forms.Label SynchronizeIntervalMinutesLabel;
        private System.Windows.Forms.TextBox SynchronizeIntervalTextBox;
        private System.Windows.Forms.Label SynchronizeIntervalLabel;
        private System.Windows.Forms.Button SynchronizeButton;
        private System.Windows.Forms.GroupBox OrdersGoupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox ManualSettingsGroupBox;
        private System.Windows.Forms.Button SendToMoldingBoxButton;
    }
}