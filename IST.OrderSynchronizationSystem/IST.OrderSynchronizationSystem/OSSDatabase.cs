using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Transactions;
using IST.OrderSynchronizationSystem.MBAPI;
using IST.OrderSynchronizationSystem.Models;

namespace IST.OrderSynchronizationSystem
{
    public class OssDatabase
    {
        
        private readonly SqlConnectionStringBuilder _stagingSqlConnectionConnectionStringBuilder;
        private readonly SqlConnectionStringBuilder _sourceSqlConnectionConnectionStringBuilder;
        private bool _selectAllOrdersFromTHubAsStagingIsEmpty = false;
        
        
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

        public List<OssShipment> GetShipmentsFromThub()
        {
            try
            {
                var shipments = new List<OssShipment>();
                using (new TransactionScope())
                {
                    //TODO: Use in where clause
                    var lastExecutionTime = this.GetLastOrdersSyncWithTHub();

                    using (
                        var tHubDbConnection =
                            new SqlConnection(_sourceSqlConnectionConnectionStringBuilder.ConnectionString))
                    {

                        using (
                            var ordersCommand = new SqlCommand(SqlResource.source_sql_PullOrdersFromThub,
                                tHubDbConnection))
                        {
                            ordersCommand.Parameters.Add("@LastExecutionTime", SqlDbType.DateTime).Value =
                                lastExecutionTime;

                            tHubDbConnection.Open();
                            var orderResults = ordersCommand.ExecuteReader();
                            if (orderResults.HasRows)
                            {
                                using (var stagingDbConnection = new SqlConnection())
                                {
                                    while (orderResults.Read())
                                    {
                                        var shipment = OssDatabase.ConvertSourceOrderToStagingShipment(orderResults);
                                        
                                        shipments.Add(shipment);
                                    }
                                }
                            }
                            tHubDbConnection.Close();
                        }

                        foreach (var shipment in shipments)
                        {
                            tHubDbConnection.Open();
                            var orderItems = new List<Item>();
                            var thubOrderId = shipment.ThubOrderId;
                            using (var orderItemsCommand = new SqlCommand(SqlResource.source_sql_PullOrderItems, tHubDbConnection))
                            {
                                orderItemsCommand.Parameters.AddWithValue("@THubOrderId", thubOrderId);
                                var orderItemResults = orderItemsCommand.ExecuteReader();
                                if (orderItemResults.HasRows)
                                {
                                    orderItems.Add(OssDatabase.ConvertSourceOrderItemToStaging(orderItemResults));
                                }
                                shipment.Items = orderItems.ToArray();
                            }
                        }
                        tHubDbConnection.Close();
                    }
                }

                return shipments;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private DateTime GetLastOrdersSyncWithTHub()
        {
            using (var stagingDbconnection = new SqlConnection(_stagingSqlConnectionConnectionStringBuilder.ConnectionString))
            {
                stagingDbconnection.Open();
                using (var command = new SqlCommand(SqlResource.staging_sql_LastExecutionTimeQuery, stagingDbconnection))
                {
                    var lastOrdersSyncWithTHub = command.ExecuteScalar();
                    stagingDbconnection.Close();
                    return (lastOrdersSyncWithTHub == DBNull.Value ? Convert.ToDateTime("1/1/1753 12:00:00") : (DateTime)lastOrdersSyncWithTHub);
                }
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
                ShippingMethodID = (int)order["ShippingMethodID"],
                Custom1 = order["Custom1"].ToString(),
                Custom2 = order["Custom2"].ToString(),
                Custom3 = order["Custom3"].ToString(),
                Custom4 = order["Custom4"].ToString(),
                Custom5 = order["Custom5"].ToString(),
                Custom6 = order["Custom6"].ToString()
            };
        }

        private static Item ConvertSourceOrderItemToStaging(IDataRecord orderItem)
        {
            return new Item()
            {
                SKU = orderItem["SKU"].ToString(),
                Description = orderItem["Description"].ToString(),
                Quantity = (int) orderItem["Quantity"],
                Custom1 = orderItem["Custom1"].ToString(),
                Custom2 = orderItem["Custom2"].ToString(),
                Custom3 = orderItem["Custom3"].ToString(),
                Custom4 = orderItem["Custom4"].ToString(),
                Custom5 = orderItem["Custom5"].ToString(),
                Custom6 = orderItem["Custom6"].ToString()
            };
        }

        

        private static void AddRowsToShipmentList(List<Shipment> shipments, IDataRecord record)
        {
            var shipmentFromDatabase = new Shipment
            {
                OrderID = record["OrderID"].ToString(),
                Orderdate = (DateTime)record["Orderdate"],
                Company = record["Company"].ToString(),
                FirstName = record["FirstName"].ToString(),
                LastName = record["LastName"].ToString(),
                Address1 = record["Address1"].ToString(),
                Address2 = record["Address2"].ToString(),
                City = record["City"].ToString(),
                State = record["State"].ToString(),
                Zip = record["Zip"].ToString(),
                Country = record["Country"].ToString(),
                Email = record["Email"].ToString(),
                Phone = record["Phone"].ToString(),
                ShippingMethodID = (int)record["ShippingMethodID"],
                Custom1 = record["Custom1"].ToString(),
                Custom2 = record["Custom2"].ToString(),
                Custom3 = record["Custom3"].ToString(),
                Custom4 = record["Custom4"].ToString(),
                Custom5 = record["Custom5"].ToString(),
                Custom6 = record["Custom6"].ToString()
            };
            shipments.Add(shipmentFromDatabase);
        }
    }
}
