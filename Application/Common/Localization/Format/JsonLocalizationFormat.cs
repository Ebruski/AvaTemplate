using System.Collections.Generic;

namespace Application.Common.Localization.Format
{
    internal class JsonLocalizationFormat
    {
        public Dictionary<string, string> Values = new Dictionary<string, string>();
    }

    internal class LocalizationFormat
    {
        public Dictionary<int, string> Values = new Dictionary<int, string>();
    }

    internal class LocalizedFormat
    {
        public bool IsParent { get; set; }
        public string Value { get; set; }
    }
}