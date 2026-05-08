using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineExamPortal.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action Executing: " +
                context.ActionDescriptor.DisplayName);

            base.OnActionExecuting(context);
        }
    }
}