using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.DTOs.ReviewDTOs;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;
using AgencyWebApp.Application.Common;

namespace AgencyWebApp.UnitTests.Services
{
    public class ReviewServiceTests
    {
        private readonly Mock<IReviewRepository> _reviewRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMemoryCache> _cacheMock;
        private readonly ReviewService _service;

        public ReviewServiceTests()
        {
            _reviewRepoMock = new Mock<IReviewRepository>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IMemoryCache>();

            // Создаем экземпляр сервиса с моками
            _service = new ReviewService(
                _reviewRepoMock.Object,
                _mapperMock.Object,
                _cacheMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_WhenCacheIsNotEmpty_ShouldReturnCachedData()
        {
            // Arrange (Подготовка)
            var cachedReviews = new List<ReviewDto>
            {
                new ReviewDto { Text = "From Cache" }
            };

            object? outValue = cachedReviews;

            // Настраиваем мок кэша так, чтобы TryGetValue вернул true и наши данные
            _cacheMock
                .Setup(x => x.TryGetValue(CacheKeys.REVIEWS, out outValue))
                .Returns(true);

            // Act (Действие)
            var result = await _service.GetAllAsync();

            // Assert (Проверка)
            result.Should().NotBeNull();
            result.First().Text.Should().Be("From Cache");

            // Проверяем, что в базу НЕ ходили
            _reviewRepoMock.Verify(x => x.GetAllAsync(), Times.Never);
        }

        [Fact]
        public async Task GetAllAsync_WhenCacheIsEmpty_ShouldCallRepoAndFillCache()
        {
            // Arrange (Подготовка)
            var dbReviews = new List<Review> { new Review { Id = 1, Text = "From DB" } };
            var mappedDtos = new List<ReviewDto> { new ReviewDto { Text = "From DB" } };

            object? outValue = null;

            // 1. Кэш пуст
            _cacheMock
                .Setup(x => x.TryGetValue(CacheKeys.REVIEWS, out outValue))
                .Returns(false);

            // 2. Настраиваем репозиторий
            _reviewRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(dbReviews);

            // 3. Настраиваем маппер
            _mapperMock.Setup(x => x.Map<List<ReviewDto>>(dbReviews)).Returns(mappedDtos);

            // 4. Имитируем создание записи в кэше (нужно для .Set)
            _cacheMock
                .Setup(m => m.CreateEntry(It.IsAny<object>()))
                .Returns(Mock.Of<ICacheEntry>());

            // Act (Действие)
            var result = await _service.GetAllAsync();

            // Assert (Проверка)
            result.Should().NotBeNull();
            result.First().Text.Should().Be("From DB");

            // Проверяем, что в базу ходили 1 раз
            _reviewRepoMock.Verify(x => x.GetAllAsync(), Times.Once);

            // Проверяем, что маппер работал
            _mapperMock.Verify(x => x.Map<List<ReviewDto>>(dbReviews), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_WhenReviewExists_ShouldReturnMappedDto()
        {
            // Arrange
            int id = 1;
            var review = new Review { Id = id, Text = "Found" };
            var dto = new ReviewDto { Text = "Found" };

            _reviewRepoMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(review);
            _mapperMock.Setup(x => x.Map<ReviewDto>(review)).Returns(dto);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            result.Should().NotBeNull();
            result!.Text.Should().Be("Found");
        }
    }
}