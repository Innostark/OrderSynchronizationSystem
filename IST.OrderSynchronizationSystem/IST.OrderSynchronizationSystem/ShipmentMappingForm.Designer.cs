namespace IST.OrderSynchronizationSystem
{
    partial class ShipmentMappingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentMappingForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MappingLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.shipmentMappingGridView = new System.Windows.Forms.DataGridView();
            this.DestinationShipmentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentMappingGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.MappingLabel);
            this.groupBox1.Controls.Add(this.RefreshButton);
            this.groupBox1.Controls.Add(this.CloseButton);
            this.groupBox1.Controls.Add(this.shipmentMappingGridView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shipment Methods Mappings";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MappingLabel
            // 
            this.MappingLabel.AutoSize = true;
            this.MappingLabel.Location = new System.Drawing.Point(13, 398);
            this.MappingLabel.Name = "MappingLabel";
            this.MappingLabel.Size = new System.Drawing.Size(118, 13);
            this.MappingLabel.TabIndex = 3;
            this.MappingLabel.Text = "Total No. of Mappings: ";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(564, 397);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(645, 397);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // shipmentMappingGridView
            // 
            this.shipmentMappingGridView.AllowUserToDeleteRows = false;
            this.shipmentMappingGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shipmentMappingGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.shipmentMappingGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shipmentMappingGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DestinationShipmentMethod});
            this.shipmentMappingGridView.Location = new System.Drawing.Point(13, 20);
            this.shipmentMappingGridView.MultiSelect = false;
            this.shipmentMappingGridView.Name = "shipmentMappingGridView";
            this.shipmentMappingGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.shipmentMappingGridView.RowHeadersVisible = false;
            this.shipmentMappingGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.shipmentMappingGridView.Size = new System.Drawing.Size(789, 371);
            this.shipmentMappingGridView.TabIndex = 0;
            this.shipmentMappingGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentMappingGridView_CellContentClick);
            this.shipmentMappingGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.shipmentMappingGridView_CellValueChanged);
            this.shipmentMappingGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.shipmentMappingGridView_DataError);
            // 
            // DestinationShipmentMethod
            // 
            this.DestinationShipmentMethod.DataPropertyName = "DestinationShipmentMethod";
            this.DestinationShipmentMethod.HeaderText = "Molding Box Shipment Method Id";
            this.DestinationShipmentMethod.Name = "DestinationShipmentMethod";
            // 
            // ShipmentMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 427);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShipmentMappingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shipment Method Mappings";
            this.Load += new System.EventHandler(this.ShipmentMappingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentMappingGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.DataGridView shipmentMappingGridView;
        private System.Windows.Forms.Label MappingLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationShipmentMethod;
    }
}