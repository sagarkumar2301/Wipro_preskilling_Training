using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages{
public class ItemsModel : PageModel
{
    public static List<string> Items = new List<string>();

    public void OnGet()
    {
    }
}
}