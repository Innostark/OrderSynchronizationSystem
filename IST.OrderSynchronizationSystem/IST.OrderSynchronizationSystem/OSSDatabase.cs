using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Transactions;
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
                using (var connection = new SqlConnection(_sourceSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    using (var command = new SqlCommand(SqlResource.source_sql_verify, connection))
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
                using (var connection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    using (var command = new SqlCommand(SqlResource.staging_sql_verify, connection))
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
            var ossShipments = new List<OssShipment>();
            using (var scope = new TransactionScope())
            {
                var lastExecutedTHubOrderId = this.GetLastExecutedTHubOrderId();

                using (
                    var tHubDbConnection =
                        new SqlConnection(_sourceSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    using (
                        var ordersCommand = new SqlCommand(SqlResource.source_sql_PullOrdersFromThub, tHubDbConnection))
                    {
                        ordersCommand.Parameters.Add("@LastExecutedTHubOrderId", SqlDbType.BigInt).Value =
                            lastExecutedTHubOrderId;
                        tHubDbConnection.Open();
                        var orderResults = ordersCommand.ExecuteReader();
                        if (orderResults.HasRows)
                        {
                            while (orderResults.Read())
                            {
                                ossShipments.Add(OssDatabase.ConvertSourceOrderToStagingShipment(orderResults));
                            }
                        }
                        tHubDbConnection.Close();
                    }
                    tHubDbConnection.Open();
                    foreach (var shipment in ossShipments)
                    {
                        var orderItems = new List<Item>();
                        var thubOrderId = shipment.ThubOrderId;
                        using (var orderItemsCommand = new SqlCommand(SqlResource.source_sql_PullOrderItems, tHubDbConnection))
                        {
                            orderItemsCommand.Parameters.AddWithValue("@THubOrderId", thubOrderId);
                            var orderItemResults = orderItemsCommand.ExecuteReader();
                            if (orderItemResults.HasRows)
                            {
                                while (orderItemResults.Read())
                                {
                                    orderItems.Add(OssDatabase.ConvertSourceOrderItemToStagingItem(orderItemResults));
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

        public DataTable LoadOrdersFromStaging(string name)
        {
            var stagingOrdersDataTable = OssDatabase.CreateStagingOrdersTable(name, true);
            using (
                var stagingDbconnection =
                    new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                stagingDbconnection.Open();
                using (var command = new SqlCommand("USPLoadOrdersFromStaging", stagingDbconnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var stagingOrder = command.ExecuteReader();
                    if (stagingOrder.HasRows)
                    {
                        while (stagingOrder.Read())
                        {
                            var orderRow = stagingOrdersDataTable.NewRow();
                            OssDatabase.LoadStagingOrderFromReaderToDataRow(stagingOrder, orderRow);
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
            using (var stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                stagingDbconnection.Open();
                using (var command = new SqlCommand(SqlResource.staging_sql_LastExecutedTHubOrderId, stagingDbconnection))
                {
                    var lastExecutedTHubOrderId = (long)command.ExecuteScalar();
                    stagingDbconnection.Close();
                    return lastExecutedTHubOrderId;
                }
            }
        }

        internal int InsertShipmentsToStaging(List<OssShipment> stagingShipments)
        {
            var numberOfRecordsAffected = int.MinValue;
            var ossOrdersTableTHubLoad = OssDatabase.CreateStagingOrdersTable_THubLoad();
            foreach (var ossShipment in stagingShipments)
            {
                var shipment = OssDatabase.ConvertStagingOrderToMoldingBoxShipment(ossShipment);
                var shipmenJson = JsonConvert.SerializeObject(shipment);
                var ossOrder = OssDatabase.CreateStagingOrderRowFromStagingShipment_THubLoad(ossOrdersTableTHubLoad, ossShipment, shipmenJson);

                ossOrdersTableTHubLoad.Rows.Add(ossOrder);
            }
            using (var transaction = new TransactionScope())
            {
                using (var stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
                {
                    stagingDbconnection.Open();
                    using (
                        var command = new SqlCommand("USPCreateOSSOrders")
                        {
                            CommandType = CommandType.StoredProcedure,
                            Connection = stagingDbconnection
                        })
                    {
                        command.Parameters.AddWithValue("@createOssOrders", ossOrdersTableTHubLoad);

                        numberOfRecordsAffected = command.ExecuteNonQuery();
                    }
                    stagingDbconnection.Close();
                }
                transaction.Complete();
            }

            return numberOfRecordsAffected;
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
                ShippingMethodID = (int)order["ShippingMethodID"],
                Custom1 = order["Custom1"].ToString(),
                Custom2 = order["Custom2"].ToString(),
                Custom3 = order["Custom3"].ToString(),
                Custom4 = order["Custom4"].ToString(),
                Custom5 = order["Custom5"].ToString(),
                Custom6 = order["Custom6"].ToString()
            };
        }

        private static Item ConvertSourceOrderItemToStagingItem(IDataRecord orderItem)
        {
            return new Item()
            {
                SKU = orderItem["SKU"].ToString(),
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

            var shipment = new Shipment();
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
            var ossOrdersTable = new DataTable("OSSOrders");
            ossOrdersTable.Columns.Add("THubOrderId", typeof(long));
            ossOrdersTable.Columns.Add("THubOrderReferenceNo", typeof(string));
            ossOrdersTable.Columns.Add("CreatedOn", typeof(DateTime));
            ossOrdersTable.Columns.Add("THubCompleteOrder", typeof(string));

            return ossOrdersTable;
        }

        private static DataRow CreateStagingOrderRowFromStagingShipment_THubLoad(DataTable stagingOrdersTable, OssShipment stagingShipment, string shipmentJson)
        {
            if (shipmentJson == null) throw new ArgumentNullException("shipmentJson");

            var ossOrder = stagingOrdersTable.NewRow();
            ossOrder["THubOrderId"] = stagingShipment.ThubOrderId;
            ossOrder["THubOrderReferenceNo"] = stagingShipment.OrderID;
            ossOrder["CreatedOn"] = DateTime.Now;
            ossOrder["THubCompleteOrder"] = shipmentJson;
            return ossOrder;
        }

        private static DataTable CreateStagingOrdersTable(string name, bool withTableId)
        {
            var ossOrdersTable = new DataTable(name);
            if (withTableId) ossOrdersTable.Columns.Add("OSSOrderId", typeof(long));
            ossOrdersTable.Columns.Add("THubOrderId", typeof(long));
            ossOrdersTable.Columns.Add("THubOrderReferenceNo", typeof(string));
            ossOrdersTable.Columns.Add("CreatedOn", typeof(DateTime));
            ossOrdersTable.Columns.Add("THubCompleteOrder", typeof (string));
            ossOrdersTable.Columns.Add("SentToMB", typeof(bool));
            ossOrdersTable.Columns.Add("SentToMBOn", typeof(DateTime));
            ossOrdersTable.Columns.Add("MBPostShipmentMessage", typeof(string));
            ossOrdersTable.Columns.Add("MBPostShipmentResponseMessage", typeof(string));
            ossOrdersTable.Columns.Add("MBSuccessfullyReceived", typeof(string));
            ossOrdersTable.Columns.Add("MBShipmentId", typeof(string));
            ossOrdersTable.Columns.Add("MBShipmentSubmitError", typeof(string));
            ossOrdersTable.Columns.Add("MBShipmentIdSubmitedToThub", typeof(bool));
            ossOrdersTable.Columns.Add("MBShipmentIdSubmitedToThubOn", typeof(DateTime));

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
        }
    }
}
