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
            return await _context.Stalls
                .Select(stall => new Stall
                {
                    StallId = stall.StallId,
                    Name = stall.Name ?? "Unnamed Stall", 
                    Type = stall.Type ?? "Unknown", 
                    Coordinates = stall.Coordinates ?? "0,0", 
                    EventId = stall.EventId, 
                    Floor = stall.Floor ?? "Unknown Floor" 
                })
                .ToListAsync();
        }


        public async Task<Stall> AddAndReturnStall(Stall stall)
        {
            var result = _context.Stalls.Add(stall);
            await _context.SaveChangesAsync();

            return result.Entity;
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
