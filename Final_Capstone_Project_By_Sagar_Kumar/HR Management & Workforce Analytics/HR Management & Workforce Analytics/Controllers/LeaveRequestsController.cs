
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR_Management___Workforce_Analytics.Models;
using HR_Management___Workforce_Analytics.Data;
using HR_Management___Workforce_Analytics.Interfaces;

public class LeaveRequestsController : Controller
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public LeaveRequestsController(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    // GET: LEAVEREQUESTS
    public async Task<IActionResult> Index()    
    {
        return View(await _leaveRequestRepository.GetAllAsync());
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
            await _leaveRequestRepository.AddAsync(leaverequest);
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
        }

        await _leaveRequestRepository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LeaveRequestExists(int? id)
    {
        return _leaveRequestRepository.GetByIdAsync(id.Value) != null;
    }
}
