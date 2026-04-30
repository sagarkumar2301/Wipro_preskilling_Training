using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureUserApp.Utilities
{
    class EncryptionHelper
    {
        private static readonly string key = "1234567890123456"; // 16 char key

        public static string Encrypt(string text)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                byte[] bytes = Encoding.UTF8.GetBytes(text);

                byte[] encrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);

                return Convert.ToBase64String(encrypted);
            }
        }

        public static string Decrypt(string cipher)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = new byte[16];

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                byte[] buffer = Convert.FromBase64String(cipher);

                byte[] decrypted = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }
}
