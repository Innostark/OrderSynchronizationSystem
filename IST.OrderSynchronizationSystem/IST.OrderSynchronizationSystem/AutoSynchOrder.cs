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
        public CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
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
                //try
                //{
                //    mainForm.Invoke(mainForm.reloadGridsDelegate); 
                //}
                //catch (Exception exp)
                //{
                    
                //}
                
                Thread.Sleep(frequency * 60000);
            }            
        }

        public void ProcessMb(Form mainWindow, int frequency)
        {
            MainWindow mainForm = (MainWindow)mainWindow;
            apiKey = mainForm.apiKey;
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
                    PostShipmentToMoldingBox(row, mainProgram);
                }
                mainProgram.ApplicationStatusUpdate("Cycle for Pulling Orders from T-Hub and posting on MB completed.");
            }
            catch (Exception ex)
            {                
                
                string errorText = "An error occured while importing order from T-Hub. The process will continue but if problem persists, make sure that database is available.";
                mainProgram.ApplicationStatusUpdate(errorText);
                //MessageBox.Show(errorText, "Order Synchronization Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                mainProgram._orderSyncronizationDatabase.LogOrder(1, -1, string.Format("{0} Error Details: {1}", errorText, ex.Message));
            }
        }

        private void PostShipmentToMoldingBox(DataRow ossOrderRow, MainWindow mainProgram)
        {

            string orderJsonString = ossOrderRow["THubCompleteOrder"].ToString();
            OssShipment[] shipments = new OssShipment[1]
                    {
                        JsonConvert.DeserializeObject<OssShipment>(orderJsonString)
                    };
            int destinationMapping = mainProgram._orderSyncronizationDatabase.LoadShipmentMethodMapping(true, shipments[0].WebShipMethod);
            if (destinationMapping == -1)
            {
                SetOrderStatusForMissingShipmentmethod(ossOrderRow,
                    "Shipment method mapping does not exist. Please repost this order manually.");
                mainProgram._orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);
                mainProgram._orderSyncronizationDatabase.LogOrder(1, long.Parse(ossOrderRow["THubOrderId"].ToString()),
                    "Mapping missing for order.");
                mainProgram.ApplicationStatusUpdate("Shipment method Mapping missing for order.");
            }
            else
            {
                shipments[0].ShippingMethodID = destinationMapping;
                Shipment[] shipmentsToPost = new Shipment[1];
                shipmentsToPost[0] = CreateFrom(shipments[0], mainProgram);
                DateTime shipmentRequestSentOn = DateTime.Now;
                Response[] responses = MoldingBoxHelper.PostShipment(client, apiKey, shipmentsToPost);
                SetOrderStatus(ossOrderRow, shipmentRequestSentOn, destinationMapping, responses, shipments);
                mainProgram._orderSyncronizationDatabase.UpdateOrderAfterMoldingBoxShipmentRequest(ossOrderRow);
                mainProgram._orderSyncronizationDatabase.LogOrder(1, long.Parse(ossOrderRow["THubOrderId"].ToString()),
                    "Order Successfully posted on Molding Box.");
                mainProgram.ApplicationStatusUpdate("Order successfully shipped to Moldingbox.");

            }

        }
        private Shipment CreateFrom(OssShipment source, MainWindow mainWindow)
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
                Email = string.IsNullOrEmpty(source.Email) ? mainWindow._defaultEmail : source.Email,
                FirstName = source.FirstName,
                Items = source.Items,
                LastName = source.LastName,
                OrderID = source.OrderID,
                Orderdate = DateTime.Now,
                Phone = string.IsNullOrEmpty(source.Phone) ? mainWindow._defaultPhone : source.Phone,
                ShippingMethodID = source.ShippingMethodID,
                State = source.State,
                Zip = source.Zip
            };
        }
        private void SetOrderStatus(DataRow ossOrderRow, DateTime shipmentRequestSentOn, int MBShipmentMethod, Response[] responses, OssShipment[] shipments)
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
                ossOrderRow["MBShipmentSubmitError"] = string.Empty;
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
                mainProgram.ApplicationStatusUpdate("Cycle for Auto-Synchronization with Molding-Box completed.");
            }
            catch (Exception ex) 
            {
                string errorText = "An error occured while Checking order status on MoldingBox. The process will continue but if problem persists, make sure that database is available. ";                
                mainProgram.ApplicationStatusUpdate(errorText);
                //MessageBox.Show(errorText, "Order Synchronization Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mainProgram._orderSyncronizationDatabase.LogOrder(1, -1, string.Format("{0} Error details: {1} Stack-Trace: {2}", errorText, ex.Message, ex.StackTrace));                
            }
            
        }

        private void CheckAndUpdateOssOrderRowStatus(MainWindow mainProgram, DataRow ossOrderRow)
        {
            string mbShipmentID = ossOrderRow["MBShipmentId"].ToString();
            string orderId = ossOrderRow["THubOrderId"].ToString();
            string orderChannelRefNumber = ossOrderRow["THubOrderReferenceNo"].ToString();
            string mbShipmentMethod = ossOrderRow["MBShipmentMethod"].ToString();
            if (client == null)
            {
                client = MoldingBoxHelper.GetMoldingBoxClient();
            }
            StatusResponse[] statusResponse = new StatusResponse[1];
            try
            {
                statusResponse = client.Retrieve_Shipment_Status(apiKey, new ArrayOfInt { int.Parse(mbShipmentID) });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Current status of order is unrecognized"))
                {
                    mainProgram._orderSyncronizationDatabase.UpdateOrderStatusCanceledOrOnHold(long.Parse(orderId),
                        OSSOrderStatus.OnHold, "Current status of order is unrecognized on MoldingBox.");
                    mainProgram._orderSyncronizationDatabase.LogOrder(1, long.Parse(orderId),
                        string.Format("Order status check returns an exceptional response. Response Message: '{0}'",
                            statusResponse[0].ErrorMessage));
                }
                else
                {
                    mainProgram._orderSyncronizationDatabase.LogOrder(1, long.Parse(orderId), string.Format("Order status check returns an exceptional response. Response Message: '{0}'", ex.Message));
                }
                return;
            }            
            
            if (statusResponse[0].ShipmentExists)
            {
                if (statusResponse[0].ShipmentStatusID == (int)OSSOrderStatus.Completed) // Handle in processing
                {
                    string shipVia, shipMethod;
                    string orderJsonString = ossOrderRow["THubCompleteOrder"].ToString();
                    OssShipment[] shipments = new OssShipment[1]
                    {
                        JsonConvert.DeserializeObject<OssShipment>(orderJsonString)
                    };
                    string webShipMethod = shipments[0].WebShipMethod;
                    if (GetMBShipmentDetailsForCompletedOrder(mainProgram, webShipMethod, out shipVia, out shipMethod))
                    {
                        mainProgram._orderSyncronizationDatabase.UpdateOrderTrackingAndOssStatus(statusResponse[0], long.Parse(orderId), orderChannelRefNumber, shipVia, shipMethod);
                    }
                    else
                    {
                        mainProgram._orderSyncronizationDatabase.LogOrder(1, long.Parse(orderId),
                            string.Format("Shipment method mappings has been changed or removed against WebShipMethod: '{0}'. Please create or update the mappings against WebShipMethod: '{1}' so that completed orders are updated back in T-Hub.", webShipMethod, webShipMethod));
                    }
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
                    mainProgram._orderSyncronizationDatabase.UpdateOrderStatusCanceledOrOnHold(long.Parse(orderId), OSSOrderStatus.Canceled, "Order was cancelled by Molding Box.");
                }
                else
                {
                    mainProgram._orderSyncronizationDatabase.UpdateOrderStatusCanceledOrOnHold(long.Parse(orderId), OSSOrderStatus.Exception);
                    mainProgram._orderSyncronizationDatabase.LogOrder(1, long.Parse(orderId), string.Format("Order status check returns an exceptional response. Response Message: '{0}'", statusResponse[0].ErrorMessage));
                }
            } 
        }
        private bool GetMBShipmentDetailsForCompletedOrder(MainWindow mainProgram, string webShipMethod, out string ShipVia, out string ShipMethod)
        {
            ShipVia = ShipMethod = string.Empty;
            DataTable table = mainProgram._orderSyncronizationDatabase.GetShipMappingDetails(webShipMethod);
            if (table.Rows.Count < 1)
            {
                return false;
            }
            ShipVia = table.Rows[0]["MBShipVia"].ToString();
            ShipMethod = table.Rows[0]["MBShipMethod"].ToString();
            return true;
        }
        #endregion
    }
}