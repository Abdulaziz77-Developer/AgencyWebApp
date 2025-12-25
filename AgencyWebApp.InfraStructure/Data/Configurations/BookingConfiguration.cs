using AgencyWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyWebApp.Infrastructure.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bookings)
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Tour)
                   .WithMany(t => t.Bookings)
                   .HasForeignKey(b => b.TourId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(b => b.Hotel)
                   .WithMany(h => h.Bookings)
                   .HasForeignKey(b => b.HotelId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(b => b.Flight)
                   .WithMany(f => f.Bookings)
                   .HasForeignKey(b => b.FlightId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
