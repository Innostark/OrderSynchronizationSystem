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
    public partial class ShipmentMappingForm : Form
    {
        private OssDatabase synchronizationDatabase;
        public ShipmentMappingForm(OssDatabase database)
        {
            InitializeComponent();
            this.synchronizationDatabase = database;
        }

        private void ShipmentMappingForm_Load(object sender, EventArgs e)
        {
            DataTable shipmentMapping = synchronizationDatabase.LoadMappingsFromStagingDatabase();
            if (shipmentMapping.Rows.Count > 0)
            {
                shipmentMappingGridView.DataSource = shipmentMapping;
            }
            MappingLabel.Text = "Total No. of Mappings: " + shipmentMapping.Rows.Count;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            DataTable shipmentMapping = synchronizationDatabase.LoadMappingsFromStagingDatabase();
            if (shipmentMapping.Rows.Count > 0)
            {
                shipmentMappingGridView.DataSource = shipmentMapping;
            }
            MappingLabel.Text = "Total No. of Mappings: " + shipmentMapping.Rows.Count;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
