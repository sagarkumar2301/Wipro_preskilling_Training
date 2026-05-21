using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureECommercePortal.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}