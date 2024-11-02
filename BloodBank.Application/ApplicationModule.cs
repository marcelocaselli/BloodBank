using BloodBank.Application.Commands.InsertDonor;
using BloodBank.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers();

            return services;
        } 

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IDonationService, DonationService>();
            services.AddScoped<IStockService, StockService>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<InsertDonorCommand>());

            return services;
        }
    }

}
