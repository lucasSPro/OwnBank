using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ownbank.Domain.Repositories.User;
using ownbank.Infrastructure.DataAccess;
using ownbank.Infrastructure.DataAccess.Repositories;

namespace ownbank.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext_MySql(services);
            AddRepositories(services);
        }

        private static void AddDbContext_SqlServer(IServiceCollection services)
        {
            var connectionString = "Data Source=Desktop-Dell\\SQLEXPRESS;Initial Catalog=ownbank;User ID=sa;Password=123456lcs; Truted_Connection=true;Encrypt=true;trustServerCertificate=true";

            services.AddDbContext<OwnbankDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }
        private static void AddDbContext_MySql(IServiceCollection services)
        {
            var connectionString = "Server= localhost; Database= ownbank; Uid=root;Pwd=123456lcs";
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
