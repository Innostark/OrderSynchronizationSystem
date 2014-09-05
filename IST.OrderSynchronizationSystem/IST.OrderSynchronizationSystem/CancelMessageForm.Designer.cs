namespace IST.OrderSynchronizationSystem
{
    partial class CancelMessageForm
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
            this.CancelGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelMessageTextBox = new System.Windows.Forms.TextBox();
            this.CancelMessageSave = new System.Windows.Forms.Button();
            this.cancelErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CancelGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cancelErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelGroupBox
            // 
            this.CancelGroupBox.Controls.Add(this.cancelMessageTextBox);
            this.CancelGroupBox.Location = new System.Drawing.Point(13, 13);
            this.CancelGroupBox.Name = "CancelGroupBox";
            this.CancelGroupBox.Size = new System.Drawing.Size(257, 136);
            this.CancelGroupBox.TabIndex = 0;
            this.CancelGroupBox.TabStop = false;
            this.CancelGroupBox.Text = "Cancel Message";
            // 
            // cancelMessageTextBox
            // 
            this.cancelMessageTextBox.Location = new System.Drawing.Point(6, 28);
            this.cancelMessageTextBox.Multiline = true;
            this.cancelMessageTextBox.Name = "cancelMessageTextBox";
            this.cancelMessageTextBox.Size = new System.Drawing.Size(245, 102);
            this.cancelMessageTextBox.TabIndex = 0;
            // 
            // CancelMessageSave
            // 
            this.CancelMessageSave.Location = new System.Drawing.Point(195, 155);
            this.CancelMessageSave.Name = "CancelMessageSave";
            this.CancelMessageSave.Size = new System.Drawing.Size(75, 23);
            this.CancelMessageSave.TabIndex = 1;
            this.CancelMessageSave.Text = "Save";
            this.CancelMessageSave.UseVisualStyleBackColor = true;
            this.CancelMessageSave.Click += new System.EventHandler(this.CancelMessageSave_Click);
            // 
            // cancelErrorProvider
            // 
            this.cancelErrorProvider.ContainerControl = this;
            // 
            // CancelMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 193);
            this.Controls.Add(this.CancelMessageSave);
            this.Controls.Add(this.CancelGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CancelMessageForm";
            this.Text = "CancelMessageForm";
            this.CancelGroupBox.ResumeLayout(false);
            this.CancelGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cancelErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CancelGroupBox;
        private System.Windows.Forms.TextBox cancelMessageTextBox;
        private System.Windows.Forms.Button CancelMessageSave;
        private System.Windows.Forms.ErrorProvider cancelErrorProvider;
    }
}