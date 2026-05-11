using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EcommerceRoutingApp.Constraints
{
    public class CategoryConstraint : IRouteConstraint
    {
        private readonly List<string> validCategories =
            new List<string> { "electronics", "fashion", "books" };

        public bool Match(
            HttpContext? httpContext,
            IRouter? route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value))
            {
                return validCategories.Contains(value!.ToString()!.ToLower());
            }

            return false;
        }
    }
}