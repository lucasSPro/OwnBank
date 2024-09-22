using Dapper;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace GestorAvaliacao.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static void Migrate(string connectionString, IServiceProvider serviceProvider)
        {
            EnsureDatabaseCreated(connectionString);

            MigrationDatabase(serviceProvider);
        }

        private static void EnsureDatabaseCreated(string connectionString)
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

        private static void MigrationDatabase(IServiceProvider serviceProvider)
        {
            try
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

                runner.ListMigrations();
                runner.MigrateUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar a migration: {ex.Message}");
            }
           
        }

    }
}
