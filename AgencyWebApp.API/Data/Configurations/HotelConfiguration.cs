using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgencyWebApp.API.Models;

namespace AgencyWebApp.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasMany(h => h.Reviews)
                   .WithOne(r => r.Hotel)
                   .HasForeignKey(r => r.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(h => h.Bookings)
                   .WithOne(b => b.Hotel)
                   .HasForeignKey(b => b.HotelId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
