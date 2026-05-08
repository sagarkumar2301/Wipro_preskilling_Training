using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodDelivery.Controllers
{
    [Route("restaurant")]
    public class RestaurantController : Controller
    {
        // URL Routing
        [Route("menu")]
        public IActionResult Menu()
        {
            return Content("Restaurant Menu Page");
        }

        // Attribute Routing
        [Route("details")]
        public IActionResult Details()
        {
            return Content("Restaurant Details Page");
        }

        // Routing Constraint
        [Route("{id:int}")]
        public IActionResult GetRestaurantById(int id)
        {
            return Content($"Restaurant ID: {id}");
        }

        // Custom Route Action
        [Route("/order-food")]
        public IActionResult OrderFood()
        {
            return Content("Order Food Page");
        }
    }
}
