using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages{
public class AddItemModel : PageModel
{
    [BindProperty]
    public string NewItem { get; set; }

    public IActionResult OnPost()
    {
        ItemsModel.Items.Add(NewItem);
        return RedirectToPage("Items");
    }
}
}