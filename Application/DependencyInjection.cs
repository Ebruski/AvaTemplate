using Application.Common.Behaviour;
using Application.Common.Interfaces;
using Application.Common.Localization.Configuration;
using Application.Common.Localization.Extensions;
using Application.Common.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddSingleton<ICommandFactory, CommandFactory>();

            return services;
        }

        public static void ConfigureLocalization(this IServiceCollection services, IConfiguration configuration)
        {
            var jsonLocalizationOptions = configuration.GetSection(nameof(JsonLocalizationOptions));

            var localizationOptions = jsonLocalizationOptions.Get<JsonLocalizationOptions>();
            var defaultRequestCulture = new RequestCulture(localizationOptions.DefaultCulture,
                localizationOptions.DefaultUICulture);
            var supportedCultures = localizationOptions.SupportedCultureInfos.ToList();

            services.AddJsonLocalization(options =>
            {
                options.ResourcesPath = localizationOptions.ResourcesPath;
                options.UseBaseName = localizationOptions.UseBaseName;
                options.CacheDuration = localizationOptions.CacheDuration;
                options.SupportedCultureInfos = localizationOptions.SupportedCultureInfos;
                options.FileEncoding = localizationOptions.FileEncoding;
                options.IsAbsolutePath = localizationOptions.IsAbsolutePath;
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = defaultRequestCulture;

                // Formatting numbers, dates, etc.
                options.SupportedCultures = supportedCultures;
                //new List<CultureInfo>() { supportedCultures };// _defaultRequestCulture;

                // UI strings that we have localized.
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
