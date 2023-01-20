using Application.Common.Localization.Configuration;
using Application.Common.Localization.Format;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Application.Common.Localization.Localizer.Modes
{
    internal class LocalizationBasicModeGenerator : LocalizationModeBase, ILocalizationModeGenerator
    {
        public ConcurrentDictionary<string, LocalizedFormat> ConstructLocalization(
            IEnumerable<string> myFiles, CultureInfo currentCulture, JsonLocalizationOptions options)
        {
            _options = options;

            foreach (string file in myFiles)
            {
                ConcurrentDictionary<string, JsonLocalizationFormat> tempLocalization =
                    LocalisationModeHelpers.ReadAndDeserializeFile<string, JsonLocalizationFormat>(file,
                        options.FileEncoding);

                if (tempLocalization == null)
                {
                    continue;
                }

                foreach (KeyValuePair<string, JsonLocalizationFormat> temp in tempLocalization)
                {
                    LocalizedFormat localizedValue = GetLocalizedValue(currentCulture, temp);
                    AddOrUpdateLocalizedValue<JsonLocalizationFormat>(localizedValue, temp);
                }
            }

            return localization;
        }

        private LocalizedFormat GetLocalizedValue(CultureInfo currentCulture,
            KeyValuePair<string, JsonLocalizationFormat> temp)
        {
            var localizationFormat = temp.Value;
            bool isParent = false;
            string value = localizationFormat.Values.FirstOrDefault(s =>
                string.Equals(s.Key, currentCulture.Name, StringComparison.OrdinalIgnoreCase)).Value;
            if (value is null)
            {
                isParent = true;
                value = localizationFormat.Values.FirstOrDefault(s =>
                    string.Equals(s.Key, currentCulture.Parent.Name, StringComparison.OrdinalIgnoreCase)).Value;
                if (value is null)
                {
                    value = localizationFormat.Values.FirstOrDefault(s => string.IsNullOrWhiteSpace(s.Key)).Value;
                    if (value is null && _options.DefaultCulture != null)
                    {
                        value = localizationFormat.Values.FirstOrDefault(s => string.Equals(s.Key,
                            _options.DefaultCulture.Name, StringComparison.OrdinalIgnoreCase)).Value;
                    }
                }
            }

            return new LocalizedFormat()
            {
                IsParent = isParent,
                Value = value
            };
        }
    }
}