using BankingFiltersApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingFiltersApp.Filters
{
    public class AdminAuthorizationFilter : IActionFilter
    {
        private readonly IAuthService _authService;

        public AdminAuthorizationFilter(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_authService.IsAdmin())
            {
                context.Result = new ContentResult
                {
                    Content = "Access Denied"
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}