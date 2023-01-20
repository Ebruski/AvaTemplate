using Application.Common.Localization.Configuration;
using Application.Common.Localization.Format;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Application.Common.Localization.Localizer.Modes
{
    internal abstract class LocalizationModeBase
    {
        protected ConcurrentDictionary<string, LocalizedFormat> localization =
            new ConcurrentDictionary<string, LocalizedFormat>();

        protected JsonLocalizationOptions _options;

        protected void AddOrUpdateLocalizedValue<T>(LocalizedFormat localizedValue, KeyValuePair<string, T> temp)
        {
            if (!(localizedValue.Value is null))
            {
                if (!localization.ContainsKey(temp.Key))
                {
                    localization.TryAdd(temp.Key, localizedValue);
                }
                else if (localization[temp.Key].IsParent)
                {
                    localization[temp.Key] = localizedValue;
                }
            }
        }
    }
}