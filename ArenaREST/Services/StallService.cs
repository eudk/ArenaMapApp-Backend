using ArenaREST.Models;
using ArenaREST.Repositories;

namespace ArenaREST.Services
{
    public class StallService
    {
        private readonly StallRepository _stallRepository;

        public StallService(StallRepository stallRepository)
        {
            _stallRepository = stallRepository;
        }

        public async Task<IEnumerable<Stall>> GetAllStalls()
        {
            return await _stallRepository.GetAllStalls();
        }

        public async Task<Stall> AddStall(Stall stall)
        {
            var createdStall = await _stallRepository.AddAndReturnStall(stall);
            return createdStall;
        }



        public async Task<Stall?> UpdateStall(int stallId, Stall updatedStall)
        {
            return await _stallRepository.UpdateStall(stallId, updatedStall);
        }

        public async Task<bool> DeleteStall(int stallId)
        {
            return await _stallRepository.DeleteStall(stallId);
        }
    }
}
