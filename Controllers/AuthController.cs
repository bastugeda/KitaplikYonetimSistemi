using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;  // IConfiguration için eklendi
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KitaplikYonetimSistemi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;  // Configuration için eklendi

        // Constructor üzerinden IConfiguration nesnesini alın
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // ⚠️ Geçici örnek kullanıcı kontrolü (veritabanı yok henüz)
            if (request.Username == "admin" && request.Password == "1234")
            {
                var token = GenerateJwtToken();
                return Ok(new { token });
            }
            return Unauthorized("Kullanıcı adı veya şifre hatalı");
        }

        private string GenerateJwtToken()
        {
            // appsettings.json dosyasından JWT anahtarını alın
            var jwtKey = _configuration["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:Expire"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
} 