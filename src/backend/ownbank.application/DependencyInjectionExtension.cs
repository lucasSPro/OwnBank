using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ownbank.Application.Services.AutoMapper;
using ownbank.Application.Services.Cryptography;
using ownbank.Application.UseCases.Register;

namespace ownbank.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configurations)
        {
            AddUseCases(services);
            PasswordEncrypter(services, configurations);
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(IServiceCollection services) 
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(option =>
            {
                option.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase,  RegisterUserUseCase>();
        }

        private static void PasswordEncrypter(IServiceCollection services, IConfiguration configuration)
        {
            var additionalKey = configuration.GetValue<string>("Settings:Password:AdditionalKey");
            services.AddScoped(option => new PasswordEncripter(additionalKey!));
        }
    }
        
}
