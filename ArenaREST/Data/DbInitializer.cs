using ArenaREST.Context;
using ArenaREST.Models;

namespace ArenaREST
{
    public static class DbInitializer
    {
        public static void Initialize(ArenaDbContext context)
        {
            if (context.Events.Any()) return; 

            var events = new[]
            {
                new Event { EventName = "Norlys Cup - Denmark vs. Bahrain", EventDate = new DateTime(2025, 1, 9) },
                new Event { EventName = "Pantera Live", EventDate = new DateTime(2025, 1, 26) },
                new Event { EventName = "Toto with Special Guest", EventDate = new DateTime(2025, 2, 22) },
                //test af events hardkodet
            };

            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}
