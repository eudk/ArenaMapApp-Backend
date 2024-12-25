using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaREST.Repositories
{
    public class AdminRepository
    {
        private readonly ArenaDbContext _context;

        public AdminRepository(ArenaDbContext context)
        {
            _context = context;
        }
        //logik for admin login
        public async Task<Admin?> AuthenticateAsync(string username, string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password); 
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Username == username);

            if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.Password))
            {
                return admin;
            }

            return null;
        }
    }
}
