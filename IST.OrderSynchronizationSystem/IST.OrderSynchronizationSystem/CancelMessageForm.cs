using System;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.Properties;

namespace IST.OrderSynchronizationSystem
{
    public partial class CancelMessageForm : Form
    {
        public string CancelMessageString { get; set; }
        public DialogResult Result { get; set; }
        public CancelMessageForm()
        {
            InitializeComponent();
        }

        private void CancelMessageSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cancelMessageTextBox.Text))
            {
                cancelErrorProvider.SetError(cancelMessageTextBox, Resources.MainWindow_Required_Field);
                return;
            }
            CancelMessageString = cancelMessageTextBox.Text;
            Result = DialogResult.OK;
            Close();
        }
    }
}
