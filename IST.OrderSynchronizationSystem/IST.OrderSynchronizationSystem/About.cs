using System.Windows.Forms;

namespace IST.OrderSynchronizationSystem
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.innostark.com");
        }
    }
}
