using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.MBAPI;

namespace IST.OrderSynchronizationSystem
{
    public partial class ShipmentMappingForm : Form
    {
        private OssDatabase synchronizationDatabase;
        private ShippingMethod[] moldingBoxWebShipmentMethod;
        public ShipmentMappingForm(OssDatabase database, ShippingMethod[] moldingBoxWebShipmentMethod)
        {
            
            InitializeComponent();            
            synchronizationDatabase = database;
            this.moldingBoxWebShipmentMethod = moldingBoxWebShipmentMethod;
            shipmentMappingGridView.EditingControlShowing +=shipmentMappingGridView_EditingControlShowing;
            button1.Enabled = false;
        }

        private void shipmentMappingGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;                
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void ShipmentMappingForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable shipmentMapping = synchronizationDatabase.LoadMappingsFromStagingDatabase();
                if (shipmentMapping.Rows.Count > 0)
                {
                    shipmentMappingGridView.DataSource = shipmentMapping;
                    AddComboBoxColumn();
                }
                shipmentMappingGridView.Columns["DestinationShipmentMethod"].Visible = false;
                MappingLabel.Text = "Total No. of Mappings: " + shipmentMapping.Rows.Count;
                HideIdColumn();
            }
            catch (Exception exception)
            {
                synchronizationDatabase.LogOrder(1, -1, string.Format("Error loading mappings. Error: {0}", exception.Message));
                MessageBox.Show("There is some problem while loading mappings. Error details has been logged. Please check database if the problem persists.", "Error!", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void HideIdColumn()
        {
            shipmentMappingGridView.Columns[0].Visible = false;
        }

        
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable shipmentMapping = synchronizationDatabase.LoadMappingsFromStagingDatabase();
                if (shipmentMapping.Rows.Count > 0)
                {
                    shipmentMappingGridView.DataBindings.Clear();
                    shipmentMappingGridView.Columns.Clear();
                    shipmentMappingGridView.DataSource = shipmentMapping;
                    AddComboBoxColumn();
                }
                shipmentMappingGridView.Columns["DestinationShipmentMethod"].Visible = false;
                HideIdColumn();
                MappingLabel.Text = "Total No. of Mappings: " + shipmentMapping.Rows.Count;
            }            
            catch (Exception exception)
            {
                synchronizationDatabase.LogOrder(1, -1, string.Format("Error loading mappings. Error: {0}", exception.Message));
                MessageBox.Show("There is some problem while loading mappings. Error details has been logged. Please check database if the problem persists.", "Error!", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AddComboBoxColumn()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            DataTable tableSource = new DataTable("tableSource");
            tableSource.Columns.AddRange(new[] { new DataColumn("ID"), new DataColumn("Method") });
            foreach (ShippingMethod shippingMethod in moldingBoxWebShipmentMethod)
            {
                tableSource.Rows.Add(shippingMethod.ID, shippingMethod.Method);
            }
            
            cmb.DataSource = tableSource;
            
            cmb.DisplayMember = "Method";
            cmb.ValueMember = "Method";
            cmb.Name = "MethodCombobox";
            cmb.DataPropertyName = "DestinationShipmentMethod";
            shipmentMappingGridView.Columns.Add(cmb);
            shipmentMappingGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            shipmentMappingGridView.Columns[0].ReadOnly = true;
            shipmentMappingGridView.Columns[1].ReadOnly = true;
        }
        private void shipmentMappingGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IList<MBShimentMethodMappings> mappings = validateMappings();
                if (mappings != null)
                {
                    synchronizationDatabase.UpdateMappings(mappings);
                }
                button1.Enabled = false;
            }
            catch (Exception exception)
            {
                synchronizationDatabase.LogOrder(1, -1, string.Format("Error saving mappings. Error: {0}", exception.Message));
                MessageBox.Show("There is some problem while saving mappings. Error details has been logged. Please check database if the problem persists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private IList<MBShimentMethodMappings> validateMappings()
        {
            List<MBShimentMethodMappings> mappingsToSave = new List<MBShimentMethodMappings>();
            for (int i = 0; i < shipmentMappingGridView.Rows.Count; i++)
            {
                DataGridViewComboBoxCell cell = shipmentMappingGridView.Rows[i].Cells["MethodCombobox"] as DataGridViewComboBoxCell;
                if (cell != null && cell.FormattedValue != null && string.IsNullOrEmpty(cell.FormattedValue.ToString()))
                {
                    MessageBox.Show("Please enter all mappings.");
                    return null;
                }
                MBShimentMethodMappings mapping = new MBShimentMethodMappings()
                {
                    DestinationShipmentMethodID = shipmentMappingGridView.Rows[i].Cells["OSSShipmentMappingsId"].Value.ToString(),
                    SourceShipmentMethod = shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString(),
                    DestinationShipmentMethod = shipmentMappingGridView.Rows[i].Cells["MethodCombobox"].Value != null ?  shipmentMappingGridView.Rows[i].Cells["MethodCombobox"].Value.ToString() : string.Empty,

                };
                mappingsToSave.Add(mapping); 
            }
            return mappingsToSave;
        }
        
    }

    
}
