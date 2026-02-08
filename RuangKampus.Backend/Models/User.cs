namespace RuangKampus.Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Nanti idealnya di-hash, skrg plain dulu biar gampang
        public string Role { get; set; } = "User"; // "Admin" atau "User"
    }
}