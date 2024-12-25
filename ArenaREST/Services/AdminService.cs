using ArenaREST.Models;
using ArenaREST.Repositories;

namespace ArenaREST.Services
{
    public class AdminService
    {
        private readonly AdminRepository _adminRepository;

        public AdminService(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin?> AuthenticateAsync(string username, string password)
        {
            return await _adminRepository.AuthenticateAsync(username, password);
        }
    }
}
