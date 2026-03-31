using System.Collections.Generic;
using TourBookingMVCApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace TourBookingMVCApplication.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourBookingForm> TourBookingForms { get; set; }
        public DbSet<AuthUser> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        public DbSet<ParticipantInformation> participantInformations { get; set; }

    }
}
