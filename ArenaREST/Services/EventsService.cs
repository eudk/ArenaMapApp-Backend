using ArenaREST.Models;
using ArenaREST.Repositories;

namespace ArenaREST.Services
{
    public class EventService
    {
        private readonly EventRepository _eventRepository;

        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }

        public async Task<Event?> GetEventById(int eventId)
        {
            return await _eventRepository.GetEventById(eventId);
        }
    }
}
