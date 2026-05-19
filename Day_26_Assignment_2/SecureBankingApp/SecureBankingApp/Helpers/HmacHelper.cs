using System.Security.Cryptography;
using System.Text;

namespace SecureBankingApp.Helpers
{
    public class HmacHelper
    {
        public static string GenerateHMAC(string data, string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);

            using var hmac = new HMACSHA256(keyBytes);

            var dataBytes = Encoding.UTF8.GetBytes(data);

            var hash = hmac.ComputeHash(dataBytes);

            return Convert.ToBase64String(hash);
        }
    }
}