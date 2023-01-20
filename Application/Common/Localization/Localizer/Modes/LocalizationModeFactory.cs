using Application.Common.Localization.Configuration;

namespace Application.Common.Localization.Localizer.Modes
{
    internal static class LocalizationModeFactory
    {
        public static ILocalizationModeGenerator GetLocalisationFromMode(
            LocalizationMode localizationMode)
        {
            ILocalizationModeGenerator localizationModeGenerator = null;

            switch (localizationMode)
            {
                case LocalizationMode.I18n:
                    localizationModeGenerator = new LocalizationI18NModeGenerator();
                    break;

                default:
                    localizationModeGenerator = new LocalizationBasicModeGenerator();
                    break;
            };

            return localizationModeGenerator;
        }
    }
}