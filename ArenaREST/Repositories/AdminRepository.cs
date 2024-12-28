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

        public async Task<Admin?> GetAdminByUsername(string username)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task<bool> UpdateLastLogin(int adminId, DateTime lastLogin)
        {
            var admin = await _context.Admins.FindAsync(adminId);
            if (admin == null) return false;

            admin.LastLogin = lastLogin;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
