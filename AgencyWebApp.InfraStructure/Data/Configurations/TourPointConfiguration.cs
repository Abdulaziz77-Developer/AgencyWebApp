using AgencyWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AgencyWebApp.Infrastructure.Data.Configurations
{
    public class TourPointConfiguration : IEntityTypeConfiguration<TourPoint>
    {
        public void Configure(EntityTypeBuilder<TourPoint> builder)
        {
            builder.HasKey(tp => tp.Id);

            // precision для координат точек тура
            builder.Property(tp => tp.Latitude)
                   .HasPrecision(9, 6);

            builder.Property(tp => tp.Longitude)
                   .HasPrecision(9, 6);

            builder.HasOne(tp => tp.Tour)
                   .WithMany(t => t.TourPoints)
                   .HasForeignKey(tp => tp.TourId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
