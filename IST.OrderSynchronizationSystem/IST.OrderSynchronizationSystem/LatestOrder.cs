using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IST.OrderSynchronizationSystem
{
    public partial class LatestOrder : Form
    {
        private OssDatabase _database;
        public DialogResult results;
        public LatestOrder(OssDatabase database)
        {
            InitializeComponent();
            _database = database;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                long OrderId;
                if (string.IsNullOrEmpty(textBox1.Text) || !long.TryParse(textBox1.Text, out OrderId))
                {
                    errorProvider1.SetError(textBox1, "Please provide a valid Order Id.");
                }
                else
                {
                    _database.CreateDatabase(OrderId);
                    results = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                        "Staging database objects cannot be created on the specified database. Please make sure the database settings you provided on configurations tab exists and no script has been previously uploaded.",
                        "Error creating database!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
