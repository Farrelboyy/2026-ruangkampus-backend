using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuangKampus.Backend.Data;
using RuangKampus.Backend.Models;

namespace RuangKampus.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            // Cek username udah ada belum
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            {
                return BadRequest(new { message = "Username sudah dipakai!" });
            }

            // Simpan user baru
            user.Role = "User"; // Default role
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registrasi berhasil!" });
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Username atau Password salah!" });
            }

            // Login sukses, balikin data user (HAPUS FullName BIAR GAK ERROR)
            return Ok(new
            {
                message = "Login berhasil!",
                user = new { user.Id, user.Username, user.Role }
            });
        }
    }

    // Class kecil buat nangkep input login (Dikasih = string.Empty biar gak warning)
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}