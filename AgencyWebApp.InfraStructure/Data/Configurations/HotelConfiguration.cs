

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
                Address = "проспект Рудаки, 14",
                City = "Душанбе",
                Country = "Таджикистан",
                Description = "Роскошный 5-звездочный отель в самом сердце столицы, выполненный в традиционном таджикском стиле.",
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
                Address = "проспект Исмоили Сомони, 26/1",
                City = "Душанбе",
                Country = "Таджикистан",
                Description = "Современный отель на берегу озера, идеально подходящий как для деловых поездок, так и для отдыха.",
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
                Address = "ул. Нисора Мухаммада, 63",
                City = "Душанбе",
                Country = "Таджикистан",
                Description = "Бутик-отель, оформленный с использованием национальных тканей и располагающий прекрасным садом.",
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
                Address = "ул. Камоли Худжанди, 22",
                City = "Худжанд",
                Country = "Таджикистан",
                Description = "Лучшие апартаменты в центре Худжанда с великолепным видом на реку Сырдарья.",
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
                Address = "ул. Ленина, 15",
                City = "Худжанд",
                Country = "Таджикистан",
                Description = "Классический отель, расположенный рядом с историческим рынком Панджшанбе.",
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
                Address = "поселок Калайхумб",
                City = "Дарвоз",
                Country = "Таджикистан",
                Description = "Ворота Памира. Роскошный комфорт в окружении величественных диких гор.",
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
                Address = "ул. Ленина, 52",
                City = "Хорог",
                Country = "Таджикистан",
                Description = "Знаменитый памирский гостевой дом, известный своим гостеприимством и традиционной кухней.",
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
                Address = "проспект Вахдат, 10",
                City = "Бохтар",
                Country = "Таджикистан",
                Description = "Комфортабельный отель в центре города, удобный для путешественников, изучающих Хатлонскую область.",
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
                Address = "ул. Лоика Шерали, 3",
                City = "Душанбе",
                Country = "Таджикистан",
                Description = "Уютный и тихий бутик-отель, расположенный в элитном жилом районе столицы.",
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
                Address = "ул. Айни, 48",
                City = "Душанбе",
                Country = "Таджикистан",
                Description = "Сервис премиум-класса вблизи аэропорта и центральной части Душанбе.",
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
