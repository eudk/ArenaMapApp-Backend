namespace ArenaREST.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; } 
        public DateTime? LastLogin { get; set; }
    }
}
