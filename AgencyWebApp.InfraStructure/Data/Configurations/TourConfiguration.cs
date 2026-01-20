using AgencyWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyWebApp.Infrastructure.Data.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18,2)");

            // precision для координат старта тура
            builder.Property(t => t.StartLatitude)
                   .HasPrecision(9, 6);

            builder.Property(t => t.StartLongitude)
                   .HasPrecision(9, 6);

            builder.HasOne(t => t.Hotel)
                   .WithMany(h => h.Tours)
                   .HasForeignKey(t => t.HotelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Reviews)
                   .WithOne(r => r.Tour)
                   .HasForeignKey(r => r.TourId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Bookings)
                   .WithOne(b => b.Tour)
                   .HasForeignKey(b => b.TourId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
