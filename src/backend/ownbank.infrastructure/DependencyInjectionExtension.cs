﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ownbank.Domain.Enums;
using ownbank.Domain.Repositories.User;
using ownbank.Infrastructure.DataAccess;
using ownbank.Infrastructure.DataAccess.Repositories;

namespace ownbank.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseType = configuration.GetConnectionString("DatabaseType");

            var databaseTypeEnum = (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseType);

            if(databaseTypeEnum == DatabaseType.MySql)
                AddDbContext_MySql(services, configuration);
            else
                AddDbContext_SqlServer(services, configuration);

            AddRepositories(services);
        }

        private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<OwnbankDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }
        private static void AddDbContext_MySql(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySql");

            var serverVersion = new MySqlServerVersion(new Version(8,0,36));

            services.AddDbContext<OwnbankDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseMySql(connectionString, serverVersion);
            });
        }

        private static void AddRepositories(IServiceCollection services) 
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }

    }
}