using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using SecureBankingApp.Data;
using SecureBankingApp.Models;

namespace SecureBankingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user, string password)
        {
            if (ModelState.IsValid)
            {
                user.PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(password);

                _context.Users.Add(user);

                _context.SaveChanges();

                AuditLog log = new AuditLog()
                {
                    ActionPerformed = "New User Registered",
                    UserEmail = user.Email,
                    ActionTime = DateTime.Now
                };

                _context.AuditLogs.Add(log);

                _context.SaveChanges();

                TempData["Success"] = "User Registered Successfully";

                return RedirectToAction("Register");
            }

            return View(user);
        }
    }
}