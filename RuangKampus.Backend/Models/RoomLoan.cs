namespace RuangKampus.Backend.Models
{
    public class RoomLoan
    {
        public int Id { get; set; }
        public string BorrowerName { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
    }
}