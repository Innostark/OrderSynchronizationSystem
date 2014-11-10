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
        private bool UpdateShipmentMapping;
        public CreateMappingForm(OssDatabase database, string tHubWebShipMethod, bool updateShipment = false)
        {
            this.database = database;
            this.tHubWebShipMethod = tHubWebShipMethod;
            InitializeComponent();
            
            tHubShipMethod.Text = tHubWebShipMethod;
            tHubShipMethod.ReadOnly = true;
            UpdateShipmentMapping = updateShipment;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {            
            MbShipMethodId = int.Parse(mbShipment.Text);
            SaveMapping();
        }

        private void SaveMapping()
        {
            try
            {
                if (!UpdateShipmentMapping)
                {
                    if (database.SaveThubToMbMapping(tHubWebShipMethod, MbShipMethodId, true))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    if (database.UpdateThubToMbMapping(tHubWebShipMethod, MbShipMethodId, true))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
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
