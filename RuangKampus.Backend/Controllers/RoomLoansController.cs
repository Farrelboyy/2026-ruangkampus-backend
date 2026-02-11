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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomLoan>>> GetRoomLoans()
        {
            return await _context.RoomLoans
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

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

        [HttpPost]
        public async Task<ActionResult<RoomLoan>> PostRoomLoan(CreateLoanDto request)
        {
            var roomLoan = new RoomLoan
            {
                BorrowerName = request.BorrowerName,
                RoomName = request.RoomName,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Purpose = request.Purpose,
                Status = "Pending",
                IsDeleted = false
            };

            _context.RoomLoans.Add(roomLoan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoomLoan), new { id = roomLoan.Id }, roomLoan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomLoan(int id, [FromBody] UpdateLoanRequest request)
        {
            var existingLoan = await _context.RoomLoans.FindAsync(id);

            if (existingLoan == null || existingLoan.IsDeleted)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(request.Status)) existingLoan.Status = request.Status;
            if (!string.IsNullOrEmpty(request.BorrowerName)) existingLoan.BorrowerName = request.BorrowerName;
            if (!string.IsNullOrEmpty(request.RoomName)) existingLoan.RoomName = request.RoomName;
            if (!string.IsNullOrEmpty(request.Purpose)) existingLoan.Purpose = request.Purpose;
            if (request.StartTime != default) existingLoan.StartTime = request.StartTime;
            if (request.EndTime != default) existingLoan.EndTime = request.EndTime;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomLoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomLoan(int id)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);
            if (roomLoan == null)
            {
                return NotFound();
            }

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

    public class UpdateLoanRequest
    {
        public string? BorrowerName { get; set; }
        public string? RoomName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Purpose { get; set; }
        public string? Status { get; set; }
    }
}