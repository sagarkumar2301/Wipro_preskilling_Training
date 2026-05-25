using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = new List<string>
            {
                "Order-1001",
                "Order-1002",
                "Order-1003"
            };

            return Ok(orders);
        }
    }
}