using Microsoft.EntityFrameworkCore;
using ArenaREST.Models;

namespace ArenaREST.Context
{
    public class ArenaDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Stall> Stalls { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public ArenaDbContext(DbContextOptions<ArenaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary keys
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.AdminID);

            modelBuilder.Entity<Stall>()
                .HasKey(s => s.StallId);

            modelBuilder.Entity<MenuItem>()
                .HasKey(mi => mi.ItemId);

            modelBuilder.Entity<Event>()
                .HasKey(e => e.EventID);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.OrderItemId);

        {
            // Configure primary keys
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<OrderItem>().HasKey(oi => oi.OrderItemId);

            // Configure relationships
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }



            base.OnModelCreating(modelBuilder);
        }
    }
}
