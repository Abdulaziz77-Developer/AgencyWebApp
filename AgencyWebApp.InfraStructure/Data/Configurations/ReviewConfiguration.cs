
using AgencyWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyWebApp.Infrastructure.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Text)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Tour)
                   .WithMany(t => t.Reviews)
                   .HasForeignKey(r => r.TourId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Hotel)
                   .WithMany(h => h.Reviews)
                   .HasForeignKey(r => r.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Flight)
                   .WithMany(f => f.Reviews)
                   .HasForeignKey(r => r.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
            new Review
            {
                Id = 1,
                Text = "The Pamir Highway tour was a life-changing experience! Highly recommend.",
                CreatedAt = new DateTime(2025, 12, 10),
                UserId = 1,
                TourId = 1,
                HotelId = 7,
                FlightId = null
            },
            new Review
            {
                Id = 2,
                Text = "Dushanbe Serena Hotel is the best place to stay. Very professional staff.",
                CreatedAt = new DateTime(2025, 12, 15),
                UserId = 2,
                TourId = null,
                HotelId = 1,
                FlightId = null
            },
            new Review
            {
                Id = 3,
                Text = "The flight from Moscow to Dushanbe was on time and very comfortable.",
                CreatedAt = new DateTime(2026, 01, 05),
                UserId = 3,
                TourId = null,
                HotelId = null,
                FlightId = 1
            },
            new Review
            {
                Id = 4,
                Text = "Iskanderkul Lake is breathtaking. The tour guide was very knowledgeable.",
                CreatedAt = new DateTime(2026, 01, 10),
                UserId = 4,
                TourId = 4,
                HotelId = 2,
                FlightId = null
            },
            new Review
            {
                Id = 5,
                Text = "Great service at Hyatt Regency. The breakfast selection was amazing.",
                CreatedAt = new DateTime(2026, 01, 12),
                UserId = 5,
                TourId = null,
                HotelId = 2,
                FlightId = null
            },
            new Review
            {
                Id = 6,
                Text = "Hulbuk Fortress is a hidden gem in Khatlon. A must-visit for history lovers.",
                CreatedAt = new DateTime(2026, 01, 14),
                UserId = 6,
                TourId = 9,
                HotelId = 9,
                FlightId = null
            },
            new Review
            {
                Id = 7,
                Text = "Panjakent ruins are impressive. Seven Lakes tour was a bit tiring but worth it.",
                CreatedAt = new DateTime(2026, 01, 15),
                UserId = 7,
                TourId = 2,
                HotelId = 4,
                FlightId = null
            },
            new Review
            {
                Id = 8,
                Text = "Somon Air flight to Khujand was quick and smooth. No complaints.",
                CreatedAt = new DateTime(2026, 01, 16),
                UserId = 8,
                TourId = null,
                HotelId = null,
                FlightId = 3
            },
            new Review
            {
                Id = 9,
                Text = "The sanatorium in Khoja-Obigarm is unique. Perfect for health and relaxation.",
                CreatedAt = new DateTime(2026, 01, 18),
                UserId = 9,
                TourId = 5,
                HotelId = 10,
                FlightId = null
            },
            new Review
            {
                Id = 10,
                Text = "Awesome day trip to Varzob Gorge. Great way to escape the city heat!",
                CreatedAt = new DateTime(2026, 01, 20),
                UserId = 10,
                TourId = 10,
                HotelId = 3,
                FlightId = null
            }
        );
        }
    }
}
