using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureJwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [Authorize]
        [HttpGet("user")]
        public IActionResult UserEndpoint()
        {
            return Ok("This endpoint is accessible to authenticated users.");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("This endpoint is accessible only to Admin.");
        }


        [Authorize(Roles = "User")]
        [HttpGet("normaluser")]
        public IActionResult UserRoleEndpoint()
        {
            return Ok("This endpoint is accessible only to User.");
        }
    }
}