using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.DTOs.TourDTOs;
using AgencyWebApp.Application.DTOs.MapDTOs;
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
    public class TourServiceTests
    {
        private readonly Mock<ITourRepository> _tourRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMemoryCache> _cacheMock;
        private readonly TourService _service;

        public TourServiceTests()
        {
            _tourRepoMock = new Mock<ITourRepository>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IMemoryCache>();

            _service = new TourService(
                _tourRepoMock.Object,
                _mapperMock.Object,
                _cacheMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_WhenCacheMiss_ShouldCallRepositoryAndFillCache()
        {
            // Arrange
            var tours = new List<Tour> { new Tour { Id = 1, Title = "Pamir Trip" } };
            var dtos = new List<TourDto> { new TourDto { Title = "Pamir Trip" } };
            object? outValue = null;

            _cacheMock.Setup(x => x.TryGetValue(CacheKeys.TOURS, out outValue)).Returns(false);
            _tourRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(tours);
            _mapperMock.Setup(x => x.Map<List<TourDto>>(tours)).Returns(dtos);
            _cacheMock.Setup(m => m.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>());

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().HaveCount(1);
            result.First().Title.Should().Be("Pamir Trip");
            _tourRepoMock.Verify(x => x.GetAllAsync(), Times.Once);
            _cacheMock.Verify(m => m.CreateEntry(CacheKeys.TOURS), Times.Once);
        }

        [Fact]
        public async Task GetToursForMapAsync_ShouldReturnValidMapData()
        {
            // Arrange
            var tours = new List<Tour>
            {
                new Tour { Id = 1, Title = "Mountains", StartLatitude = 38.5m, StartLongitude = 68.7m }
            };
            _tourRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(tours);

            // Act
            var result = await _service.GetToursForMapAsync();

            // Assert
            result.Should().NotBeEmpty();
            result[0].Title.Should().Be("Mountains");
            result[0].StartLatitude.Should().Be(38.5);
        }

        [Fact]
        public async Task UpdateAsync_WhenTourExists_ShouldUpdateStatusAndFields()
        {
            // Arrange
            int tourId = 1;
            var tour = new Tour { Id = tourId, Title = "Old Title", Status = false };
            var updateDto = new UpdateTourDto { Title = "New Title", Status = true };

            _tourRepoMock.Setup(x => x.GetByIdAsync(tourId)).ReturnsAsync(tour);

            // Act
            await _service.UpdateAsync(tourId, updateDto);

            // Assert
            tour.Title.Should().Be("New Title");
            tour.Status.Should().BeTrue();
            _tourRepoMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_WhenTourNotFound_ShouldReturnNull()
        {
            // Arrange
            _tourRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Tour)null!);

            // Act
            var result = await _service.GetByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }
    }
}