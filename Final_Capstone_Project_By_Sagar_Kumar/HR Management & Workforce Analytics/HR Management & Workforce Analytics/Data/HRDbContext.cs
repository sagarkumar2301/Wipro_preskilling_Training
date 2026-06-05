using Microsoft.EntityFrameworkCore;
using HR_Management___Workforce_Analytics.Models;

namespace HR_Management___Workforce_Analytics.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
