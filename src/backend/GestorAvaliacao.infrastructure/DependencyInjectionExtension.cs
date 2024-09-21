using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestorAvaliacao.Domain.Enums;
using GestorAvaliacao.Domain.Repositories.User;
using GestorAvaliacao.Infrastructure.DataAccess;
using GestorAvaliacao.Infrastructure.DataAccess.Repositories;
using GestorAvaliacao.Infrastructure.Extensions;

namespace GestorAvaliacao.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseEnviroment = configuration.DataEnvironment();

            if(databaseEnviroment == DatabaseEnvironment.Development)
                AddDbContext_MySql(services, configuration);
            else
                AddDbContext_SqlServer(services, configuration);

            AddRepositories(services);
        }

        private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddDbContext<GestorAvaliacaoDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }
        private static void AddDbContext_MySql(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            var serverVersion = new MySqlServerVersion(new Version(8,0,36));

            services.AddDbContext<GestorAvaliacaoDBContext>(dbContextOptions =>
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
