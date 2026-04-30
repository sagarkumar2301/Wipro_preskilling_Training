using SecureUserApp.Services;
using SecureUserApp.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureUserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerService.Configure();

            AuthService auth = new AuthService();

            try
            {
                auth.Register("sagar", "1234");

                bool result = auth.Login("sagar", "1234");

                Console.WriteLine(result ? "Login Success" : "Login Failed");

                string encrypted = EncryptionHelper.Encrypt("SensitiveData");
                Console.WriteLine("Encrypted: " + encrypted);

                string decrypted = EncryptionHelper.Decrypt(encrypted);
                Console.WriteLine("Decrypted: " + decrypted);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred in application");
                Console.WriteLine("Error occurred");
            }
        }
    }
}
