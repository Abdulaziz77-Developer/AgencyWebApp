
using AgencyWebApp.API.Models;
using AgencyWebApp.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AgencyWebApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet для всех моделей
        public DbSet<User> Users => Set<User>();
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<Tour> Tours => Set<Tour>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Review> Reviews => Set<Review>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
