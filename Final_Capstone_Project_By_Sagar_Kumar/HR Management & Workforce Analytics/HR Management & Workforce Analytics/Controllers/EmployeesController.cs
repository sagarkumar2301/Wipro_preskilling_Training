using ClosedXML.Excel;
using HR_Management___Workforce_Analytics.Interfaces;
using HR_Management___Workforce_Analytics.Models;
using HR_Management___Workforce_Analytics.Repositories;
using HR_Management___Workforce_Analytics.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;



//[Authorize(Roles = "Admin")]
public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IAuditLogRepository _auditLogRepository;

    public EmployeesController(IEmployeeService employeeService, IAuditLogRepository auditLogRepository)
    {

        _employeeService = employeeService;
        _auditLogRepository = auditLogRepository;
    }

    // GET: EMPLOYEES
    public async Task<IActionResult> Index(string searchString, string department)
    {
        var employees = await _employeeService.GetAllEmployeeAsync();

        if (!string.IsNullOrEmpty(searchString))
        {
            employees = employees.Where(e =>
                e.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                e.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(department))
        {
            employees = employees.Where(e => e.Department == department);
        }

        return View(employees);
    }

    // GET: EMPLOYEES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
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
            await _employeeService.AddEmployeeAsync(employee);
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

        var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
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
                await _employeeService.UpdateEmployeeAsync(employee);
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

        var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
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
        var employee = await _employeeService.GetEmployeeByIdAsync(id.Value);
        if (employee != null)
        {
            await _employeeService.DeleteEmployeeAsync(id.Value);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ActionPerformed = $"Employee Deleted: {employee.FirstName}",
                UserName = "Admin",
                CreatedDate = DateTime.Now
            });
            await _auditLogRepository.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ExportToExcel()
    {
        var employees = await _employeeService.GetAllEmployeeAsync();

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Employees");

            worksheet.Cell(1, 1).Value = "Employee ID";
            worksheet.Cell(1, 2).Value = "First Name";
            worksheet.Cell(1, 3).Value = "Last Name";
            worksheet.Cell(1, 4).Value = "Email";
            worksheet.Cell(1, 5).Value = "Department";
            worksheet.Cell(1, 6).Value = "Designation";
            worksheet.Cell(1, 7).Value = "Joining Date";
            worksheet.Cell(1, 8).Value = "Active";

            int row = 2;

            foreach (var emp in employees)
            {
                worksheet.Cell(row, 1).Value = emp.EmployeeId;
                worksheet.Cell(row, 2).Value = emp.FirstName;
                worksheet.Cell(row, 3).Value = emp.LastName;
                worksheet.Cell(row, 4).Value = emp.Email;
                worksheet.Cell(row, 5).Value = emp.Department;
                worksheet.Cell(row, 6).Value = emp.Designation;
                worksheet.Cell(row, 7).Value = emp.JoiningDate.ToString("dd-MM-yyyy");
                worksheet.Cell(row, 8).Value = emp.IsActive ? "Yes" : "No";

                row++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);

                var content = stream.ToArray();

                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Employees.xlsx");
            }
        }
    }

    private bool EmployeeExists(int? id)
    {
        return _employeeService.GetEmployeeByIdAsync(id.Value).Result != null;
    }
}
