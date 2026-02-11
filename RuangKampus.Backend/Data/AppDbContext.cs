using Microsoft.EntityFrameworkCore;
using RuangKampus.Backend.Models;

namespace RuangKampus.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<RoomLoan> RoomLoans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==========================================
            // 1. SEED DATA USER (Fixed: Pake 'Password' bukan 'PasswordHash')
            // ==========================================
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin", Role = "Admin" },
                new User { Id = 2, Username = "mahasiswa", Password = "user123", Role = "User" },
                new User { Id = 3, Username = "Budi Santoso", Password = "12345", Role = "User" },
                new User { Id = 4, Username = "Siti Aminah", Password = "12345", Role = "User" },
                new User { Id = 5, Username = "Himpunan Mahasiswa", Password = "12345", Role = "User" },
                new User { Id = 6, Username = "Dosen Tamu", Password = "12345", Role = "User" }
            );

            // ==========================================
            // 2. SEED DATA PEMINJAMAN
            // ==========================================
            modelBuilder.Entity<RoomLoan>().HasData(
                new RoomLoan
                {
                    Id = 1,
                    BorrowerName = "Budi Santoso", 
                    RoomName = "Lab Komputer 1",
                    Purpose = "Pengerjaan Tugas Akhir",
                    StartTime = new DateTime(2026, 2, 10, 8, 0, 0),
                    EndTime = new DateTime(2026, 2, 10, 10, 0, 0),
                    Status = "Approved",
                    IsDeleted = false
                },
                new RoomLoan
                {
                    Id = 2,
                    BorrowerName = "Siti Aminah",
                    RoomName = "Aula Utama",
                    Purpose = "Seminar Proposal",
                    StartTime = new DateTime(2026, 2, 11, 13, 0, 0),
                    EndTime = new DateTime(2026, 2, 11, 15, 0, 0),
                    Status = "Pending",
                    IsDeleted = false
                },
                new RoomLoan
                {
                    Id = 3,
                    BorrowerName = "Himpunan Mahasiswa",
                    RoomName = "Ruang Rapat 1",
                    Purpose = "Rapat Bulanan",
                    StartTime = new DateTime(2026, 2, 12, 16, 0, 0),
                    EndTime = new DateTime(2026, 2, 12, 18, 0, 0),
                    Status = "Approved",
                    IsDeleted = false
                },
                new RoomLoan
                {
                    Id = 4,
                    BorrowerName = "Dosen Tamu",
                    RoomName = "Auditorium",
                    Purpose = "Kuliah Umum",
                    StartTime = new DateTime(2026, 2, 13, 9, 0, 0),
                    EndTime = new DateTime(2026, 2, 13, 11, 0, 0),
                    Status = "Pending",
                    IsDeleted = false
                },
                new RoomLoan
                {
                    Id = 5,
                    BorrowerName = "Admin",
                    RoomName = "Studio Musik",
                    Purpose = "Testing Sistem",
                    StartTime = new DateTime(2026, 2, 14, 19, 0, 0),
                    EndTime = new DateTime(2026, 2, 14, 21, 0, 0),
                    Status = "Rejected",
                    IsDeleted = false
                }
            );
        }
    }
}