using System;
using System.Windows.Forms;

namespace IST.OrderSynchronizationSystem
{
    public partial class ConnectionForm : Form
    {
        public ConnectionType FormConnectionType;

        public ConnectionForm()
        {
            InitializeComponent();
        }

        public ConnectionForm(ConnectionType connectionType)
        {
            InitializeComponent();
            this.FormConnectionType = connectionType;

            if(FormConnectionType == ConnectionType.Source)
            {
                this.Text = "Source Connection (Settings)";
                this.Icon = Properties.Resources.SourceIcon;
            }
            else if (FormConnectionType == ConnectionType.Staging)
            {
                this.Text = "Staging Connection  (Settings)";
                this.Icon = Properties.Resources.StagingIcon;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButon_Click(object sender, EventArgs e)
        {

        }
    }
}
