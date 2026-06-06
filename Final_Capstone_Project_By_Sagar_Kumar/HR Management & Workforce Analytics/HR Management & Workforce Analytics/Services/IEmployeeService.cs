using HR_Management___Workforce_Analytics.Models;

namespace HR_Management___Workforce_Analytics.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task AddEmployeeAsync(Employee employee);

        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
