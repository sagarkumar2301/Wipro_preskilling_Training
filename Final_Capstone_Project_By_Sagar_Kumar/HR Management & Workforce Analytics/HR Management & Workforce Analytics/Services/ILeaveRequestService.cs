using HR_Management___Workforce_Analytics.Models;
namespace HR_Management___Workforce_Analytics.Services
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id);
        Task AddLeaveRequestAsync(LeaveRequest leaveRequest);
        Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task DeleteLeaveRequestAsync(int id);
        
    }
}
