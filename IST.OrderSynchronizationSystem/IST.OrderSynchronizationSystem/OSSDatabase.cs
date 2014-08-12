using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Transactions;
using IST.OrderSynchronizationSystem.MBAPI;

namespace IST.OrderSynchronizationSystem
{
    public class OSSDatabase
    {
        
        private readonly SqlConnectionStringBuilder stagingSqlConnectionConnectionStringBuilder;
        private readonly SqlConnectionStringBuilder sourceSqlConnectionConnectionStringBuilder;
        public OSSDatabase(OSSConnection sourceDatabaseConnection, OSSConnection stagingDatabaseConnection)
        {
            sourceSqlConnectionConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = sourceDatabaseConnection.ServerName,
                UserID = sourceDatabaseConnection.UserName,
                Password = sourceDatabaseConnection.Password,
                InitialCatalog = sourceDatabaseConnection.DatabaseName
            };
            
            stagingSqlConnectionConnectionStringBuilder = new SqlConnectionStringBuilder
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
                using (SqlConnection connection = new SqlConnection(sourceSqlConnectionConnectionStringBuilder.ConnectionString))
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
                using (SqlConnection connection = new SqlConnection(stagingSqlConnectionConnectionStringBuilder.ConnectionString))
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

        public List<Shipment> LoadOrdersAndCreateShipments()
        {
            try
            {
                List<Shipment> shipments = new List<Shipment>();
                using (TransactionScope scope = new TransactionScope())
                {
                    //TODO: Use in where clause
                    DateTime lastExecutionTime;
                    using (SqlConnection stagingDbconnection = new SqlConnection(stagingSqlConnectionConnectionStringBuilder.ConnectionString))
                    {
                        stagingDbconnection.Open();
                        using (SqlCommand command = new SqlCommand(SqlResource.staging_sql_LastExecutionTimeQuery, stagingDbconnection))
                        {
                            var result = command.ExecuteScalar();
                            lastExecutionTime = result == null ? DateTime.Now.Date : DateTime.Parse(string.Format(CultureInfo.InvariantCulture, result.ToString()));
                        }

                        
                    }
                    using (SqlConnection tHubDbConnection = new SqlConnection())
                    {
                        using (SqlCommand command = new SqlCommand(SqlResource.staging_sql_PullOrdersFromThubQuery, tHubDbConnection))
                        {
                            SqlDataReader results = command.ExecuteReader();
                            while (results.Read())
                            {
                                AddRowsToShipmentList(shipments, results);
                            }
                        }
                    }
                }

                return shipments;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static void AddRowsToShipmentList(List<Shipment> shipments, IDataRecord record)
        {
            Shipment shipmentFromDatabase = new Shipment
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
                Country = record["Country"].ToString(),
                Email = record["Email"].ToString(),
                Phone = record["Phone"].ToString(),
                ShippingMethodID = (int)record["ShippingMethodID"],
                Custom1 = record["Custom1"].ToString(),
                Custom2 = record["Custom2"].ToString(),
                Custom3 = record["Custom3"].ToString(),
                Custom4 = record["Custom4"].ToString(),
                Custom5 = record["Custom5"].ToString(),
            };
            shipments.Add(shipmentFromDatabase);
        }
    }
}
