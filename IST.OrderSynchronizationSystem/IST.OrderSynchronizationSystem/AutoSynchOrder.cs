using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.GUI;
using IST.OrderSynchronizationSystem.MBAPI;
using IST.OrderSynchronizationSystem.Models;
using IST.OrderSynchronizationSystem.MoldingBox;
using Newtonsoft.Json;

namespace IST.OrderSynchronizationSystem
{
    public class AutoSynchOrder
    {
        public readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private string apiKey;
        private MBAPISoapClient client;
        public void Process(Form mainWindow, int frequency)
        {
            MainWindow mainForm = (MainWindow)mainWindow;
            apiKey = mainForm.apiKey;
            client = MoldingBoxHelper.GetMoldingBoxClient();
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                mainForm.ApplicationStatusUpdate("Auto Synchronization of new orders started.");
                AutoSyncNewOrders(mainForm);
                mainForm.ReloadAllGrid();
                Thread.Sleep(frequency * 60000);
            }            
        }

        public void ProcessMb(Form mainWindow, int frequency)
        {
            MainWindow mainForm = (MainWindow)mainWindow;
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                mainForm.ApplicationStatusUpdate("Auto Synchronization Moldingbox started.");
                AutoSyncMoldingBoxStatuses(mainForm);
                Thread.Sleep(frequency * 60000);
            }            
        }

        #region New Orders Import
        private void AutoSyncNewOrders(MainWindow mainProgram)
        {
            try
            {
                ShippingMethod[] shipmentMethods = client.Retrieve_Merchant_Shipping_Methods(apiKey);
                List<OssShipment> ossShipments = mainProgram._orderSyncronizationDatabase.LoadShipmentsFromThub();
                mainProgram._orderSyncronizationDatabase.InsertShipmentsToStaging(ossShipments);
                OssShipment firstOrDefault = ossShipments.OrderByDescending(ossShipment => ossShipment.ThubOrderId).FirstOrDefault();
                if (firstOrDefault != null)
                {
                    mainProgram._orderSyncronizationDatabase.GetOrSetMaximumOrderIdFetched(firstOrDefault.ThubOrderId);
                }

                DataTable stagingNewOrders = mainProgram._orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrderTable", OSSOrderStatus.New);
                foreach (DataRow row in stagingNewOrders.Rows)
                {
                    if ((long)row["THubOrderID"] != 2710)
                        PostShipmentToMoldingBox(row, mainProgram, shipmentMethods);
                }

            }
            catch (Exception ex)
            {
                string errorText = "An error occured while importing order from T-Hub. The process will continue but if problem persists, make sure that database is available.";
                mainProgram.ApplicationStatusUpdate(errorText);
                mainProgram._orderSyncronizationDatabase.LogOrder(1, -1, string.Format("{0} Error Details: {1}", errorText, ex.Message));
            }
        }

        private void PostShipmentToMoldingBox(DataRow ossOrderRow, MainWindow mainProgram, IEnumerable<ShippingMethod> ossShipmentMethods)
        {

            string orderJsonString = ossOrderRow["THubCompleteOrder"].ToString();
            OssShipment[] shipments = new OssShipment[1]
                    {
                        JsonConvert.DeserializeObject<OssShipment>(orderJsonString)
                    };
            string destinationMapping = mainProgram._orderSyncronizationDatabase.LoadShipmentMethodMapping(true, shipments[0].WebShipMethod);
            if (string.IsNullOrEmpty(destinationMapping))
            {
                SetOrderStatusForMissingShipmentmethod(ossOrderRow, "Shipment method mapping does not exist. Please repost this order manually.");
                mainProgram._orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);
                //TODO: Log it
            }
            else 
            {
                ShippingMethod mbShipMethod = ossShipmentMethods.FirstOrDefault(mb => mb.Method == destinationMapping);
                if (mbShipMethod == null || string.IsNullOrEmpty(mbShipMethod.Method)) // Old Mapging is changed and no Longer exist
                {
                    SetOrderStatusForMissingShipmentmethod(ossOrderRow, "Shipment method mapping has been changed on molding box. Please repost this order manually.");
                    mainProgram._orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);
                }
                else
                {
                    shipments[0].ShippingMethodID = mbShipMethod.ID;
                    Shipment[] shipmentsToPost = new Shipment[1];
                    shipmentsToPost[0] = CreateFrom(shipments[0]);
                    DateTime shipmentRequestSentOn = DateTime.Now;
                    Response[] responses = MoldingBoxHelper.PostShipment(client, apiKey, shipmentsToPost);
                    SetOrderStatus(ossOrderRow, shipmentRequestSentOn, mbShipMethod.Method, responses, shipments);
                    mainProgram._orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);
                }
            }

        }
        private Shipment CreateFrom(OssShipment source)
        {
            return new Shipment
            {
                Address1 = source.Address1,
                Address2 = source.Address2,
                CODAmount = source.CODAmount,
                City = source.City,
                Company = source.Company,
                Country = source.Country,
                Custom1 = source.Custom1,
                Custom2 = source.Custom2,
                Custom3 = source.Custom3,
                Custom4 = source.Custom4,
                Custom5 = source.Custom5,
                Custom6 = source.Custom6,
                Email = source.Email,
                FirstName = source.FirstName,
                Items = source.Items,
                LastName = source.LastName,
                OrderID = source.OrderID,
                Orderdate = source.Orderdate,
                Phone = source.Phone,
                ShippingMethodID = source.ShippingMethodID,
                State = source.State,
                Zip = source.Zip
            };
        }
        private void SetOrderStatus(DataRow ossOrderRow, DateTime shipmentRequestSentOn, string MBShipmentMethod, Response[] responses, OssShipment[] shipments)
        {
            Response response = responses[0];
            if (response.MBShipmentID == 0)
            {
                ossOrderRow["SentToMB"] = false;
                ossOrderRow["OrderStatus"] = (int)OSSOrderStatus.Exception;
                ossOrderRow["MBShipmentSubmitError"] = response.ErrorMessage;
            }
            else
            {
                ossOrderRow["SentToMB"] = true;
                ossOrderRow["OrderStatus"] = (int)OSSOrderStatus.InFlight;
                ossOrderRow["MBShipmentId"] = response.MBShipmentID.ToString();
            }
            ossOrderRow["SentToMBOn"] = shipmentRequestSentOn;
            ossOrderRow["MBPostShipmentMessage"] = JsonConvert.SerializeObject(new OssShipmentMessage(apiKey, shipments));
            ossOrderRow["MBPostShipmentResponseMessage"] = JsonConvert.SerializeObject(responses);
            ossOrderRow["MBSuccessfullyReceived"] = response.SuccessfullyReceived;
            ossOrderRow["CancelMessage"] = string.Empty;
            ossOrderRow["MBShipmentMethod"] = MBShipmentMethod;
        }

        private void SetOrderStatusForMissingShipmentmethod(DataRow ossOrderRow, string errorMessage)
        {
            ossOrderRow["SentToMB"] = false;
            ossOrderRow["OrderStatus"] = (int) OSSOrderStatus.Exception;
            ossOrderRow["MBShipmentSubmitError"] = errorMessage;
        }

        #endregion

        #region Moldingbox Status Cycle

        private void AutoSyncMoldingBoxStatuses(MainWindow mainProgram)
        {
            try
            {
                DataTable stagingOrders = mainProgram._orderSyncronizationDatabase.LoadOrdersFromStaging("OssOrderTable", OSSOrderStatus.InFlight);
                foreach (DataRow ossOrderRow in stagingOrders.Rows)
                {
                    CheckAndUpdateOssOrderRowStatus(mainProgram, ossOrderRow);
                }
            }
            catch (Exception ex) 
            {
                string errorText = "An error occured while Checking order status on MoldingBox. The process will continue but if problem persists, make sure that database is available. ";
                mainProgram.ApplicationStatusUpdate(errorText);
                mainProgram._orderSyncronizationDatabase.LogOrder(1, -1, string.Format("{0} Error details: {1}",errorText, ex.Message));                
            }
            
        }

        private void CheckAndUpdateOssOrderRowStatus(MainWindow mainProgram, DataRow ossOrderRow)
        {
            string mbShipmentID = ossOrderRow["MBShipmentId"].ToString();
            string orderId = ossOrderRow["THubOrderId"].ToString();
            if (client == null)
            {
                client = MoldingBoxHelper.GetMoldingBoxClient();
            }
            StatusResponse[] statusResponse = client.Retrieve_Shipment_Status(apiKey, new ArrayOfInt() { int.Parse(mbShipmentID) });
            if (statusResponse[0].ShipmentExists)
            {
                if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.Completed) // Handle in processing
                {
                    mainProgram._orderSyncronizationDatabase.UpdateOrderTrackingAndOssStatus(statusResponse[0], long.Parse(orderId));
                }
                else if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.InFlight || statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.Recieved)
                {
                    mainProgram._orderSyncronizationDatabase.UpdateLastSyncDateOfOrder(long.Parse(orderId));
                }
                else if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.OnHold)
                {
                    mainProgram._orderSyncronizationDatabase.UpdateOrderStatusCanceledOrOnHold(long.Parse(orderId),
                        OSSOrderStatus.OnHold);
                }
                else if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.Canceled)
                {
                    mainProgram._orderSyncronizationDatabase.UpdateOrderStatusCanceledOrOnHold(long.Parse(orderId), OSSOrderStatus.Canceled);
                }
            } 
        }
        #endregion
    }
}
