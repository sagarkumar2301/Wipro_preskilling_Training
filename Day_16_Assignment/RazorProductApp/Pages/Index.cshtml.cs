using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProductApp.Models;

namespace RazorProductApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        public static List<Product> ProductList = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            ProductList.Add(Product);
            return RedirectToPage();
        }
    }
}
