using Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace Application.Common.Extensions
{
    public static class UtilityExtensions
    {
        public static T ConvertFromByte<T>(this byte[] arr)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(arr));
        }

        public static byte[] ConvertToByte<T>(this T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
