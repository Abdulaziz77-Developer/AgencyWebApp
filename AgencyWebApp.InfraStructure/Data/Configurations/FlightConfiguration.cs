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
        }
    }
}