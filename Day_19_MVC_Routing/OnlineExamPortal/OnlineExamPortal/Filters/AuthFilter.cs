
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    namespace OnlineExamPortal.Filters
    {
        public class AuthFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var session = context.HttpContext.Session.GetString("User");

                if (string.IsNullOrEmpty(session))
                {
                    context.Result = new RedirectToActionResult("Login", "Account", null);
                }

                base.OnActionExecuting(context);
            }
        }
    }

