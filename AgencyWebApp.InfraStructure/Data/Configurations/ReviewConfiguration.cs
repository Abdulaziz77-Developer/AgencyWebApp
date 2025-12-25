
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
        }
    }
}
