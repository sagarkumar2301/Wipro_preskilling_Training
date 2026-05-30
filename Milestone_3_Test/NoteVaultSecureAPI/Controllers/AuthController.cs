using Microsoft.AspNetCore.Mvc;
using NoteVaultSecureAPI.DTOs;
using NoteVaultSecureAPI.Models;
using NoteVaultSecureAPI.Services;

namespace NoteVaultSecureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new List<User>();

        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (users.Any(u => u.Username == dto.Username))
            {
                return BadRequest(new
                {
                    message = "Username already exists"
                });
            }

            var user = new User
            {
                Id = users.Count + 1,
                Username = dto.Username,
                PasswordHash = dto.Password
            };

            users.Add(user);

            return Ok(new
            {
                message = "User registered successfully. Please log in."
            });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = users.FirstOrDefault(
                u => u.Username == dto.Username &&
                     u.PasswordHash == dto.Password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid username or password"
                });
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token = token,
                expires_in = 3600,
                user = new
                {
                    username = user.Username
                }
            });
        }
    }
}