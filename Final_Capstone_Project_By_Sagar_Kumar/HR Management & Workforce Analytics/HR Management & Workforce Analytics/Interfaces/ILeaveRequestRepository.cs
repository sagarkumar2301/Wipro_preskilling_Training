using HR_Management___Workforce_Analytics.Models;

namespace HR_Management___Workforce_Analytics.Interfaces

{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllAsync();

        Task<LeaveRequest?> GetByIdAsync(int id);

        Task AddAsync(LeaveRequest leaveRequest);

        Task UpdateAsync(LeaveRequest leaveRequest);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
