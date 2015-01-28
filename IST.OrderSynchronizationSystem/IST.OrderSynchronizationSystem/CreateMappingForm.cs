using System;
using System.Data;
using System.Windows.Forms;

namespace IST.OrderSynchronizationSystem
{
    public partial class CreateMappingForm : Form
    {
        private readonly string tHubWebShipMethod;
        public int MbShipMethodId;
        //public string MbShipMethod;
        private readonly OssDatabase database;
        public DialogResult Result;
        
        public CreateMappingForm(OssDatabase database, string tHubWebShipMethod)
        {
            this.database = database;
            this.tHubWebShipMethod = tHubWebShipMethod;
            InitializeComponent();
            
            tHubShipMethod.Text = tHubWebShipMethod;
            tHubShipMethod.ReadOnly = true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (IsValidInput())
            {
                MbShipMethodId = int.Parse(mbShipment.Text);
                SaveMapping();
            }
            
        }

        private bool IsValidInput()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(mbShipment.Text))
            {
                mappingErrorProvider.SetError(mbShipment, "Please provide a valid MB: Shipment Method Id.");
                returnValue = false;
            }
            if (shipViaCombobox.SelectedItem.ToString() == "...")
            {
                mappingErrorProvider.SetError(shipViaCombobox, "Please provide a valid T-Hub: Shipment Via.");
                returnValue = false;
            }
            if (string.IsNullOrEmpty(mbShipMethod.Text))
            {
                mappingErrorProvider.SetError(mbShipMethod, "Please provide a valid T-Hub: Shipment Method.");
                returnValue = false;
            }
            return returnValue;
        }

        private void SaveMapping()
        {
            try
            {
                if (database.SaveThubToMbMapping(tHubWebShipMethod, MbShipMethodId, shipViaCombobox.SelectedItem.ToString(), mbShipMethod.Text, true))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot save mappings. Error: \n" + ex.Message);
            }
        }

        private void mbShipment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CreateMappingForm_Load(object sender, EventArgs e)
        {
            InitializeShipViaCombobox();
        }

        private void InitializeShipViaCombobox()
        {

            shipViaCombobox.Items.Add("...");
            shipViaCombobox.Items.Add("FedEx");
            shipViaCombobox.Items.Add("UPS");
            shipViaCombobox.Items.Add("USPS");
            shipViaCombobox.SelectedIndex = 0;
        }
    }
}
