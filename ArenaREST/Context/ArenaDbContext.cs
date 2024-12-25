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
        public DbSet<QRCode> QRCodes { get; set; }

        public ArenaDbContext(DbContextOptions<ArenaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .HasKey(mi => mi.ItemId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<Stall>()
                .HasKey(s => s.StallId);

            modelBuilder.Entity<QRCode>()
                .HasKey(qr => qr.QRCodeId);

            modelBuilder.Entity<QRCode>()
                .HasOne(qr => qr.Order)
                .WithOne(o => o.QRCode)
                .HasForeignKey<QRCode>(qr => qr.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
