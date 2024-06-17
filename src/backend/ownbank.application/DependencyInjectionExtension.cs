using Microsoft.Extensions.DependencyInjection;
using ownbank.Application.Services.AutoMapper;
using ownbank.Application.UseCases.Register;

namespace ownbank.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
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
    }
        
}
