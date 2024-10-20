using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GestorAvaliacao.Domain.Repositories.User;
using GestorAvaliacao.Infrastructure.DataAccess;
using GestorAvaliacao.Infrastructure.DataAccess.Repositories;
using GestorAvaliacao.Infrastructure.Extensions;
using FluentMigrator.Runner;
using System.Reflection;
using GestorAvaliacao.Domain.Repositories;

namespace GestorAvaliacao.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
 
            AddDbContext(services, configuration);
            AddFluentMigrations(services, configuration);
            AddRepositories(services);

        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddDbContext<GestorAvaliacaoDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }
    
        private static void AddRepositories(IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
        private static void AddFluentMigrations(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("GestorAvaliacao.Infrastructure")).For.All(); 
            });

        }

    }
}
