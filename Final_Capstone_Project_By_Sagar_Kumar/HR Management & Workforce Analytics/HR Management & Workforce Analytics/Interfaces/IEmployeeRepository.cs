using HR_Management___Workforce_Analytics.Models;
namespace HR_Management___Workforce_Analytics.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddAsync(Employee employee);

        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
