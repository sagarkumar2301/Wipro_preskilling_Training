using EcommerceFiltersApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceFiltersApp.Filters
{
    public class ErrorHandlingFilter : IExceptionFilter
    {
        private readonly ILoggingService _loggingService;

        public ErrorHandlingFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnException(ExceptionContext context)
        {
            _loggingService.Log(
                $"Exception: {context.Exception.Message}"
            );

            context.Result = new ViewResult
            {
                ViewName = "Error"
            };

            context.ExceptionHandled = true;
        }
    }
}