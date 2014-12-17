using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.MBAPI;
using Microsoft.Data.Enterprise;

namespace IST.OrderSynchronizationSystem
{
    public partial class ShipmentMappingForm : Form
    {
        private OssDatabase synchronizationDatabase;
        private ShippingMethod[] moldingBoxWebShipmentMethod;
        private bool initialLoaded = false;
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
            //ComboBox combo = e.Control as ComboBox;
            //if (combo != null)
            //{
            //    combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;                
            //}
        }

        //private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    button1.Enabled = true;
        //}

        private void ShipmentMappingForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable shipmentMapping = synchronizationDatabase.LoadMappingsFromStagingDatabase();
                if (shipmentMapping.Rows.Count > 0)
                {
                    shipmentMappingGridView.DataSource = shipmentMapping;
                    shipmentMappingGridView.Columns["MBShipVia"].DisplayIndex = 2;
                    shipmentMappingGridView.Columns["MBShipMethod"].DisplayIndex = 3;
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].DisplayIndex = 1;
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].DisplayIndex = 0;
                    //AddComboBoxColumn();
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].HeaderText = "Molding Box: Shipment Method Id";
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].HeaderText = "T-Hub Shipment Method";
                    shipmentMappingGridView.Columns["MBShipVia"].HeaderText = "Molding-Box: Ship Via";
                    shipmentMappingGridView.Columns["MBShipMethod"].HeaderText = "Molding-Box: Ship Method";
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].ReadOnly = false;
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].ReadOnly = false;
                    shipmentMappingGridView.Columns["MBShipVia"].ReadOnly = false;
                    shipmentMappingGridView.Columns["MBShipMethod"].ReadOnly = false;
                    
                    HideIdColumn();
                    AddDeleteButtonToGridView(shipmentMappingGridView, 5);
                }
                else
                {
                    shipmentMapping = CreateShipmentMappingTable();
                    shipmentMappingGridView.DataSource = shipmentMapping;
                    shipmentMappingGridView.Columns["MBShipVia"].DisplayIndex = 2;
                    shipmentMappingGridView.Columns["MBShipMethod"].DisplayIndex = 3;
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].DisplayIndex = 1;
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].DisplayIndex = 0;
                    //AddComboBoxColumn();
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].HeaderText = "Molding Box: Shipment Method Id";
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].HeaderText = "T-Hub Shipment Method";
                    shipmentMappingGridView.Columns["MBShipVia"].HeaderText = "Molding-Box: Ship Via";
                    shipmentMappingGridView.Columns["MBShipMethod"].HeaderText = "Molding-Box: Ship Method";
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].ReadOnly = false;
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].ReadOnly = false;
                    shipmentMappingGridView.Columns["MBShipVia"].ReadOnly = false;
                    shipmentMappingGridView.Columns["MBShipMethod"].ReadOnly = false;
                    HideIdColumn();
                    AddDeleteButtonToGridView(shipmentMappingGridView, 5);
                }
                
                MappingLabel.Text = "Total No. of Mappings: " + shipmentMapping.Rows.Count;
                initialLoaded = true;
            }
            catch (Exception exception)
            {
                synchronizationDatabase.LogOrder(1, -1, string.Format("Error loading mappings. Error: {0}", exception.Message));
                MessageBox.Show("There is some problem while loading mappings. Error details has been logged. Please check database if the problem persists.", "Error!", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }
        private static DataTable CreateShipmentMappingTable()
        {
            DataTable ossOrdersTable = new DataTable("ShipmentMappingTable");
            ossOrdersTable.Columns.Add("OSSShipmentMappingsId", typeof(long));
            ossOrdersTable.Columns.Add("SourceShipmentMethod", typeof(string));
            ossOrdersTable.Columns.Add("DestinationShipmentMethod", typeof(int));
            ossOrdersTable.Columns.Add("MBShipVia", typeof(string));
            ossOrdersTable.Columns.Add("MBShipMethod", typeof(string));
            return ossOrdersTable;
        }
        private void AddDeleteButtonToGridView(DataGridView gridView, int index = 21)
        {
            DataGridViewDisableButtonColumn deleteButtonColumn = new DataGridViewDisableButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.MinimumWidth = 100;
            deleteButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            deleteButtonColumn.Name = "btnDelete";
            deleteButtonColumn.ToolTipText = "Click to delete Mapping.";
            deleteButtonColumn.DefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridView.Columns.Insert(index, deleteButtonColumn);
        }
        private void HideIdColumn()
        {
            shipmentMappingGridView.Columns["OSSShipmentMappingsId"].Visible = false;
        }

        
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable shipmentMapping = synchronizationDatabase.LoadMappingsFromStagingDatabase();
                if (shipmentMapping.Rows.Count > 0)
                {
                    shipmentMappingGridView.DataSource = null;
                    shipmentMappingGridView.DataSource = shipmentMapping;

                    shipmentMappingGridView.Columns["MBShipVia"].DisplayIndex = 2;
                    shipmentMappingGridView.Columns["MBShipMethod"].DisplayIndex = 3;
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].DisplayIndex = 1;
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].DisplayIndex = 0;
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].ReadOnly = false;
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].ReadOnly = false;
                    shipmentMappingGridView.Columns["MBShipVia"].ReadOnly = false;
                    shipmentMappingGridView.Columns["MBShipMethod"].ReadOnly = false;
                    shipmentMappingGridView.Columns["DestinationShipmentMethod"].HeaderText = "Molding Box: Shipment Method Id";
                    shipmentMappingGridView.Columns["SourceShipmentMethod"].HeaderText = "T-Hub Shipment Method";
                    shipmentMappingGridView.Columns["MBShipVia"].HeaderText = "Molding-Box: Ship Via";
                    shipmentMappingGridView.Columns["MBShipMethod"].HeaderText = "Molding-Box: Ship Method";
                    
                    HideIdColumn();
                    if (!shipmentMappingGridView.Columns.Contains("btnDelete"))
                    {
                        AddDeleteButtonToGridView(shipmentMappingGridView, 5);
                    }
                    shipmentMappingGridView.Columns["btnDelete"].DisplayIndex = 5;
                }
                
                MappingLabel.Text = "Total No. of Mappings: " + shipmentMapping.Rows.Count;
                button1.Enabled = false;
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
        private void AddComboBoxColum()
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
            cmb.HeaderText = "Moldingbox Shipment Method";
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
                if (!validateMappings())
                {
                    MessageBox.Show("Please correct mapping data and then try.", "Incorect Mappings detected.",
                        MessageBoxButtons.OK);
                    return;
                }
                
                saveMappings();
                button1.Enabled = false;
                MessageBox.Show("Mappings saved.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                synchronizationDatabase.LogOrder(1, -1, string.Format("Error saving mappings. Error: {0}", exception.Message));
                MessageBox.Show("There is some problem while saving mappings. Error details has been logged. Please check database if the problem persists.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private bool saveMappings()
        {
            IList<MBShimentMethodMappings> toBeSaved = new List<MBShimentMethodMappings>();
            IList<MBShimentMethodMappings> toBeUpdate = new List<MBShimentMethodMappings>();
            for (int i = 0; i < shipmentMappingGridView.Rows.Count - 1; i++)
            {
                if(string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["OSSShipmentMappingsId"].Value.ToString()))
                {
                    toBeSaved.Add(new MBShimentMethodMappings
                    {
                        SourceShipmentMethod = shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString(),
                        DestinationShipmentMethod = int.Parse(shipmentMappingGridView.Rows[i].Cells["DestinationShipmentMethod"].Value.ToString()),
                        MBShipVia = shipmentMappingGridView.Rows[i].Cells["MBShipVia"].Value.ToString(),
                        MBShipMethod = shipmentMappingGridView.Rows[i].Cells["MBShipMethod"].Value.ToString()
                    });
                }
                else
                {
                    toBeUpdate.Add(new MBShimentMethodMappings
                    {
                        SourceShipmentMethod = shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString(),
                        DestinationShipmentMethodID = long.Parse(shipmentMappingGridView.Rows[i].Cells["OSSShipmentMappingsId"].Value.ToString()),
                        DestinationShipmentMethod = int.Parse(shipmentMappingGridView.Rows[i].Cells["DestinationShipmentMethod"].Value.ToString()),
                        MBShipVia = shipmentMappingGridView.Rows[i].Cells["MBShipVia"].Value.ToString(),
                        MBShipMethod = shipmentMappingGridView.Rows[i].Cells["MBShipMethod"].Value.ToString()
                    });
                }
            }
            synchronizationDatabase.UpdateMappings(toBeUpdate);

            foreach (MBShimentMethodMappings mbShimentMethodMappingse in toBeSaved)
            {
                synchronizationDatabase.SaveThubToMbMapping(mbShimentMethodMappingse.SourceShipmentMethod, 
                    mbShimentMethodMappingse.DestinationShipmentMethod, mbShimentMethodMappingse.MBShipVia, mbShimentMethodMappingse.MBShipMethod, true);
            }
            return true;
        }
        private bool validateMappings()
        {
            
            for (int i = 0; i < shipmentMappingGridView.Rows.Count-1; i++)
            {
                if (
                    (!string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["OSSShipmentMappingsId"].Value.ToString()) &&
                    (string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["DestinationShipmentMethod"].Value.ToString()) ||
                      string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString()) ||
                      string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipVia"].Value.ToString()) ||
                       string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipMethod"].Value.ToString()))
                    ) ||
                  (string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["OSSShipmentMappingsId"].Value.ToString())  &&
                      (!string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["DestinationShipmentMethod"].Value.ToString()) &&
                      (string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipVia"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipMethod"].Value.ToString()))
                       )
                      ||
                      (!string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString()) &&
                      (string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["DestinationShipmentMethod"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipVia"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipMethod"].Value.ToString()))
                       )
                      ||
                      (!string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipVia"].Value.ToString()) &&
                      (string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["DestinationShipmentMethod"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipMethod"].Value.ToString()))
                       )
                      ||
                      (!string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipMethod"].Value.ToString()) &&
                      (string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["DestinationShipmentMethod"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["SourceShipmentMethod"].Value.ToString()) ||
                        string.IsNullOrEmpty(shipmentMappingGridView.Rows[i].Cells["MBShipVia"].Value.ToString()))
                       )
                      ))
                {
                    return false;
                }
            }
            return true;
        }

        private void shipmentMappingGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (initialLoaded)
            {
                button1.Enabled = true;
            }
            
        }

        private void shipmentMappingGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (shipmentMappingGridView.Columns[e.ColumnIndex].Name == "btnDelete" && shipmentMappingGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (string.IsNullOrEmpty(shipmentMappingGridView.Rows[e.RowIndex].Cells["OSSShipmentMappingsId"].Value.ToString()))
                {
                    shipmentMappingGridView.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    DialogResult results = MessageBox.Show("Are you sure you want to remove this mapping? This process is irreversible. Press Ok to continue.",
                        "Confirm Delete?", MessageBoxButtons.OKCancel);
                    if (results == DialogResult.OK)
                    {
                        synchronizationDatabase.DeleteMapping(int.Parse(shipmentMappingGridView.Rows[e.RowIndex].Cells["OSSShipmentMappingsId"].Value.ToString()));
                        shipmentMappingGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
        
    }

    
}
