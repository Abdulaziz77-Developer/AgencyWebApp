

using AgencyWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyWebApp.Infrastructure.Data.Configurations
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
            builder.HasData(
            new Hotel
            {
                Id = 1,
                Name = "Dushanbe Serena Hotel",
                Address = "14 Rudaki Ave",
                City = "Dushanbe",
                Country = "Tajikistan",
                Description = "A luxury 5-star hotel in the heart of the capital with traditional Tajik architecture.",
                Price = 160.00m,
                Rating = 5,
                Latitude = 38.5737m,
                Longitude = 68.7938m,
                PhotoUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 2,
                Name = "Hyatt Regency Dushanbe",
                Address = "26/1 Ismoili Somoni Ave",
                City = "Dushanbe",
                Country = "Tajikistan",
                Description = "Modern lakeside hotel perfect for business and leisure travelers.",
                Price = 185.00m,
                Rating = 5,
                Latitude = 38.5858m,
                Longitude = 68.7725m,
                PhotoUrl = "https://images.unsplash.com/photo-1551882547-ff43c63e1c04?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 3,
                Name = "Atlas Hotel",
                Address = "63 Nisor Muhammad St",
                City = "Dushanbe",
                Country = "Tajikistan",
                Description = "Boutique hotel featuring Tajik national fabrics and a beautiful garden.",
                Price = 85.00m,
                Rating = 4,
                Latitude = 38.5601m,
                Longitude = 68.8120m,
                PhotoUrl = "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 4,
                Name = "Armon Aparthotel",
                Address = "22 Kamoli Khujandi St",
                City = "Khujand",
                Country = "Tajikistan",
                Description = "The best apartments in Khujand city center with a river view.",
                Price = 75.00m,
                Rating = 4,
                Latitude = 40.2825m,
                Longitude = 69.6221m,
                PhotoUrl = "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 5,
                Name = "Sugdiyon Hotel",
                Address = "15 Lenin St",
                City = "Khujand",
                Country = "Tajikistan",
                Description = "Classic hotel located near the historical Panjshanbe Bazaar.",
                Price = 55.00m,
                Rating = 3,
                Latitude = 40.2790m,
                Longitude = 69.6300m,
                PhotoUrl = "https://images.unsplash.com/photo-1561501900-3701fa6a0864?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 6,
                Name = "Karon Palace",
                Address = "Kalaikhumb Village",
                City = "Darvoz",
                Country = "Tajikistan",
                Description = "The gateway to the Pamirs. Luxury comfort in a remote mountain setting.",
                Price = 95.00m,
                Rating = 5,
                Latitude = 38.4571m,
                Longitude = 70.7831m,
                PhotoUrl = "https://images.unsplash.com/photo-1445019980597-93fa8acb246c?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 7,
                Name = "Lal Hotel",
                Address = "52 Lenin St",
                City = "Khorog",
                Country = "Tajikistan",
                Description = "Famous Pamiri guesthouse known for its hospitality and traditional food.",
                Price = 65.00m,
                Rating = 4,
                Latitude = 37.4896m,
                Longitude = 71.5511m,
                PhotoUrl = "https://images.unsplash.com/photo-1582719478250-c89cae4df85b?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 8,
                Name = "Grand Hotel Bokhtar",
                Address = "10 Vahdat Ave",
                City = "Bokhtar",
                Country = "Tajikistan",
                Description = "A comfortable central hotel for travelers exploring the Khatlon region.",
                Price = 60.00m,
                Rating = 3,
                Latitude = 37.8364m,
                Longitude = 68.7802m,
                PhotoUrl = "https://images.unsplash.com/photo-1495365200479-c4ed1d35e1aa?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 9,
                Name = "Seven In Boutique",
                Address = "3 Loik Sherali St",
                City = "Dushanbe",
                Country = "Tajikistan",
                Description = "Cozy and quiet boutique hotel located in a premium residential area.",
                Price = 90.00m,
                Rating = 4,
                Latitude = 38.5900m,
                Longitude = 68.7850m,
                PhotoUrl = "https://images.unsplash.com/photo-1571896349842-33c89424de2d?auto=format&fit=crop&w=800"
            },
            new Hotel
            {
                Id = 10,
                Name = "Hilton Dushanbe",
                Address = "48 Ayni St",
                City = "Dushanbe",
                Country = "Tajikistan",
                Description = "Premium hospitality close to the airport and Dushanbe city center.",
                Price = 145.00m,
                Rating = 5,
                Latitude = 38.5672m,
                Longitude = 68.8051m,
                PhotoUrl = "https://images.unsplash.com/photo-1590490360182-c33d57733427?auto=format&fit=crop&w=800"
            }
        );
        }
    }
}
