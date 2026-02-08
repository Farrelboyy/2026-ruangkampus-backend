using RuangKampus.Backend.Models;

namespace RuangKampus.Backend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Pastikan database udah kebuat
            context.Database.EnsureCreated();

            // Cek apakah tabel RoomLoans sudah ada isinya?
            if (context.RoomLoans.Any())
            {
                return;   // Data sudah ada, gak perlu ngapa-ngapain
            }

            // Kalau kosong, kita masukin data dummy (Data Sampah buat ngetes)
            var loans = new RoomLoan[]
            {
                new RoomLoan
                {
                    BorrowerName = "Farrel Ganteng",
                    RoomName = "Lab Komputer 1",
                    StartTime = DateTime.Now.AddDays(1).AddHours(9), // Besok jam 9 pagi
                    EndTime = DateTime.Now.AddDays(1).AddHours(11),  // Besok jam 11 pagi
                    Purpose = "Ngerjain Tugas Backend",
                    Status = "Approved"
                },
                new RoomLoan
                {
                    BorrowerName = "Budi Santoso",
                    RoomName = "Ruang Sidang",
                    StartTime = DateTime.Now.AddDays(2).AddHours(13),
                    EndTime = DateTime.Now.AddDays(2).AddHours(15),
                    Purpose = "Rapat Hima",
                    Status = "Pending"
                },
                new RoomLoan
                {
                    BorrowerName = "Siti Aminah",
                    RoomName = "Aula Utama",
                    StartTime = DateTime.Now.AddDays(3).AddHours(8),
                    EndTime = DateTime.Now.AddDays(3).AddHours(12),
                    Purpose = "Seminar Teknologi",
                    Status = "Rejected"
                }
            };

            // Masukin ke database
            foreach (var loan in loans)
            {
                context.RoomLoans.Add(loan);
            }
            context.SaveChanges(); // Simpan permanen
        }
    }
}