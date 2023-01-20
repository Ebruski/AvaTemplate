using Application.Common.Interfaces.Repository;
using Application.Common.Interfaces.Service;
using Infrastructure.AppSettingsModels;
using Infrastructure.Persistence.DbConfiguration;
using Infrastructure.Persistence.Repository;
using Infrastructure.Services.FakeServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceUrls>(configuration.GetSection(nameof(ServiceUrls)));

            services.AddTransient<ICorporateRepository, CorporateRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ITestService, FakeTestService>();

            return services;
        }
    }
}