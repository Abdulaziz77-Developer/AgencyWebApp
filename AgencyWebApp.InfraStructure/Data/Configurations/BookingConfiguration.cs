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
            builder.HasData(
            new Booking
            {
                Id = 1,
                BookingDate = new DateTime(2026, 01, 10, 10, 0, 0),
                Status = true,
                UserId = 1,
                TourId = 1,
                HotelId = 7,
                FlightId = null
            },
            new Booking
            {
                Id = 2,
                BookingDate = new DateTime(2026, 01, 12, 14, 30, 0),
                Status = true,
                UserId = 2,
                TourId = null,
                HotelId = 1,
                FlightId = null
            },
            new Booking
            {
                Id = 3,
                BookingDate = new DateTime(2026, 01, 14, 09, 15, 0),
                Status = false,
                UserId = 3,
                TourId = null,
                HotelId = null,
                FlightId = 1
            },
            new Booking
            {
                Id = 4,
                BookingDate = new DateTime(2026, 01, 15, 11, 0, 0),
                Status = true,
                UserId = 4,
                TourId = 4,
                HotelId = 2,
                FlightId = null
            },
            new Booking
            {
                Id = 5,
                BookingDate = new DateTime(2026, 01, 16, 16, 45, 0),
                Status = true,
                UserId = 5,
                TourId = null,
                HotelId = 2,
                FlightId = null
            },
            new Booking
            {
                Id = 6,
                BookingDate = new DateTime(2026, 01, 17, 12, 0, 0),
                Status = true,
                UserId = 6,
                TourId = 9,
                HotelId = 9,
                FlightId = null
            },
            new Booking
            {
                Id = 7,
                BookingDate = new DateTime(2026, 01, 18, 18, 20, 0),
                Status = true,
                UserId = 7,
                TourId = 2,
                HotelId = 4,
                FlightId = null
            },
            new Booking
            {
                Id = 8,
                BookingDate = new DateTime(2026, 01, 19, 08, 0, 0),
                Status = false,
                UserId = 8,
                TourId = null,
                HotelId = null,
                FlightId = 3
            },
            new Booking
            {
                Id = 9,
                BookingDate = new DateTime(2026, 01, 20, 13, 10, 0),
                Status = true,
                UserId = 9,
                TourId = 5,
                HotelId = 10,
                FlightId = null
            },
            new Booking
            {
                Id = 10,
                BookingDate = new DateTime(2026, 01, 20, 15, 0, 0),
                Status = true,
                UserId = 10,
                TourId = 10,
                HotelId = 3,
                FlightId = null
            }
        );
        }
    }
}
