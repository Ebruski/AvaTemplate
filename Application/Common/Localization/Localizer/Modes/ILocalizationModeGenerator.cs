using Application.Common.Localization.Configuration;
using Application.Common.Localization.Format;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;

namespace Application.Common.Localization.Localizer.Modes
{
    internal interface ILocalizationModeGenerator
    {
        ConcurrentDictionary<string, LocalizedFormat> ConstructLocalization(
            IEnumerable<string> myFiles, CultureInfo currentCulture, JsonLocalizationOptions options);

    }
}