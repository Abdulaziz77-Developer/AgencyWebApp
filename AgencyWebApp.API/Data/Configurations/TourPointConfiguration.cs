using AgencyWebApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyWebApp.API.Data.Configurations
{
    public class TourPointConfiguration : IEntityTypeConfiguration<TourPoint>
    {
        public void Configure(EntityTypeBuilder<TourPoint> builder)
        {
            builder.HasKey(tp => tp.Id);
            builder.HasOne(tp => tp.Tour)
                   .WithMany(t => t.TourPoints)
                   .HasForeignKey(tp => tp.TourId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
