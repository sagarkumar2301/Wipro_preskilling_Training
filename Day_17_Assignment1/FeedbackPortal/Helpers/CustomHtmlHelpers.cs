using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeedbackPortal.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlContent StyledInput(this IHtmlHelper htmlHelper,
            string name,
            string placeholder)
        {
            TagBuilder input = new TagBuilder("input");

            input.Attributes.Add("type", "text");
            input.Attributes.Add("name", name);
            input.Attributes.Add("placeholder", placeholder);
            input.AddCssClass("form-control");

            return input;
        }
    }
}