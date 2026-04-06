using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.DTOs.HotelDTOs;
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
    public class HotelServiceTests
    {
        private readonly Mock<IHotelRepository> _hotelRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMemoryCache> _cacheMock;
        private readonly HotelService _service;

        public HotelServiceTests()
        {
            _hotelRepoMock = new Mock<IHotelRepository>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IMemoryCache>();

            _service = new HotelService(
                _hotelRepoMock.Object,
                _mapperMock.Object,
                _cacheMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_WhenCacheIsHit_ShouldNotCallRepository()
        {
            // Arrange
            var cachedHotels = new List<HotelDto> { new HotelDto { Name = "Cached Hotel" } };
            object? outValue = cachedHotels;

            _cacheMock
                .Setup(x => x.TryGetValue(CacheKeys.HOTELS, out outValue))
                .Returns(true);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().BeEquivalentTo(cachedHotels);
            _hotelRepoMock.Verify(x => x.GetAllAsync(), Times.Never);
        }

        [Fact]
        public async Task GetHotelsForMapAsync_ShouldReturnCorrectCoordinates()
        {
            // Arrange
            var hotels = new List<Hotel>
            {
                new Hotel { Id = 1, Name = "Grand Hotel", Latitude = 38.5m, Longitude = 68.7m }
            };
            _hotelRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(hotels);

            // Act
            var result = await _service.GetHotelsForMapAsync();

            // Assert
            result.Should().HaveCount(1);
            result[0].Name.Should().Be("Grand Hotel");
            result[0].Latitude.Should().Be(38.5);
            result[0].Longitude.Should().Be(68.7);
        }

        [Fact]
        public async Task UpdateAsync_WhenHotelNotFound_ShouldThrowException()
        {
            // Arrange
            int hotelId = 99;
            _hotelRepoMock.Setup(x => x.GetByIdAsync(hotelId)).ReturnsAsync((Hotel)null!);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync(hotelId, new UpdateHotelDto()));
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnMappedDto()
        {
            // Arrange
            var createDto = new CreateHotelDto { Name = "New Hotel" };
            var hotel = new Hotel { Id = 1, Name = "New Hotel" };
            var expectedDto = new HotelDto { Id = 1, Name = "New Hotel" };

            _mapperMock.Setup(m => m.Map<Hotel>(createDto)).Returns(hotel);
            _hotelRepoMock.Setup(r => r.CreateAsync(hotel)).ReturnsAsync(hotel);
            _mapperMock.Setup(m => m.Map<HotelDto>(hotel)).Returns(expectedDto);

            // Act
            var result = await _service.CreateAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("New Hotel");
            _hotelRepoMock.Verify(r => r.CreateAsync(It.IsAny<Hotel>()), Times.Once);
        }
    }
}