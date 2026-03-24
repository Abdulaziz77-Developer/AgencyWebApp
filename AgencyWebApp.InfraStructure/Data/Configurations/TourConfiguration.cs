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

            

            builder.HasMany(t => t.Reviews)
                   .WithOne(r => r.Tour)
                   .HasForeignKey(r => r.TourId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Bookings)
                   .WithOne(b => b.Tour)
                   .HasForeignKey(b => b.TourId)
                   .OnDelete(DeleteBehavior.SetNull);
           builder.HasData(
    new Tour
    {
        Id = 1,
        Title = "Приключение на Памирском тракте",
        Region = "ГБАО",
        Duration = 7,
        Rating = 5,
        Status = true,
        Description = "Легендарное путешествие по высокогорным дорогам Памира с посещением города Хорог.",
        Price = 550.00m,
        StartLatitude = 38.5737m,
        StartLongitude = 68.7938m,
        PhotoUrl = "https://images.unsplash.com/photo-1581414441460-7058866e409b?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 2,
        Title = "Древний Пенджикент и озера",
        Region = "Согдийская область",
        Duration = 3,
        Rating = 5,
        Status = true,
        Description = "Исследуйте руины Саразма и невероятные Семь озер (Хафт-Кул).",
        Price = 120.00m,
        StartLatitude = 39.4969m,
        StartLongitude = 67.6103m,
        PhotoUrl = "https://images.unsplash.com/photo-1541829070764-84a7d30dee6b?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 3,
        Title = "Выходные в Душанбе",
        Region = "Душанбе",
        Duration = 2,
        Rating = 4,
        Status = true,
        Description = "Посещение Национального музея, памятника Исмоили Сомони и колоритных местных базаров.",
        Price = 85.00m,
        StartLatitude = 38.5858m,
        StartLongitude = 68.7725m,
        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/National_Museum_of_Tajikistan.jpg/800px-National_Museum_of_Tajikistan.jpg"
    },
    new Tour
    {
        Id = 4,
        Title = "Побег к озеру Искандеркуль",
        Region = "Фанские горы",
        Duration = 3,
        Rating = 5,
        Status = true,
        Description = "Посетите легендарное озеро Александра Македонского и знаменитый водопад «Фанская Ниагара».",
        Price = 150.00m,
        StartLatitude = 39.0833m,
        StartLongitude = 68.3667m,
        PhotoUrl = "https://images.unsplash.com/photo-1563290328-9710279603e8?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 5,
        Title = "Оздоровление в Ходжа-Обигарм",
        Region = "Варзоб",
        Duration = 10,
        Rating = 4,
        Status = true,
        Description = "Отдых и лечение в знаменитом бальнеологическом санатории с уникальными термальными парами.",
        Price = 300.00m,
        StartLatitude = 38.8953m,
        StartLongitude = 68.7914m,
        PhotoUrl = "https://images.unsplash.com/photo-1544161515-4ab6ce6db874?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 6,
        Title = "Мургаб: Крыша мира",
        Region = "Восточный Памир",
        Duration = 12,
        Rating = 5,
        Status = true,
        Description = "Жизнь кочевников, яки и фантастические «лунные» ландшафты высокогорья у границы с Китаем.",
        Price = 750.00m,
        StartLatitude = 38.1702m,
        StartLongitude = 73.9647m,
        PhotoUrl = "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 7,
        Title = "Тур в Худжандскую крепость",
        Region = "Согдийская область",
        Duration = 2,
        Rating = 4,
        Status = true,
        Description = "Исторический тур в крепость V века и прогулка по живописному берегу Сырдарьи.",
        Price = 90.00m,
        StartLatitude = 40.2825m,
        StartLongitude = 69.6221m,
        PhotoUrl = "https://images.unsplash.com/photo-1523393160341-9c869066666d?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 8,
        Title = "Природа Сари-Хосор",
        Region = "Хатлон",
        Duration = 5,
        Rating = 5,
        Status = true,
        Description = "Эко-тур в одну из самых красивых и отдаленных долин Таджикистана.",
        Price = 210.00m,
        StartLatitude = 38.2167m,
        StartLongitude = 69.8333m,
        PhotoUrl = "https://images.unsplash.com/photo-1501785888041-af3ef285b470?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 9,
        Title = "История крепости Хулбук",
        Region = "Хатлон",
        Duration = 1,
        Rating = 4,
        Status = true,
        Description = "Однодневная поездка в реконструированный дворец средневековых царей Хутталя.",
        Price = 45.00m,
        StartLatitude = 37.7772m,
        StartLongitude = 69.5539m,
        PhotoUrl = "https://images.unsplash.com/photo-1590059132218-22ca52103723?auto=format&fit=crop&w=800"
    },
    new Tour
    {
        Id = 10,
        Title = "День в Варзобском ущелье",
        Region = "РРП",
        Duration = 1,
        Rating = 5,
        Status = true,
        Description = "Самая популярная зона отдыха рядом с Душанбе: реки, горы и свежий воздух.",
        Price = 35.00m,
        StartLatitude = 38.7411m,
        StartLongitude = 68.8144m,
        PhotoUrl = "https://images.unsplash.com/photo-1470770841072-f978cf4d019e?auto=format&fit=crop&w=800"
    }
);
        }
    }
}
