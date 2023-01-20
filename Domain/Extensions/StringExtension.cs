using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Extensions
{
   public static class StringExtension
    {
  
        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static byte[] GetObjectByte<T>(this T value)
        {
            var stringMessage = JsonConvert.SerializeObject(value, Formatting.None);
            return Encoding.UTF8.GetBytes(stringMessage);
        }
        public static T GetObjectFromByte<T>(this byte[] value)
        {
            var bytesAsString = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject<T>(bytesAsString);
        }

        public static (byte[], byte[]) ToHash(this string password)
        {
            using (var cipher = new System.Security.Cryptography.HMACSHA512())
            {
                var passwordSalt = cipher.Key;
                var passwordHash = cipher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return (passwordHash, passwordSalt);
            }
        }
        public static bool VerifyHash(this string Password, byte[] storedSalt, byte[] storedHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return computed.SequenceEqual(storedHash);
            }
        }
        public static string GenerateRefreshToken(this string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
