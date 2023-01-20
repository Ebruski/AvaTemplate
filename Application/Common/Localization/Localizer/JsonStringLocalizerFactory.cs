using Application.Common.Localization.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;

namespace Application.Common.Localization.Localizer
{
    /// <summary>
    /// Factory the create the JsonStringLocalizer
    /// </summary>
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly IOptions<JsonLocalizationOptions> _localizationOptions;

#if NETCORE
            private readonly IWebHostEnvironment _env;
        
         public JsonStringLocalizerFactory(
            IWebHostEnvironment env,
            IOptions<JsonLocalizationOptions> localizationOptions = null)
        {
            _env = env;
            _localizationOptions = localizationOptions ?? throw new ArgumentNullException(nameof(localizationOptions));
        }
#else
        private readonly IHostEnvironment _env;

        public JsonStringLocalizerFactory(
            IHostEnvironment env,
            IOptions<JsonLocalizationOptions> localizationOptions = null)
        {
            _env = env;
            _localizationOptions = localizationOptions ?? throw new ArgumentNullException(nameof(localizationOptions));
        }
#endif


        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer(_localizationOptions, _env);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            baseName = _localizationOptions.Value.UseBaseName ? baseName : string.Empty;
            return new JsonStringLocalizer(_localizationOptions, _env, baseName);
        }
    }
}