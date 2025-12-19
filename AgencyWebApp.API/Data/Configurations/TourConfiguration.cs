using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgencyWebApp.API.Models;

namespace AgencyWebApp.Data.Configurations
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
