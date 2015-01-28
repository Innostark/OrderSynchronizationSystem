namespace IST.OrderSynchronizationSystem
{
    partial class CreateMappingForm
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
            this.tHubShipMethod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shipViaCombobox = new System.Windows.Forms.ComboBox();
            this.mbShipMethod = new System.Windows.Forms.TextBox();
            this.mbShipment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mappingErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappingErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tHubShipMethod
            // 
            this.tHubShipMethod.Location = new System.Drawing.Point(6, 54);
            this.tHubShipMethod.Name = "tHubShipMethod";
            this.tHubShipMethod.Size = new System.Drawing.Size(260, 20);
            this.tHubShipMethod.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "T-Hub: Web Shipment Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MB: Shipment Method Id";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shipViaCombobox);
            this.groupBox1.Controls.Add(this.mbShipMethod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mbShipment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tHubShipMethod);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 213);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "T-Hub to Molding Box Mapping";
            // 
            // shipViaCombobox
            // 
            this.shipViaCombobox.FormattingEnabled = true;
            this.shipViaCombobox.Location = new System.Drawing.Point(6, 93);
            this.shipViaCombobox.Name = "shipViaCombobox";
            this.shipViaCombobox.Size = new System.Drawing.Size(256, 21);
            this.shipViaCombobox.TabIndex = 1;
            // 
            // mbShipMethod
            // 
            this.mbShipMethod.Location = new System.Drawing.Point(6, 132);
            this.mbShipMethod.Name = "mbShipMethod";
            this.mbShipMethod.Size = new System.Drawing.Size(256, 20);
            this.mbShipMethod.TabIndex = 3;
            // 
            // mbShipment
            // 
            this.mbShipment.Location = new System.Drawing.Point(6, 174);
            this.mbShipment.Name = "mbShipment";
            this.mbShipment.Size = new System.Drawing.Size(260, 20);
            this.mbShipment.TabIndex = 4;
            this.mbShipment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mbShipment_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "T-Hub: Ship Method";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "T-Hub: Ship Via";
            // 
            // mappingErrorProvider
            // 
            this.mappingErrorProvider.ContainerControl = this;
            // 
            // CreateMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateMappingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Mapping";
            this.Load += new System.EventHandler(this.CreateMappingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappingErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tHubShipMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox mbShipment;
        private System.Windows.Forms.TextBox mbShipMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider mappingErrorProvider;
        private System.Windows.Forms.ComboBox shipViaCombobox;

    }
}