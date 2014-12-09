using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.MBAPI;
using IST.OrderSynchronizationSystem.MoldingBox;


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
            //var Client = MoldingBoxHelper.GetMoldingBoxClient();
            //var Shipments = new Shipment[] 
            //{ new Shipment()
            //    {
            //        OrderID = "T100005182",
            //        Orderdate = Convert.ToDateTime("2014-08-09 00:00:00.000"),
            //        Company = String.Empty,
            //        FirstName = "Hendrik",
            //        LastName = "Tysma",
            //        Address1 = "PO Box 102374",
            //        Address2 = null,
            //        City = "Denver",
            //        State = "CO",
            //        Country = "US",
            //        Email = "hendrik@electroflip.com",
            //        Phone = "9546484936",
            //        ShippingMethodID = 1,
            //        CODAmount = 1.00,
            //        Items = new Item[] 
            //        { new Item()
            //            {
            //                SKU = "SKU1",
            //                Description = "Test SKU2 Memory Card = No Memory Card",
            //                Quantity = 1,

            //            } 
            //        }
            //    }
            //};

            //var PostShipmentResponse = MoldingBoxHelper.PostShipment(Client, "MBLLTAtOr8wKNI2Z44oPj2s81Hea6F", Shipments);
            //var ShipmentStatus = Client.Retrieve_Shipment_Status("MBLLTAtOr8wKNI2Z44oPj2s81Hea6F", new ArrayOfInt() {1315020});
           // var ShipmentCancelStatus = Client.Cancel_Shipment("MBLLTAtOr8wKNI2Z44oPj2s81Hea6F", new ArrayOfInt() { 1315020 });

            //OrderID	Orderdate	Company	FirstName	LastName	Address1	Address2	City	State	Country	Email	Phone	ShippingMethodID	CODAmount	Custom1	Custom2	Custom3	Custom4	Custom5
            //2180	2014-08-09 00:00:00.000		Hendrik	Tysma	PO Box 102374		Denver	CO	US	hendrik@electroflip.com	9546484936	FedEx (Federal Express) - Home Delivery		1				


            //MoldingBoxSoapClient.ClientCredentials.UserName.UserName = "SKU1";
            //MoldingBoxSoapClient.ClientCredentials.UserName.Password = "MBLLTAtOr8wKNI2Z44oPj2s81Hea6F";

            //var GetShipingMethods = new MBAPI.Retrieve_Shipping_MethodsRequest();
            //var ShipingMethodsResponse = new MBAPI.Retrieve_Shipping_MethodsResponse();

            //GetShipingMethods.Body = new Retrieve_Shipping_MethodsRequestBody();
            //var a123 = MoldingBoxSoapClient.Retrieve_Shipping_Methods();

            //bool aIsNewInstance = false, result = false;
            //Mutex myMutex = new Mutex(true, "IST.OrderSynchronizationSystem", out aIsNewInstance);
            if (AnotherInstanceExists())
            {
                MessageBox.Show("OSS is already running...", "OSS  (Order Synchronization System)", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(false));
        }
        private static bool AnotherInstanceExists()
        {
            Process currentRunningProcess = Process.GetCurrentProcess();
            Process[] listOfProcs = Process.GetProcessesByName(currentRunningProcess.ProcessName);

            return listOfProcs.Any(proc => (proc.MainModule.FileName == currentRunningProcess.MainModule.FileName) && (proc.Id != currentRunningProcess.Id));
        }
    }
}