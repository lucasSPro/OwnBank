using GestorAvaliacao.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorAvaliacao.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {

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
                default:
                return configuration.GetConnectionString("Homologation")!;
            }
        }
    }
}
