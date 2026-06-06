using HR_Management___Workforce_Analytics.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HR_Management___Workforce_Analytics.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DashboardController: Controller
    {
        private readonly HRDbContext _context;

        public DashboardController(HRDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.ActiveEmployees = _context.Employees.Count(e => e.IsActive);

            ViewBag.TotalLeaveRequests = _context.LeaveRequests.Count();

            ViewBag.PendingLeaveRequests = _context.LeaveRequests.Count(lr => lr.Status == "Pending");
            

            ViewBag.HRCount =
                _context.Employees.Count(e => e.Department == "HR");

            ViewBag.ITCount =
                _context.Employees.Count(e => e.Department == "IT");

            ViewBag.FinanceCount =
                _context.Employees.Count(e => e.Department == "Finance");

            ViewBag.SalesCount =
                _context.Employees.Count(e => e.Department == "Sales");

            return View();
        }

    }
}
