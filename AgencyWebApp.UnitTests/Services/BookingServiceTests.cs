using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.DTOs.BookingDTOs;
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
    public class BookingServiceTests
    {
        private readonly Mock<IBookingRepository> _bookingRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMemoryCache> _cacheMock;
        private readonly BookingService _service;

        public BookingServiceTests()
        {
            _bookingRepoMock = new Mock<IBookingRepository>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<IMemoryCache>();

            _service = new BookingService(
                _bookingRepoMock.Object,
                _mapperMock.Object,
                _cacheMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_WhenCacheIsEmpty_ShouldFetchFromRepoAndSetCache()
        {
            // Arrange
            var bookings = new List<Booking> { new Booking { Id = 1, TourId = 10 } };
            var dtos = new List<BookingDto> { new BookingDto { Id = 1, TourId = 10 } };
            object? outValue = null;

            _cacheMock.Setup(x => x.TryGetValue(CacheKeys.BOOKINGS, out outValue)).Returns(false);
            _bookingRepoMock.Setup(x => x.GetAllAsync()).ReturnsAsync(bookings);
            _mapperMock.Setup(x => x.Map<List<BookingDto>>(bookings)).Returns(dtos);

            // Имитация записи в кэш
            _cacheMock.Setup(m => m.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>());

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().HaveCount(1);
            _bookingRepoMock.Verify(x => x.GetAllAsync(), Times.Once);
            _cacheMock.Verify(m => m.CreateEntry(CacheKeys.BOOKINGS), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_WhenBookingExists_ShouldReturnDto()
        {
            // Arrange
            int bookingId = 1;
            var booking = new Booking { Id = bookingId };
            var dto = new BookingDto { Id = bookingId };

            _bookingRepoMock.Setup(x => x.GetByIdAsync(bookingId)).ReturnsAsync(booking);
            _mapperMock.Setup(x => x.Map<BookingDto>(booking)).Returns(dto);

            // Act
            var result = await _service.GetByIdAsync(bookingId);

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().Be(bookingId);
        }

        [Fact]
        public async Task UpdateAsync_WhenBookingDoesNotExist_ShouldThrowException()
        {
            // Arrange
            int bookingId = 999;
            _bookingRepoMock.Setup(x => x.GetByIdAsync(bookingId)).ReturnsAsync((Booking)null!);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync(bookingId, new UpdateBookingDto()));
        }
    }
}