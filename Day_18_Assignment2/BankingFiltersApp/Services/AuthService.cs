namespace BankingFiltersApp.Services
{
    public class AuthService : IAuthService
    {
        public bool IsAuthenticated()
        {
            return true;
        }

        public bool IsAdmin()
        {
            return true;
        }
    }
}