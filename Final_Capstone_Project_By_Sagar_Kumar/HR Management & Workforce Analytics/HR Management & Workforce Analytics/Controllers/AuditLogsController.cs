using Microsoft.AspNetCore.Mvc;
using HR_Management___Workforce_Analytics.Interfaces;



namespace HR_Management___Workforce_Analytics.Controllers
{
    public class AuditLogsController : Controller
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogsController(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _auditLogRepository.GetAllAsync();
            return View(logs);
        }
    }
}
