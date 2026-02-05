using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuangKampus.Backend.Data;
using RuangKampus.Backend.Models;

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

        // 1. GET: Ambil semua data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomLoan>>> GetRoomLoans()
        {
            return await _context.RoomLoans.ToListAsync();
        }

        // 2. GET: Ambil satu data by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomLoan>> GetRoomLoan(int id)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);
            if (roomLoan == null) return NotFound();
            return roomLoan;
        }

        // 3. POST: Tambah data baru
        [HttpPost]
        public async Task<ActionResult<RoomLoan>> PostRoomLoan(RoomLoan roomLoan)
        {
            _context.RoomLoans.Add(roomLoan);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRoomLoan), new { id = roomLoan.Id }, roomLoan);
        }

        // 4. PUT: Update data
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomLoan(int id, RoomLoan roomLoan)
        {
            if (id != roomLoan.Id) return BadRequest();
            _context.Entry(roomLoan).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RoomLoans.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        // 5. DELETE: Hapus data
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomLoan(int id)
        {
            var roomLoan = await _context.RoomLoans.FindAsync(id);
            if (roomLoan == null) return NotFound();
            _context.RoomLoans.Remove(roomLoan);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}