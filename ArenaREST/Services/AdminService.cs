using ArenaREST.Models;
using ArenaREST.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace ArenaREST.Services
{
    public class AdminService
    {
        private readonly AdminRepository _adminRepository;

        public AdminService(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // Verify  login
        public async Task<bool> VerifyAdminLogin(string username, string password)
        {
            var admin = await _adminRepository.GetAdminByUsername(username);
            if (admin == null) return false;

            // Verify  password
            return VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt);
        }

        // Create password hash and salt
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key; // random salt
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA256(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }

        public async Task<bool> UpdateLastLogin(string username)
        {
            var admin = await _adminRepository.GetAdminByUsername(username);
            if (admin == null) return false;

            return await _adminRepository.UpdateLastLogin(admin.AdminID, DateTime.UtcNow);
        }

        // Add  admin
        public async Task<bool> AddAdmin(string username, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            var admin = new Admin
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            return await _adminRepository.AddAdmin(admin);
        }
    }
}
