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
    public partial class ViewLogForm : Form
    {
        private OssDatabase synchronizationDatabase;
        public ViewLogForm(OssDatabase database)
        {
            InitializeComponent();
            synchronizationDatabase = database;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var results =
                MessageBox.Show("Are you sure you want to clear all logs? This operation is irreversible. Press ok to proceed.",
                    "Clear all logs?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (results == DialogResult.OK)
            {
                synchronizationDatabase.ClearAllLogs();
                LogsGridView.DataBindings.Clear();
                LogsLabel.Text = "Total No. of Logs: 0" ;
            }
            
        }

        private void ViewLogForm_Load(object sender, EventArgs e)
        {
            DataTable logsTable = synchronizationDatabase.LoadLogsFromDatabase();
            if (logsTable.Rows.Count > 0)
            {
                LogsGridView.DataSource = logsTable;
            }
            LogsLabel.Text = "Total No. of Logs: " + logsTable.Rows.Count;
        }
    }
}
