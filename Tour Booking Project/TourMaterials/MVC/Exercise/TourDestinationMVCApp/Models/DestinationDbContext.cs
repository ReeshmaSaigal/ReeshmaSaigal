using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TourDestinationMVCApp.Models
{
    public class DestinationDbContext:DbContext
    {
        public DestinationDbContext(DbContextOptions<DestinationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthUser> Users { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthUser>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<AuthUser>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
    }
}
