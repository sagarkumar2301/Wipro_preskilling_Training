using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Employee_Feedback_Portal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //one way data binding : Displaying only
        public string EmployeeName { get; set; }

        //two way data binding : Displaying and accepting input
        [BindProperty]
        [Required(ErrorMessage = "Feedback is required.")]
        public string Feedback { get; set; }
        public string Message { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost() {
            //checking if model is valid
            if(!ModelState.IsValid)
            {
                return;
               
            }
            Message = "Thank you for your feedback!";
        }
    }
}
