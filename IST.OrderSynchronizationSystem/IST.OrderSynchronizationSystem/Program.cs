using System;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.MBAPI;


namespace IST.OrderSynchronizationSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var MoldingBoxSoapClient = new MBAPI.MBAPISoapClient();

            MoldingBoxSoapClient.ClientCredentials.UserName.UserName = "SKU1";
            MoldingBoxSoapClient.ClientCredentials.UserName.Password = "MBLLTAtOr8wKNI2Z44oPj2s81Hea6F";

            var GetShipingMethods = new MBAPI.Retrieve_Shipping_MethodsRequest();
            var ShipingMethodsResponse = new MBAPI.Retrieve_Shipping_MethodsResponse();

            //GetShipingMethods.Body = new Retrieve_Shipping_MethodsRequestBody();
            var a123 = MoldingBoxSoapClient.Retrieve_Shipping_Methods();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(false));
        }
    }
}