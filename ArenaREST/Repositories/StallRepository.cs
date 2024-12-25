using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaREST.Repositories
{
    public class StallRepository
    {
        private readonly ArenaDbContext _context;

        public StallRepository(ArenaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stall>> GetAllStalls()
        {
            return await _context.Stalls.ToListAsync();
        }

        public async Task<Stall> AddStall(Stall stall)
        {
            _context.Stalls.Add(stall);
            await _context.SaveChangesAsync();
            return stall;
        }

        public async Task<Stall?> UpdateStall(int stallId, Stall updatedStall)
        {
            var stall = await _context.Stalls.FindAsync(stallId);
            if (stall == null) return null;

            stall.Name = updatedStall.Name;
            stall.Coordinates = updatedStall.Coordinates;
            stall.Type = updatedStall.Type;
            await _context.SaveChangesAsync();
            return stall;
        }

        public async Task<bool> DeleteStall(int stallId)
        {
            var stall = await _context.Stalls.FindAsync(stallId);
            if (stall == null) return false;

            _context.Stalls.Remove(stall);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
