
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
            builder.HasData(
                 new Review
                 {
                     Id = 1,
                     Text = "Путешествие по Памирскому тракту изменило мою жизнь! Очень рекомендую всем любителям гор.",
                     CreatedAt = new DateTime(2025, 12, 10),
                     UserId = 1,
                     TourId = 1,
                     HotelId = 7,
                     FlightId = null
                 },
                 new Review
                 {
                     Id = 2,
                     Text = "Отель Dushanbe Serena — лучшее место для проживания. Очень профессиональный и вежливый персонал.",
                     CreatedAt = new DateTime(2025, 12, 15),
                     UserId = 2,
                     TourId = null,
                     HotelId = 1,
                     FlightId = null
                 },
                 new Review
                 {
                     Id = 3,
                     Text = "Рейс из Москвы в Душанбе прошел вовремя, полет был очень комфортным. Спасибо!",
                     CreatedAt = new DateTime(2026, 01, 05),
                     UserId = 3,
                     TourId = null,
                     HotelId = null,
                     FlightId = 1
                 },
                 new Review
                 {
                     Id = 4,
                     Text = "Озеро Искандеркуль просто захватывает дух. Наш гид рассказал много интересных легенд.",
                     CreatedAt = new DateTime(2026, 01, 10),
                     UserId = 4,
                     TourId = 4,
                     HotelId = 2,
                     FlightId = null
                 },
                 new Review
                 {
                     Id = 5,
                     Text = "Отличный сервис в Hyatt Regency. Выбор блюд на завтрак был просто потрясающим.",
                     CreatedAt = new DateTime(2026, 01, 12),
                     UserId = 5,
                     TourId = null,
                     HotelId = 2,
                     FlightId = null
                 },
                 new Review
                 {
                     Id = 6,
                     Text = "Крепость Хулбук — это настоящая скрытая жемчужина Хатлона. Обязательно к посещению для любителей истории.",
                     CreatedAt = new DateTime(2026, 01, 14),
                     UserId = 6,
                     TourId = 9,
                     HotelId = 9,
                     FlightId = null
                 },
                 new Review
                 {
                     Id = 7,
                     Text = "Руины Пенджикента впечатляют. Тур по Семи озерам немного утомительный, но он того стоит!",
                     CreatedAt = new DateTime(2026, 01, 15),
                     UserId = 7,
                     TourId = 2,
                     HotelId = 4,
                     FlightId = null
                 },
                 new Review
                 {
                     Id = 8,
                     Text = "Перелет Somon Air в Худжанд был быстрым и спокойным. Никаких нареканий.",
                     CreatedAt = new DateTime(2026, 01, 16),
                     UserId = 8,
                     TourId = null,
                     HotelId = null,
                     FlightId = 3
                 },
                 new Review
                 {
                     Id = 9,
                     Text = "Санаторий в Ходжа-Обигарм — уникальное место. Идеально подходит для оздоровления и релаксации.",
                     CreatedAt = new DateTime(2026, 01, 18),
                     UserId = 9,
                     TourId = 5,
                     HotelId = 10,
                     FlightId = null
                 },
                 new Review
                 {
                     Id = 10,
                     Text = "Классная поездка в Варзобское ущелье на выходные. Отличный способ сбежать от городской жары!",
                     CreatedAt = new DateTime(2026, 01, 20),
                     UserId = 10,
                     TourId = 10,
                     HotelId = 3,
                     FlightId = null
                 }
            ); 
        }
    }
}
