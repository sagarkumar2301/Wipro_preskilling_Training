using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HR_Management___Workforce_Analytics.Filters
{
    public class GlobalExceptionFilter: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ViewResult
            {
                ViewName = "Error"
            };
            context.ExceptionHandled = true;
        }
    }
}
