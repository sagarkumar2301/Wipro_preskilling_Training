using SecureUserApp.Models;
using System.Collections.Generic;
using System.Linq;
using SecureUserApp.Utilities;   


namespace SecureUserApp.Services
{
    public class AuthService
    {
        private List<User> users = new List<User>();

        public void Register(string username, string password)
        {
            string hashed = HashHelper.HashPassword(password);

            users.Add(new User
            {
                Username = username,
                HashedPassword = hashed
            });
        }

        public bool Login(string username, string password)
        {
            string hashed = HashHelper.HashPassword(password);

            return users.Any(u => u.Username == username && u.HashedPassword == hashed);
        }
    }
}
