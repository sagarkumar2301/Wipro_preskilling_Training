using HR_Management___Workforce_Analytics.Models;
using HR_Management___Workforce_Analytics.Data;
using HR_Management___Workforce_Analytics.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace HR_Management___Workforce_Analytics.Repositories
{
    public class AuditLogRepository: IAuditLogRepository
    {
        private readonly HRDbContext _context;

        public AuditLogRepository(HRDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AuditLog auditLog)
        {
            await _context.AuditLogs.AddAsync(auditLog);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<AuditLog>> GetAllAsync()
        {
            return await _context.AuditLogs.ToListAsync();
        } 
    }
}
