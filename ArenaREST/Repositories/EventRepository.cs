using ArenaREST.Context;
using ArenaREST.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaREST.Repositories
{
    public class EventRepository
    {
        private readonly ArenaDbContext _context;

        public EventRepository(ArenaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventById(int eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }
    }
}
