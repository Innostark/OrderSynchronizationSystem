using System;
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
                mappingErrorProvider.SetError(mbShipment, "Please provide a valid Molding-Box Shipment Method Id.");
                returnValue = false;
            }
            if (string.IsNullOrEmpty(mbShipVia.Text))
            {
                mappingErrorProvider.SetError(mbShipVia, "Please provide a valid Molding-Box Shipment Via.");
                returnValue = false;
            }
            if (string.IsNullOrEmpty(mbShipMethod.Text))
            {
                mappingErrorProvider.SetError(mbShipMethod, "Please provide a valid Molding-Box Shipment Method.");
                returnValue = false;
            }
            return returnValue;
        }

        private void SaveMapping()
        {
            try
            {
                if (database.SaveThubToMbMapping(tHubWebShipMethod, MbShipMethodId, mbShipVia.Text, mbShipMethod.Text, true))
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
    }
}
