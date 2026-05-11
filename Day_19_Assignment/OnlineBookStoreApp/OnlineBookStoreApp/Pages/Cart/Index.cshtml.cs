using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineBookStoreApp.Pages.Cart
{
    public class IndexModel : PageModel
    {
        public int TotalItems { get; set; }

        public void OnGet()
        {
            TotalItems = HttpContext.Session.GetInt32("CartCount") ?? 0;
        }
    }
}