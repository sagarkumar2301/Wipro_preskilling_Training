
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management___Workforce_Analytics.Models;
using HR_Management___Workforce_Analytics.Data;
using HR_Management___Workforce_Analytics.Interfaces;
using Microsoft.AspNetCore.Authorization;

//[Authorize(Roles = "Admin")]
public class LeaveRequestsController : Controller
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    private readonly IAuditLogRepository _auditLogRepository;

    public LeaveRequestsController(ILeaveRequestRepository leaveRequestRepository, IAuditLogRepository auditLogRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _auditLogRepository = auditLogRepository;
    }

    // GET: LEAVEREQUESTS
    public async Task<IActionResult> Index(string status)
    {
        var leaveRequests = await _leaveRequestRepository.GetAllAsync();

        if (!string.IsNullOrEmpty(status))
        {
            leaveRequests = leaveRequests
                .Where(l => l.Status == status)
                .ToList();
        }

        return View(leaveRequests);
    }

    // GET: LEAVEREQUESTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leaverequest = await _leaveRequestRepository.GetByIdAsync(id.Value);
        if (leaverequest == null)
        {
            return NotFound();
        }

        return View(leaverequest);
    }

    // GET: LEAVEREQUESTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LEAVEREQUESTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("LeaveRequestId,EmployeeId,Employee,LeaveType,StartDate,EndDate,Reason,Status")] LeaveRequest leaverequest)
    {
        if (ModelState.IsValid)
        {
            leaverequest.Status = "Pending";
            await _leaveRequestRepository.AddAsync(leaverequest);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ActionPerformed = "Leave Request Create",
                UserName = "Admin",
                CreatedDate = DateTime.Now
            });
            await _auditLogRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(leaverequest);
    }

    // GET: LEAVEREQUESTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leaverequest = await _leaveRequestRepository.GetByIdAsync(id.Value);
        if (leaverequest == null)
        {
            return NotFound();
        }
        return View(leaverequest);
    }

    // POST: LEAVEREQUESTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("LeaveRequestId,EmployeeId,Employee,LeaveType,StartDate,EndDate,Reason,Status")] LeaveRequest leaverequest)
    {
        if (id != leaverequest.LeaveRequestId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _leaveRequestRepository.UpdateAsync(leaverequest);
                await _auditLogRepository.AddAsync(new AuditLog
                {
                    ActionPerformed = "Leave Request Edit",
                    UserName = "Admin",
                    CreatedDate = DateTime.Now
                });
                await _auditLogRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestExists(leaverequest.LeaveRequestId))
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
        return View(leaverequest);
    }

    // GET: LEAVEREQUESTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leaverequest = await _leaveRequestRepository.GetByIdAsync(id.Value);
        if (leaverequest == null)
        {
            return NotFound();
        }

        return View(leaverequest);
    }

    // POST: LEAVEREQUESTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var leaverequest = await _leaveRequestRepository.GetByIdAsync(id.Value);
        if (leaverequest != null)
        {
            await _leaveRequestRepository.DeleteAsync(id.Value);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ActionPerformed = "Leave Request Delete",
                UserName = "Admin",
                CreatedDate = DateTime.Now
            });
        }

        await _auditLogRepository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Approve(int id)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);

        if (leaveRequest == null)
        {
            return NotFound();
        }

        leaveRequest.Status = "Approved";

        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        // Audit Log here
        await _auditLogRepository.AddAsync(new AuditLog
        {
            ActionPerformed = "Leave Request Approved",
            UserName = "Admin",
            CreatedDate = DateTime.Now
        });

        await _auditLogRepository.SaveChangesAsync();

        // Return should be LAST
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Reject(int id)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);

        if (leaveRequest == null)
        {
            return NotFound();

        }
        leaveRequest.Status = "Rejected";

        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        await _auditLogRepository.AddAsync(new AuditLog
        {
            ActionPerformed = "Leave Request Rejected",
            UserName = "Admin",
            CreatedDate = DateTime.Now
        });

        await _auditLogRepository.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Pending(int id)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(id);

        if (leaveRequest == null)
        {
            return NotFound();
        }

        leaveRequest.Status = "Pending";

        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        await _auditLogRepository.AddAsync(new AuditLog
        {
            ActionPerformed = "Leave Request Marked as Pending",
            UserName = "Admin",
            CreatedDate = DateTime.Now
        });

        await _auditLogRepository.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool LeaveRequestExists(int? id)
    {
        return _leaveRequestRepository.GetByIdAsync(id.Value) != null;
    }

    
    
}
