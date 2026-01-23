using AgencyWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyWebApp.Infrastructure.Data.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.AirPlaneName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(f => f.Reviews)
                   .WithOne(r => r.Flight)
                   .HasForeignKey(r => r.FlightId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Bookings)
                   .WithOne(b => b.Flight)
                   .HasForeignKey(b => b.FlightId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasData(
            new Flight
            {
                Id = 1,
                AirPlaneName = "Boeing 737-800",
                FlightNumber = 101,
                FromCity = "Moscow (DME)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 05, 10, 12, 0, 0),
                ArrivalTime = new DateTime(2026, 05, 10, 18, 0, 0),
                FromLatitude = 55.4103m,
                FromLongitude = 37.9024m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 250.00m,
                Status = "Scheduled"
            },
            new Flight
            {
                Id = 2,
                AirPlaneName = "Airbus A320",
                FlightNumber = 202,
                FromCity = "Istanbul (IST)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 05, 12, 09, 30, 0),
                ArrivalTime = new DateTime(2026, 05, 12, 16, 15, 0),
                FromLatitude = 41.2753m,
                FromLongitude = 28.7519m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 320.00m,
                Status = "Scheduled"
            },
            new Flight
            {
                Id = 3,
                AirPlaneName = "Boeing 737-300",
                FlightNumber = 303,
                FromCity = "Dushanbe (DYU)",
                ToCity = "Khujand (LBD)",
                DepartureTime = new DateTime(2026, 05, 15, 08, 00, 0),
                ArrivalTime = new DateTime(2026, 05, 15, 08, 50, 0),
                FromLatitude = 38.5433m,
                FromLongitude = 68.8249m,
                ToLatitude = 40.2152m,
                ToLongitude = 69.6944m,
                Price = 45.00m,
                Status = "Active"
            },
            new Flight
            {
                Id = 4,
                AirPlaneName = "Boeing 737-800",
                FlightNumber = 404,
                FromCity = "Dubai (DXB)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 05, 18, 22, 00, 0),
                ArrivalTime = new DateTime(2026, 05, 19, 02, 30, 0),
                FromLatitude = 25.2532m,
                FromLongitude = 55.3657m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 380.00m,
                Status = "Scheduled"
            },
            new Flight
            {
                Id = 5,
                AirPlaneName = "Airbus A321",
                FlightNumber = 505,
                FromCity = "Tashkent (TAS)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 05, 20, 14, 00, 0),
                ArrivalTime = new DateTime(2026, 05, 20, 15, 00, 0),
                FromLatitude = 41.2575m,
                FromLongitude = 69.2817m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 110.00m,
                Status = "Active"
            },
            new Flight
            {
                Id = 6,
                AirPlaneName = "Boeing 737-800",
                FlightNumber = 606,
                FromCity = "Almaty (ALA)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 05, 22, 10, 00, 0),
                ArrivalTime = new DateTime(2026, 05, 22, 11, 45, 0),
                FromLatitude = 43.3520m,
                FromLongitude = 77.0115m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 140.00m,
                Status = "Scheduled"
            },
            new Flight
            {
                Id = 7,
                AirPlaneName = "Boeing 787 Dreamliner",
                FlightNumber = 707,
                FromCity = "Frankfurt (FRA)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 05, 25, 20, 00, 0),
                ArrivalTime = new DateTime(2026, 05, 26, 06, 00, 0),
                FromLatitude = 50.0333m,
                FromLongitude = 8.5705m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 650.00m,
                Status = "Delayed"
            },
            new Flight
            {
                Id = 8,
                AirPlaneName = "Airbus A320",
                FlightNumber = 808,
                FromCity = "Delhi (DEL)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 05, 28, 04, 00, 0),
                ArrivalTime = new DateTime(2026, 05, 28, 07, 30, 0),
                FromLatitude = 28.5562m,
                FromLongitude = 77.1000m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 290.00m,
                Status = "Scheduled"
            },
            new Flight
            {
                Id = 9,
                AirPlaneName = "Boeing 737-800",
                FlightNumber = 909,
                FromCity = "Munich (MUC)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 06, 01, 11, 00, 0),
                ArrivalTime = new DateTime(2026, 06, 01, 20, 00, 0),
                FromLatitude = 48.3537m,
                FromLongitude = 11.7750m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 580.00m,
                Status = "Active"
            },
            new Flight
            {
                Id = 10,
                AirPlaneName = "Embraer 190",
                FlightNumber = 110,
                FromCity = "Urumqi (URC)",
                ToCity = "Dushanbe (DYU)",
                DepartureTime = new DateTime(2026, 06, 03, 15, 00, 0),
                ArrivalTime = new DateTime(2026, 06, 03, 17, 30, 0),
                FromLatitude = 43.9071m,
                FromLongitude = 87.4742m,
                ToLatitude = 38.5433m,
                ToLongitude = 68.8249m,
                Price = 420.00m,
                Status = "Scheduled"
            }
        );
        }
    }
}