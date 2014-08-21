using System;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.MBAPI;

namespace IST.OrderSynchronizationSystem
{
    public partial class CreateMappingForm : Form
    {
        private readonly ShippingMethod[] moldingBoxWebShipmentMethod;
        private readonly string tHubWebShipMethod;
        public int MbShipMethodId;
        public string MbShipMethod;
        private readonly OssDatabase database;
        public DialogResult Result;
        public CreateMappingForm(OssDatabase database, string tHubWebShipMethod, ShippingMethod[] moldingBoxWebShipmentMethod)
        {
            this.moldingBoxWebShipmentMethod = moldingBoxWebShipmentMethod;
            this.database = database;
            this.tHubWebShipMethod = tHubWebShipMethod;
            InitializeComponent();
            LoadShipmentDropdown();
            tHubShipMethod.Text = tHubWebShipMethod;
            tHubShipMethod.ReadOnly = true;
            
        }

        private void LoadShipmentDropdown()
        {
            mbShipmentMethodDDL.DataSource = moldingBoxWebShipmentMethod;
            mbShipmentMethodDDL.ValueMember = "ID";
            mbShipmentMethodDDL.DisplayMember = "Method";

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            MbShipMethod = ((ShippingMethod)mbShipmentMethodDDL.SelectedItem).Method;
            MbShipMethodId = (int) mbShipmentMethodDDL.SelectedValue;
            SaveMapping();
        }

        private void SaveMapping()
        {
            try
            {
                if (database.SaveThubToMbMapping(tHubWebShipMethod, MbShipMethod, true))
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot save mappings. Error: \n" + ex.Message);
            }            
        }
    }
}
