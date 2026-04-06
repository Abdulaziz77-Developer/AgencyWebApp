using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.DTOs.FlightDto;
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
    public class FlightServiceTests
    {
        private readonly Mock<IFlightRepository> _flightRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMemoryCache> _cacheMock;
        private readonly FlightService _service;

        public FlightServiceTests()
        {
            _flightRepoMock = new Mock<IFlightRepository>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IMemoryCache>();

            _service = new FlightService(
                _flightRepoMock.Object,
                _mapperMock.Object,
                _cacheMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_WhenCacheIsEmpty_ShouldFetchFromRepo()
        {
            // Arrange
            var flights = new List<Flight> { new Flight { Id = 1, AirPlaneName = "Boeing" } };
            var dtos = new List<FlightDto> { new FlightDto { AirPlaneName = "Boeing" } };
            object? outValue = null;

            _cacheMock.Setup(x => x.TryGetValue(CacheKeys.FLIGHTS, out outValue)).Returns(false);
            _flightRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(flights);
            _mapperMock.Setup(x => x.Map<List<FlightDto>>(flights)).Returns(dtos);
            _cacheMock.Setup(m => m.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>());

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            _flightRepoMock.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetFlightsForMapAsync_ShouldMapCoordinatesCorrectly()
        {
            // Arrange
            var flights = new List<Flight>
            {
                new Flight { Id = 1, FromLatitude = 38.5M, FromLongitude = 68.7M, ToLatitude = 40.7M, ToLongitude = -74.0M }
            };
            _flightRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(flights);

            // Act
            var result = await _service.GetFlightsForMapAsync();

            // Assert
            result.Should().HaveCount(1);
            result[0].FromLatitude.Should().Be(38.5);
            result[0].ToLongitude.Should().Be(-74.0);
        }

        [Fact]
        public async Task UpdateAsync_WhenFlightExists_ShouldUpdateFieldsAndSave()
        {
            // Arrange
            int flightId = 1;
            var flight = new Flight { Id = flightId, AirPlaneName = "Old Name" };
            var updateDto = new UpdateFlightDto { AirPlaneName = "New Name" };

            _flightRepoMock.Setup(x => x.GetByIdAsync(flightId)).ReturnsAsync(flight);

            // Act
            await _service.UpdateAsync(flightId, updateDto);

            // Assert
            flight.AirPlaneName.Should().Be("New Name");
            _flightRepoMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}