using HR_Management___Workforce_Analytics.Models;

namespace HR_Management___Workforce_Analytics.Interfaces
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog auditLog);
        Task SaveChangesAsync();
        Task<List<AuditLog>> GetAllAsync();
    }
}
