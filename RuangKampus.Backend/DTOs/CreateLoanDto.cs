using System.ComponentModel.DataAnnotations;

namespace RuangKampus.Backend.DTOs
{
    public class CreateLoanDto
    {
        [Required(ErrorMessage = "Nama peminjam wajib diisi")]
        [StringLength(100)]
        public string BorrowerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama ruangan wajib diisi")]
        public string RoomName { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Tujuan peminjaman wajib diisi")]
        public string Purpose { get; set; } = string.Empty;
    }
}