using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.DTOs.UserDTOs;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;

namespace AgencyWebApp.UnitTests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserService _service;

        public UserServiceTests()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new UserService(_userRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateAsync_WhenEmailExists_ShouldThrowException()
        {
            // Arrange
            var dto = new CreateUserDto { Email = "exists@mail.com" };
            _userRepoMock.Setup(x => x.GetByEmailAsync(dto.Email)).ReturnsAsync(new User());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _service.CreateAsync(dto));
        }

        [Fact]
        public async Task UpdateAsync_WhenPasswordProvided_ShouldHashNewPassword()
        {
            // Arrange
            int userId = 1;
            var user = new User { Id = userId, Password = "OldHashedPassword" };
            var updateDto = new UpdateUserDto { Password = "NewSecretPassword123" };

            _userRepoMock.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync(user);

            // Act
            await _service.UpdateAsync(userId, updateDto);

            // Assert
            // Проверяем, что пароль изменился и он корректно хэширован
            user.Password.Should().NotBe("NewSecretPassword123");
            BCrypt.Net.BCrypt.Verify("NewSecretPassword123", user.Password).Should().BeTrue();
            _userRepoMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_WhenUserExists_ShouldReturnMappedDto()
        {
            // Arrange
            var user = new User { Id = 1, FullName = "Abdulaziz" };
            var dto = new UserDto { FullName = "Abdulaziz" };

            _userRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(user);
            _mapperMock.Setup(x => x.Map<UserDto>(user)).Returns(dto);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.FullName.Should().Be("Abdulaziz");
        }
    }
}