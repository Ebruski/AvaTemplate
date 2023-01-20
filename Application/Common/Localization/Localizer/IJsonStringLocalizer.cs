using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace Application.Common.Localization.Localizer
{
    public interface IJsonStringLocalizer : IStringLocalizer
    {
        void ClearMemCache(IEnumerable<CultureInfo> culturesToClearFromCache = null);
        void ReloadMemCache(IEnumerable<CultureInfo> culturesToClearFromCache = null);
    }

    public interface IJsonStringLocalizer<T> : IJsonStringLocalizer
    {

    }
}