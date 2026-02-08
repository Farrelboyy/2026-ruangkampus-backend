using Microsoft.EntityFrameworkCore;
using RuangKampus.Backend.Models;

namespace RuangKampus.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Ini mendaftarkan model RoomLoan biar jadi Tabel di Database
        public DbSet<RoomLoan> RoomLoans { get; set; }
        public DbSet<User> Users { get; set; }
    }
}