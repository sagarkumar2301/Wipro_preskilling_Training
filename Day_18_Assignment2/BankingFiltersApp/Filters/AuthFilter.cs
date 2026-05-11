using BankingFiltersApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingFiltersApp.Filters
{
    public class AuthFilter : IActionFilter
    {
        private readonly IAuthService _authService;

        public AuthFilter(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_authService.IsAuthenticated())
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Account",
                    null
                );
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}