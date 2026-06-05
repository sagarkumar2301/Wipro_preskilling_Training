
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management___Workforce_Analytics.Models;
using HR_Management___Workforce_Analytics.Interfaces;


public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAuditLogRepository _auditLogRepository;

    public EmployeesController(IEmployeeRepository repository, IAuditLogRepository auditLogRepository)
    {

        _employeeRepository = repository;
        _auditLogRepository = auditLogRepository;
    }

    // GET: EMPLOYEES
    public async Task<IActionResult> Index()
    {
        return View(await _employeeRepository.GetAllAsync());
    }

    // GET: EMPLOYEES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeRepository.GetByIdAsync(id.Value);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // GET: EMPLOYEES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EMPLOYEES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Email,Department,Designation,JoiningDate,IsActive")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            await _employeeRepository.AddAsync(employee);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ActionPerformed = "Employee Created",
                UserName = "Admin",
                CreatedDate = DateTime.Now
            });

            await _auditLogRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    // GET: EMPLOYEES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeRepository.GetByIdAsync(id.Value);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    // POST: EMPLOYEES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("EmployeeId,FirstName,LastName,Email,Department,Designation,JoiningDate,IsActive")] Employee employee)
    {
        if (id != employee.EmployeeId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _employeeRepository.UpdateAsync(employee);
                await _auditLogRepository.AddAsync(new AuditLog
                {
                    ActionPerformed = "Employee Updated",
                    UserName = "Admin",
                    CreatedDate = DateTime.Now
                });
                await _auditLogRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employee.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    // GET: EMPLOYEES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeRepository.GetByIdAsync(id.Value);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: EMPLOYEES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id.Value);
        if (employee != null)
        {
            await _employeeRepository.DeleteAsync(id.Value);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ActionPerformed = "Employee Deleted",
                UserName = "Admin",
                CreatedDate = DateTime.Now
            });
            await _auditLogRepository.SaveChangesAsync();
        }

        await _employeeRepository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmployeeExists(int? id)
    {
        return _employeeRepository.GetByIdAsync(id.Value).Result != null;
    }
}
