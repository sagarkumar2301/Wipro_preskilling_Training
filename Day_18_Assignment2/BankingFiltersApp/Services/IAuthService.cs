namespace BankingFiltersApp.Services
{
    public interface IAuthService
    {
        bool IsAuthenticated();
        bool IsAdmin();
    }
}