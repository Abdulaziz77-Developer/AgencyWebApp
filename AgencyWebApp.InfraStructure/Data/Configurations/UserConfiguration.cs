using AgencyWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AgencyWebApp.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.Password)
                   .IsRequired();

            builder.Property(u => u.Role)
                   .HasConversion<int>()
                   .IsRequired();

            // precision для координат домашнего адреса (nullable поддерживается)
            builder.Property(u => u.HomeLatitude)
                   .HasPrecision(9, 6);

            builder.Property(u => u.HomeLongitude)
                   .HasPrecision(9, 6);

            builder.HasMany(u => u.Reviews)
                   .WithOne(r => r.User)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Bookings)
                   .WithOne(b => b.User)
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("Password123!");

            builder.HasData(
                new User { Id = 1, FullName = "Алишер Саидов", Email = "alisher@mail.tj", Password = passwordHash },
                new User { Id = 2, FullName = "Мадина Каримова", Email = "madina@gmail.com", Password = passwordHash },
                new User { Id = 3, FullName = "Бахтиёр Назаров", Email = "bakhtier@list.ru", Password = passwordHash },
                new User { Id = 4, FullName = "Нигина Рахимова", Email = "nigina@yandex.ru", Password = passwordHash },
                new User { Id = 5, FullName = "Парвиз Ходжаев", Email = "parviz@outlook.com", Password = passwordHash },
                new User { Id = 6, FullName = "Зарина Олимова", Email = "zarina@mail.tj", Password = passwordHash },
                new User { Id = 7, FullName = "Рустам Эшонов", Email = "rustam@google.com", Password = passwordHash },
                new User { Id = 8, FullName = "Ситора Джумаева", Email = "sitora@inbox.ru", Password = passwordHash },
                new User { Id = 9, FullName = "Фирдавс Гафуров", Email = "firdavs@rambler.ru", Password = passwordHash },
                new User { Id = 10, FullName = "Лола Шарипова", Email = "lola@tj-travel.tj", Password = passwordHash }
            );
        }
    }
}
