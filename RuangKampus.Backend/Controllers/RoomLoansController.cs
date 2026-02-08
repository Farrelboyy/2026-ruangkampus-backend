using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuangKampus.Backend.Data;
using RuangKampus.Backend.Models;
using RuangKampus.Backend.DTOs;

namespace RuangKampus.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomLoansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomLoansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomLoans (Udah Aman - Soft Delete)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomLoan>>> GetRoomLoans()
        {
            return await _context.RoomLoans
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        // GET: api/RoomLoans/5 (Udah Aman - Soft Delete)
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomLoan>> GetRoomLoan(int id)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);

            if (roomLoan == null || roomLoan.IsDeleted)
            {
                return NotFound();
            }

            return roomLoan;
        }

        // POST: api/RoomLoans (UPDATED: Pake DTO ✅)
        [HttpPost]
        public async Task<ActionResult<RoomLoan>> PostRoomLoan(CreateLoanDto request)
        {
            // Mapping dari DTO ke Model Database
            var roomLoan = new RoomLoan
            {
                BorrowerName = request.BorrowerName,
                RoomName = request.RoomName,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Purpose = request.Purpose,
                Status = "Pending", // Default
                IsDeleted = false   // Default
            };

            _context.RoomLoans.Add(roomLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomLoan", new { id = roomLoan.Id }, roomLoan);
        }

        // PUT: api/RoomLoans/5 (UPDATED: Pake DTO ✅)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomLoan(int id, CreateLoanDto request)
        {
            // Cari data lama di database
            var existingLoan = await _context.RoomLoans.FindAsync(id);

            // Cek ada gak? atau udah dihapus?
            if (existingLoan == null || existingLoan.IsDeleted)
            {
                return NotFound();
            }

            // Update cuma field yang dibolehin (ID & Status gak berubah)
            existingLoan.BorrowerName = request.BorrowerName;
            existingLoan.RoomName = request.RoomName;
            existingLoan.StartTime = request.StartTime;
            existingLoan.EndTime = request.EndTime;
            existingLoan.Purpose = request.Purpose;

            // Simpan perubahan
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomLoanExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/RoomLoans/5 (Udah Aman - Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomLoan(int id)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);
            if (roomLoan == null)
            {
                return NotFound();
            }

            // Soft Delete Logic
            roomLoan.IsDeleted = true;
            roomLoan.DeletedAt = DateTime.UtcNow;
            _context.Entry(roomLoan).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomLoanExists(int id)
        {
            return _context.RoomLoans.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}