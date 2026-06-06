using HR_Management___Workforce_Analytics.Models;
using HR_Management___Workforce_Analytics.Interfaces;
namespace HR_Management___Workforce_Analytics.Services
{
    public class LeaveRequestService: ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            return await _leaveRequestRepository.GetAllAsync();
        }

        public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id)
        {
            return await _leaveRequestRepository.GetByIdAsync(id);
        }

        public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            await _leaveRequestRepository.AddAsync(leaveRequest);
        }

        public async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            await _leaveRequestRepository.UpdateAsync(leaveRequest);
        }

        public async Task DeleteLeaveRequestAsync(int id)
        {
            await _leaveRequestRepository.DeleteAsync(id);
        }

       
    }
}
