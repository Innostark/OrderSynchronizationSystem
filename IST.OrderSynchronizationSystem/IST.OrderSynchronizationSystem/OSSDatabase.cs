using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using IST.OrderSynchronizationSystem.GUI;
using IST.OrderSynchronizationSystem.MBAPI;
using IST.OrderSynchronizationSystem.Models;
using Newtonsoft.Json;

namespace IST.OrderSynchronizationSystem
{
    public class OssDatabase
    {
        
        private readonly SqlConnectionStringBuilder _stagingSqlConnectionConnectionStringBuilder;
        private readonly SqlConnectionStringBuilder _sourceSqlConnectionConnectionStringBuilder;
        
        
        public OssDatabase(OSSConnection sourceDatabaseConnection, OSSConnection stagingDatabaseConnection)
        {
            _sourceSqlConnectionConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = sourceDatabaseConnection.ServerName,
                UserID = sourceDatabaseConnection.UserName,
                Password = sourceDatabaseConnection.Password,
                InitialCatalog = sourceDatabaseConnection.DatabaseName
            };
            
            _stagingSqlConnectionConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = stagingDatabaseConnection.ServerName,
                UserID = stagingDatabaseConnection.UserName,
                Password = stagingDatabaseConnection.Password,
                InitialCatalog = stagingDatabaseConnection.DatabaseName
            };

            
        }
        public bool VarifySourceDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_sourceSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlResource.source_sql_verify, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool VarifyStagingDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlResource.staging_sql_verify, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<OssShipment> LoadShipmentsFromThub()
        {
            List<OssShipment> ossShipments = new List<OssShipment>();
            using (TransactionScope scope = new TransactionScope())
            {
                //TODO: long lastExecutedTHubOrderId = GetLastExecutedTHubOrderId();

                using (SqlConnection tHubDbConnection = new SqlConnection(_sourceSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    using (SqlCommand ordersCommand = new SqlCommand(SqlResource.source_sql_PullOrdersFromThub, tHubDbConnection))
                    {
                        tHubDbConnection.Open();
                        SqlDataReader orderResults = ordersCommand.ExecuteReader();
                        if (orderResults.HasRows)
                        {
                            while (orderResults.Read())
                            {
                                ossShipments.Add(ConvertSourceOrderToStagingShipment(orderResults));
                            }
                        }
                        tHubDbConnection.Close();
                    }
                    tHubDbConnection.Open();
                    foreach (OssShipment shipment in ossShipments)
                    {
                        List<Item> orderItems = new List<Item>();
                        long thubOrderId = shipment.ThubOrderId;
                        using (SqlCommand orderItemsCommand = new SqlCommand(SqlResource.source_sql_PullOrderItems, tHubDbConnection))
                        {
                            orderItemsCommand.Parameters.AddWithValue("@THubOrderId", thubOrderId);
                            SqlDataReader orderItemResults = orderItemsCommand.ExecuteReader();
                            if (orderItemResults.HasRows)
                            {
                                while (orderItemResults.Read())
                                {
                                    orderItems.Add(ConvertSourceOrderItemToStagingItem(orderItemResults));
                                }
                                shipment.Items = orderItems.ToArray();
                            }
                            orderItemResults.Close();
                        }
                    }
                    tHubDbConnection.Close();
                }
                scope.Complete();
            }
            
            return ossShipments;
        }

        private void LogOrder(int LogType, long OrderId, string LogText)
        {
            //source_sql_Insert_Log
            using (
                SqlConnection tHubDbConnection =
                    new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand logCommand = new SqlCommand(SqlResource.source_sql_Insert_Log, tHubDbConnection))
                {
                    logCommand.Parameters.AddWithValue("@LogTypeId", LogType);
                    logCommand.Parameters.AddWithValue("@OrderId", OrderId);
                    logCommand.Parameters.AddWithValue("@LogText", LogText);
                    logCommand.Parameters.AddWithValue("@CreatedOn", DateTime.Now);

                    tHubDbConnection.Open();
                    int logCreated = logCommand.ExecuteNonQuery();
                    tHubDbConnection.Close();
                }
            }
        }
        public DataTable LoadOrdersFromStaging(string name, OSSOrderStatus status)
        {
            DataTable stagingOrdersDataTable = CreateStagingOrdersTable(name, true);
            using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                stagingDbconnection.Open();
                using (SqlCommand command = new SqlCommand("USPLoadOrdersFromStaging", stagingDbconnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderStatus", (int) status);
                    SqlDataReader stagingOrder = command.ExecuteReader();
                    if (stagingOrder.HasRows)
                    {
                        while (stagingOrder.Read())
                        {
                            DataRow orderRow = stagingOrdersDataTable.NewRow();
                            LoadStagingOrderFromReaderToDataRow(stagingOrder, orderRow);
                            stagingOrdersDataTable.Rows.Add(orderRow);
                        }
                    }

                }
                stagingDbconnection.Close();
            }

            return stagingOrdersDataTable;
        }

        private long GetLastExecutedTHubOrderId()
        {
            using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                stagingDbconnection.Open();
                using (SqlCommand command = new SqlCommand(SqlResource.staging_sql_LastExecutedTHubOrderId, stagingDbconnection))
                {
                    long lastExecutedTHubOrderId = (long)command.ExecuteScalar();
                    stagingDbconnection.Close();
                    return lastExecutedTHubOrderId;
                }
            }
        }

        internal int InsertShipmentsToStaging(List<OssShipment> stagingShipments)
        {
            int numberOfRecordsAffected = int.MinValue;
            DataTable ossOrdersTableTHubLoad = CreateStagingOrdersTable_THubLoad();
            foreach (OssShipment ossShipment in stagingShipments)
            {
                //Shipment shipment = ConvertStagingOrderToMoldingBoxShipment(ossShipment);
                string shipmenJson = JsonConvert.SerializeObject(ossShipment);
                DataRow ossOrder = CreateStagingOrderRowFromStagingShipment_THubLoad(ossOrdersTableTHubLoad, ossShipment, shipmenJson);

                ossOrdersTableTHubLoad.Rows.Add(ossOrder);
            }
            using (TransactionScope transaction = new TransactionScope())
            {

                using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    stagingDbconnection.Open();
                    foreach (OssShipment ossShipment in stagingShipments)
                    {
                        LogOrder(1, ossShipment.ThubOrderId, "Order Created on staging.");
                    }
                    
                    using (SqlCommand command = new SqlCommand("USPCreateOSSOrders", stagingDbconnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@createOssOrders", ossOrdersTableTHubLoad);
                        numberOfRecordsAffected = command.ExecuteNonQuery();
                    }
                    stagingDbconnection.Close();
                }
                transaction.Complete();
            }
            return numberOfRecordsAffected;
        }

        public void UpdateLastSyncDateOfOrder(long OssOrderId)
        {
            using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                stagingDbconnection.Open();
                using (SqlCommand command = new SqlCommand(SqlResource.source_sql_UpdateOrderSyncStatus, stagingDbconnection))
                {
                    command.Parameters.AddWithValue("@DateTimeNow", DateTime.Now);
                    command.Parameters.AddWithValue("@THubOrderId", OssOrderId);
                    var rowsUpdate = command.ExecuteNonQuery();
                }
                stagingDbconnection.Close();
            }            
        }

        public void UpdateOrderTrackingAndOssStatus(StatusResponse response, long OrderKey)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection sourceConnection =
                    new SqlConnection(_sourceSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    using (
                        SqlCommand command = new SqlCommand(SqlResource.staging_sql_InsertShipmentTrackingDetails,
                            sourceConnection))
                    {
                        command.Parameters.AddWithValue("@OrderKey", OrderKey);
                        command.Parameters.AddWithValue("@TrackingUrl", response.TrackingURL);
                        command.Parameters.AddWithValue("@TrackingNumber", response.TrackingNumber);
                        command.Parameters.AddWithValue("@ShipmentDate", DateTime.Now);
                        
                        sourceConnection.Open();
                        var itemsInserted = command.ExecuteNonQuery();
                    }

                }
                using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    stagingDbconnection.Open();
                    using (SqlCommand command = new SqlCommand(SqlResource.source_sql_UpdateOrderCompleted, stagingDbconnection))
                    {                        
                        command.Parameters.AddWithValue("@DateTimeNow", DateTime.Now);
                        command.Parameters.AddWithValue("@OrderStatus", (short)OSSOrderStatus.Completed);
                        command.Parameters.AddWithValue("@THubOrderId", OrderKey);                        
                        var rowsUpdate = command.ExecuteNonQuery();
                    }
                    stagingDbconnection.Close();
                }
                scope.Complete();
            }
        }

        public void UpdateOrderStatusCanceledOrOnHold(long OrderKey, OSSOrderStatus orderStatus)
        {
            using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                stagingDbconnection.Open();
                using (SqlCommand command = new SqlCommand(SqlResource.source_sql_UpdateOrderCompleted, stagingDbconnection))
                {                    
                    command.Parameters.AddWithValue("@DateTimeNow", DateTime.Now);
                    command.Parameters.AddWithValue("@OrderStatus", (short)orderStatus);
                    command.Parameters.AddWithValue("@THubOrderId", OrderKey);
                    var rowsUpdate = command.ExecuteNonQuery();
                }
                stagingDbconnection.Close();
            }

        }


        private static OssShipment ConvertSourceOrderToStagingShipment(IDataRecord order)
        {
            return new OssShipment
            {
                ThubOrderId = (long) order["THubOrderID"],
                OrderID = order["OrderID"].ToString(),
                Orderdate = (DateTime)order["Orderdate"],
                Company = order["Company"].ToString(),
                FirstName = order["FirstName"].ToString(),
                LastName = order["LastName"].ToString(),
                Address1 = order["Address1"].ToString(),
                Address2 = order["Address2"].ToString(),
                City = order["City"].ToString(),
                State = order["State"].ToString(),
                Zip = order["Zip"].ToString(),
                Country = order["Country"].ToString(),
                Email = order["Email"].ToString(),
                Phone = order["Phone"].ToString(),
                WebShipMethod = order["WebShipMethod"].ToString(),
                Custom1 = order["Custom1"].ToString(),
                Custom2 = order["Custom2"].ToString(),
                Custom3 = order["Custom3"].ToString(),
                Custom4 = order["Custom4"].ToString(),
                Custom5 = order["Custom5"].ToString(),
                Custom6 = order["Custom6"].ToString()
            };
        }

        public void ReloadShipmentToStaging()
        {
            OssShipment ossShipment = new OssShipment();
            #region Load From T-Hub

            using (SqlConnection tHubDbConnection = new SqlConnection(_sourceSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand ordersCommand = new SqlCommand(SqlResource.source_sql_PullOrdersFromThub, tHubDbConnection))
                {
                    tHubDbConnection.Open();
                    SqlDataReader orderResults = ordersCommand.ExecuteReader();
                    if (orderResults.HasRows)
                    {
                        while (orderResults.Read())
                        {
                            ossShipment = ConvertSourceOrderToStagingShipment(orderResults);
                        }
                    }
                    tHubDbConnection.Close();
                }
                tHubDbConnection.Open();
                    List<Item> orderItems = new List<Item>();
                    long thubOrderId = ossShipment.ThubOrderId;
                    using (SqlCommand orderItemsCommand = new SqlCommand(SqlResource.source_sql_PullOrderItems, tHubDbConnection))
                    {
                        orderItemsCommand.Parameters.AddWithValue("@THubOrderId", thubOrderId);
                        SqlDataReader orderItemResults = orderItemsCommand.ExecuteReader();
                        if (orderItemResults.HasRows)
                        {
                            while (orderItemResults.Read())
                            {
                                orderItems.Add(ConvertSourceOrderItemToStagingItem(orderItemResults));
                            }
                            ossShipment.Items = orderItems.ToArray();
                        }
                        orderItemResults.Close();
                    }
                tHubDbConnection.Close();
            }

            using (SqlConnection stagingConnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand updateOrderCommand = new SqlCommand(SqlResource.source_sql_UpdateOssOrder, stagingConnection))
                {
                    string shipmenJson = JsonConvert.SerializeObject(ossShipment);
                    updateOrderCommand.Parameters.AddWithValue("@CompleteOrder", shipmenJson);
                    updateOrderCommand.Parameters.AddWithValue("@OssOrderId", ossShipment.OrderID);
                    stagingConnection.Open();
                    int rowsAffected = updateOrderCommand.ExecuteNonQuery();
                }
            }
            #endregion

        }

        private static Item ConvertSourceOrderItemToStagingItem(IDataRecord orderItem)
        {
            //TODO: Replace the Hard Coded SKU with live
            return new Item()
            {
                SKU = "SKU1",//SKU = orderItem["SKU"].ToString()
                Description = orderItem["Description"].ToString(),
                Quantity = (int)orderItem["Quantity"],
                Custom1 = orderItem["Custom1"].ToString(),
                Custom2 = orderItem["Custom2"].ToString(),
                Custom3 = orderItem["Custom3"].ToString(),
                Custom4 = orderItem["Custom4"].ToString(),
                Custom5 = orderItem["Custom5"].ToString(),
                Custom6 = orderItem["Custom6"].ToString()
            };
        }

        private static Shipment ConvertStagingOrderToMoldingBoxShipment(OssShipment stagingShipment)
        {
            if (stagingShipment == null) throw new ArgumentNullException("stagingShipment");

            Shipment shipment = new Shipment();
            shipment.OrderID = stagingShipment.OrderID;
            shipment.Orderdate = stagingShipment.Orderdate;
            shipment.Company = stagingShipment.Company;
            shipment.FirstName = stagingShipment.FirstName;
            shipment.LastName = stagingShipment.LastName;
            shipment.Address1 = stagingShipment.Address1;
            shipment.Address2 = stagingShipment.Address2;
            shipment.City = stagingShipment.City;
            shipment.State = stagingShipment.State;
            shipment.Zip = stagingShipment.Zip;
            shipment.Country = stagingShipment.Country;
            shipment.Email = stagingShipment.Email;
            shipment.ShippingMethodID = stagingShipment.ShippingMethodID;
            shipment.CODAmount = stagingShipment.CODAmount;
            shipment.Custom1 = stagingShipment.Custom1;
            shipment.Custom2 = stagingShipment.Custom2;
            shipment.Custom3 = stagingShipment.Custom3;
            shipment.Custom4 = stagingShipment.Custom4;
            shipment.Custom5 = stagingShipment.Custom5;
            shipment.Custom6 = stagingShipment.Custom6;
            shipment.Items = stagingShipment.Items;
            return shipment;
        }

        private static DataTable CreateStagingOrdersTable_THubLoad()
        {
            DataTable ossOrdersTable = new DataTable("OSSOrders");
            ossOrdersTable.Columns.Add("THubOrderId", typeof(long));
            ossOrdersTable.Columns.Add("THubOrderReferenceNo", typeof(string));
            ossOrdersTable.Columns.Add("CreatedOn", typeof(DateTime));            
            ossOrdersTable.Columns.Add("THubCompleteOrder", typeof(string));
            ossOrdersTable.Columns.Add("OrderStatus", typeof(short));
            return ossOrdersTable;
        }

        private static DataRow CreateStagingOrderRowFromStagingShipment_THubLoad(DataTable stagingOrdersTable, OssShipment stagingShipment, string shipmentJson)
        {
            if (shipmentJson == null) throw new ArgumentNullException("shipmentJson");

            DataRow ossOrder = stagingOrdersTable.NewRow();
            ossOrder["THubOrderId"] = stagingShipment.ThubOrderId;
            ossOrder["OrderStatus"] = (short)OSSOrderStatus.New;
            ossOrder["THubOrderReferenceNo"] = stagingShipment.OrderID;
            ossOrder["CreatedOn"] = DateTime.Now;
            ossOrder["THubCompleteOrder"] = shipmentJson;
            return ossOrder;
        }

        private static DataTable CreateStagingOrdersTable(string name, bool withTableId)
        {
            DataTable ossOrdersTable = new DataTable(name);
            if (withTableId) ossOrdersTable.Columns.Add("OSSOrderId", typeof(long));
            ossOrdersTable.Columns.Add("THubOrderId", typeof(long));
            ossOrdersTable.Columns.Add("THubOrderReferenceNo", typeof(string));
            ossOrdersTable.Columns.Add("OrderStatus", typeof(string));
            ossOrdersTable.Columns.Add("CreatedOn", typeof(DateTime));
            ossOrdersTable.Columns.Add("THubCompleteOrder", typeof(string));
            ossOrdersTable.Columns.Add("SentToMB", typeof(bool));
            ossOrdersTable.Columns.Add("SentToMBOn", typeof(DateTime));
            ossOrdersTable.Columns.Add("MBPostShipmentMessage", typeof(string));
            ossOrdersTable.Columns.Add("MBPostShipmentResponseMessage", typeof(string));
            ossOrdersTable.Columns.Add("MBSuccessfullyReceived", typeof(string));
            ossOrdersTable.Columns.Add("MBShipmentId", typeof(string));
            ossOrdersTable.Columns.Add("MBShipmentSubmitError", typeof(string));
            ossOrdersTable.Columns.Add("MBShipmentIdSubmitedToThub", typeof(bool));
            ossOrdersTable.Columns.Add("MBShipmentIdSubmitedToThubOn", typeof(DateTime));

            ossOrdersTable.Columns.Add("LastSyncWithMBOn", typeof(DateTime));
            ossOrdersTable.Columns.Add("THubUpdatedOn", typeof(DateTime));
            ossOrdersTable.Columns.Add("MBTrackingNumber", typeof(string));
            ossOrdersTable.Columns.Add("CancelMessage", typeof(string));


            

            return ossOrdersTable;
        }

        private static void LoadStagingOrderFromReaderToDataRow(IDataRecord stagingOrder, DataRow stagingRow)
        {
            stagingRow["OSSOrderId"] = stagingOrder["OSSOrderId"];
            stagingRow["THubOrderId"] = stagingOrder["THubOrderId"];
            stagingRow["THubOrderReferenceNo"] = stagingOrder["THubOrderReferenceNo"];
            stagingRow["CreatedOn"] = stagingOrder["CreatedOn"];
            stagingRow["THubCompleteOrder"] = stagingOrder["THubCompleteOrder"];
            stagingRow["SentToMB"] = stagingOrder["SentToMB"];
            stagingRow["SentToMBOn"] = stagingOrder["SentToMBOn"];
            stagingRow["MBPostShipmentMessage"] = stagingOrder["MBPostShipmentMessage"];
            stagingRow["MBPostShipmentResponseMessage"] = stagingOrder["MBPostShipmentResponseMessage"];
            stagingRow["MBSuccessfullyReceived"] = stagingOrder["MBSuccessfullyReceived"];
            stagingRow["MBShipmentId"] = stagingOrder["MBShipmentId"];
            stagingRow["MBShipmentSubmitError"] = stagingOrder["MBShipmentSubmitError"];
            stagingRow["MBShipmentIdSubmitedToThub"] = stagingOrder["MBShipmentIdSubmitedToThub"];
            stagingRow["MBShipmentIdSubmitedToThubOn"] = stagingOrder["MBShipmentIdSubmitedToThubOn"];
            stagingRow["CancelMessage"] = stagingOrder["CancelMessage"];
            stagingRow["OrderStatus"] = stagingOrder["OrderStatus"] != null ? ((OSSOrderStatus)(int.Parse(stagingOrder["OrderStatus"].ToString()))).ToString() : string.Empty;
            stagingRow["LastSyncWithMBOn"] = stagingOrder["LastSyncWithMBOn"];
        }

        internal int UpdateOrderAfterMoldingBoxShipmentRequest(DataRow ossOrderRow)
        {
            int recordsUpdated = int.MinValue;
            using (TransactionScope transaction = new TransactionScope())
            {
                using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    stagingDbconnection.Open();
                    using (
                        SqlCommand command = new SqlCommand("USPUpdateOrderAfterMoldingBoxShipmentRequest")
                        {
                            CommandType = CommandType.StoredProcedure,
                            Connection = stagingDbconnection
                        })
                    {
                        command.Parameters.AddWithValue("@OSSOrderId", ossOrderRow["OSSOrderId"]);
                        command.Parameters.AddWithValue("@SentToMB", ossOrderRow["SentToMB"]);
                        command.Parameters.AddWithValue("@SentToMBOn", ossOrderRow["SentToMBOn"]);
                        command.Parameters.AddWithValue("@MBPostShipmentMessage", ossOrderRow["MBPostShipmentMessage"]);
                        command.Parameters.AddWithValue("@MBPostShipmentResponseMessage", ossOrderRow["MBPostShipmentResponseMessage"]);
                        command.Parameters.AddWithValue("@MBSuccessfullyReceived", ossOrderRow["MBSuccessfullyReceived"]);
                        command.Parameters.AddWithValue("@MBShipmentId", ossOrderRow["MBShipmentId"]);
                        command.Parameters.AddWithValue("@MBShipmentSubmitError", ossOrderRow["MBShipmentSubmitError"]);
                        command.Parameters.AddWithValue("@OrderStatus", ossOrderRow["OrderStatus"]);
                        command.Parameters.AddWithValue("@CancelMessage", ossOrderRow["CancelMessage"]);

                        recordsUpdated = command.ExecuteNonQuery();
                    }
                    stagingDbconnection.Close();
                }
                transaction.Complete();
            }

            return recordsUpdated;
        }

        public string LoadShipmentMethodMapping(bool thubToMoldingBox, string sourceShipmentMethod)
        {
            using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SqlResource.staging_get_Shipment_Mapping_ThubToMoldingBox, stagingDbconnection))
                {
                    command.Parameters.AddWithValue("@SourceShipment", sourceShipmentMethod);
                    command.Parameters.AddWithValue("@THubToMbFlag", thubToMoldingBox);

                    stagingDbconnection.Open();

                    object results = command.ExecuteScalar();
                    stagingDbconnection.Close();
                    if (results == null)
                        return string.Empty;
                    return (string) results;                    
                }
            }
        }

        public bool SaveThubToMbMapping(string sourceShipMethod, string destinationShipMethod, bool THubToMbMap)
        {
            using (SqlConnection stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(SqlResource.staging_sql_InsertTHubToMbMapping, stagingDbconnection))
                {
                    command.Parameters.AddWithValue("@SourceShipMethod", sourceShipMethod);
                    command.Parameters.AddWithValue("@DestinationShipMethod", destinationShipMethod);
                    command.Parameters.AddWithValue("@THubToMBMap", THubToMbMap);
                    stagingDbconnection.Open();
                    return command.ExecuteNonQuery() > 0;                    
                }
            }
        }


    }
}
