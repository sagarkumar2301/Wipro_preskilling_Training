using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureJwtApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureJwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(UserModel user)
        {
            if (user.Username == "admin" && user.Password == "admin123")
            {
                var token = GenerateToken(user.Username, "Admin");

                return Ok(new
                {
                    token = token
                });
            }

            else if (user.Username == "user" && user.Password == "user123")
            {
                var token = GenerateToken(user.Username, "User");

                return Ok(new
                {
                    token = token
                });
            }

            return Unauthorized("Invalid Username or Password");
        }

        private string GenerateToken(string username, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,
                    _configuration["Jwt:Subject"]),

                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()),

                new Claim(JwtRegisteredClaimNames.Iss,
                    _configuration["Jwt:Issuer"]),

                new Claim(ClaimTypes.Name, username),

                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,

                expires: DateTime.UtcNow.AddMinutes(10),

                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}