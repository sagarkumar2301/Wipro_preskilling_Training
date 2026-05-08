using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace FeedbackPortal.TagHelpers
{
    [HtmlTargetElement("star-rating")]
    public class StarRatingTagHelper : TagHelper
    {
        public int Stars { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Stars; i++)
            {
                sb.Append("⭐");
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}