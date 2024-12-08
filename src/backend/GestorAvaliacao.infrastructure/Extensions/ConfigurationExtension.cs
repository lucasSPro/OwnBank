using GestorAvaliacao.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace GestorAvaliacao.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static bool IsUnitTestEnviroment(this IConfiguration configuration) {
            var retorno = configuration.GetValue<bool>("Settings:InMemoryTest"); //"InMemoryTest": true,
            return retorno;
        }

        public static DatabaseEnvironment DataEnvironment(this IConfiguration configuration)
        {
            var databaseEnvironment = configuration.GetConnectionString("databaseEnvironment")!;

            return (DatabaseEnvironment)Enum.Parse(typeof(DatabaseEnvironment), databaseEnvironment);
        }
        public static string ConnectionString(this IConfiguration configuration)
        {
            var databaseEnvironment = configuration.DataEnvironment();

            switch (databaseEnvironment)
            {
                case DatabaseEnvironment.Development:
                    return configuration.GetConnectionString("Development")!;
                case DatabaseEnvironment.Homologation:
                    return configuration.GetConnectionString("Homologation")!;
                case DatabaseEnvironment.Prodution:
                    return configuration.GetConnectionString("Prodution")!;
                default:
                    return configuration.GetConnectionString("Development")!;
            }
        }
    }
}
