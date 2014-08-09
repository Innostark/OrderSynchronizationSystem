using System;
using System.Windows.Forms;

namespace IST.OrderSynchronizationSystem
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenConnectionWindow(ConnectionType.Source);
        }        

        private void stagingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenConnectionWindow(ConnectionType.Staging);
        }

        private void OpenConnectionWindow(ConnectionType connectionType)
        {
            ConnectionForm ConnectionForm = new ConnectionForm(connectionType);
            // Set the Parent Form of the Child window.
            ConnectionForm.MdiParent = this;
            // Display the new form.
            ConnectionForm.Show();
        }

        private void orderSynchronizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderSynchronizerTHubToMoldingBoxForm OrderSynchronizerForm = new OrderSynchronizerTHubToMoldingBoxForm();
            // Set the Parent Form of the Child window.
            OrderSynchronizerForm.MdiParent = this;
            // Display the new form.
            OrderSynchronizerForm.Show();
        }
    }
}
