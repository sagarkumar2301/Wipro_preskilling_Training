using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo2wayDataBinding.Pages
{
    public class IndexModel : PageModel
    {
        
        [BindProperty]
        public string StudentName { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public void OnGet()
        {

        }
        public void OnPost() { 
            Message = $"Hello, {StudentName}! Welcome to Razor Pages.";
        }
    }
}
