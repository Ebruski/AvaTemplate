using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.IO;
using System.Text;

namespace Application.Common.Localization.Localizer.Modes
{
    public static class LocalisationModeHelpers
    {
        public static ConcurrentDictionary<T, U> ReadAndDeserializeFile<T, U>(string file, Encoding encoding)
        {
            return
                JsonConvert.DeserializeObject<ConcurrentDictionary<T, U>>(
                    File.ReadAllText(file, encoding));
        }
    }
}