using HR_Management___Workforce_Analytics.Data;
using HR_Management___Workforce_Analytics.Interfaces;
using HR_Management___Workforce_Analytics.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_Management___Workforce_Analytics.Repositories
{
    public class LeaveRequestRepository: ILeaveRequestRepository
    {
        private readonly HRDbContext _context;

        public LeaveRequestRepository(HRDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return await _context.LeaveRequests.FirstOrDefaultAsync(lr => lr.LeaveRequestId == id);
        }

        public async Task AddAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id)
        {
            var leaveRequest = await GetByIdAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
