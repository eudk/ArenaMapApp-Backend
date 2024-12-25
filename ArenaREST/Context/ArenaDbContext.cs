using Microsoft.EntityFrameworkCore;
using ArenaREST.Models;

namespace ArenaREST.Context
{
    public class ArenaDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Stall> Stalls { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; } //  MenuItems
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ArenaDbContext(DbContextOptions<ArenaDbContext> options) : base(options)
        {
        }
    }
}
