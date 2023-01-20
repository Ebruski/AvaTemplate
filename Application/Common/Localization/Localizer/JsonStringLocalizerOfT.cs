using Application.Common.Localization.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace Application.Common.Localization.Localizer
{
    internal class JsonStringLocalizerOfT<T> : JsonStringLocalizer, IJsonStringLocalizer<T>, IStringLocalizer<T>
    {
#if NETCORE
         public JsonStringLocalizerOfT(IOptions<JsonLocalizationOptions> localizationOptions, IWebHostEnvironment env, string baseName
 = null) : base(localizationOptions, env, baseName)
        {
        }
#else
        public JsonStringLocalizerOfT(IOptions<JsonLocalizationOptions> localizationOptions, IHostEnvironment env,
            string baseName = null) : base(localizationOptions, env, baseName)
        {
        }
#endif
    }
}