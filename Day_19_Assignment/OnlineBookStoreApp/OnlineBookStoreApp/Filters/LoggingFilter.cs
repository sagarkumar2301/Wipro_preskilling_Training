using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBookStoreApp.Filters
{
    public class LoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action Executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Executed");
        }
    }
}