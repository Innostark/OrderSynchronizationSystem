using System;
using System.Data.SqlClient;

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
                    using (SqlCommand command = new SqlCommand("Select count(*) from Orders", connection))
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
                    using (SqlCommand command = new SqlCommand("Select count(*) from OSSOrders", connection))
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

    }
}
