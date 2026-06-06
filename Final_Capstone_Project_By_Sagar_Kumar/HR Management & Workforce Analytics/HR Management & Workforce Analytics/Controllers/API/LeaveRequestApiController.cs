
using Microsoft.AspNetCore.Mvc;
using HR_Management___Workforce_Analytics.Services;
using Microsoft.AspNetCore.Authorization;

namespace HR_Management___Workforce_Analytics.Controllers.API
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestApiController: ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestApiController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        // GET: api/LeaveRequestApi
        
        [HttpGet]
        public async Task<IActionResult> GetLeaveRequests()
        {
            var leaveRequests = await _leaveRequestService.GetAllLeaveRequestsAsync();
            return Ok(leaveRequests);
        }
    }
}
