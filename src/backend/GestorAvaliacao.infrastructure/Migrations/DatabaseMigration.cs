using Dapper;
using GestorAvaliacao.Domain.Enums;
using Microsoft.Data.SqlClient;
using MySqlConnector;


namespace GestorAvaliacao.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static void Migrate(string connectionString, DatabaseEnvironment databaseType)
        {
            if (databaseType == DatabaseEnvironment.Development)
            {
                EnsureDatabaseCreatedMySQL(connectionString);
            }
            else if (databaseType == DatabaseEnvironment.Homologation)
            {
                EnsureDatabaseCreatedSqlServer(connectionString);
            }
        }

        private static void EnsureDatabaseCreatedMySQL(string connectionString)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
            string databaseName = connectionStringBuilder.Database;
            connectionStringBuilder.Remove("Database");

            using (var dbConnection = new MySqlConnection(connectionStringBuilder.ConnectionString))
            {
                string query = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name";
                var parameters = new DynamicParameters();
                parameters.Add("name", databaseName);

                var records = dbConnection.Query(query, parameters);
                if (!records.Any())
                {
                    dbConnection.Execute($"CREATE DATABASE `{databaseName}`;");
                }
            }
        }

        private static void EnsureDatabaseCreatedSqlServer(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            string databaseName = connectionStringBuilder.InitialCatalog;
            connectionStringBuilder.InitialCatalog = ""; 

            using (var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                string query = "SELECT * FROM sys.databases WHERE name = @name";
                var parameters = new DynamicParameters();
                parameters.Add("name", databaseName);

                var records = dbConnection.Query(query, parameters);
                if (!records.Any())
                {
                    dbConnection.Execute($"CREATE DATABASE [{databaseName}];");
                }
            }
        }
    }
}
