using AgencyWebApp.Application.Services.Implementations;
using AgencyWebApp.Application.DTOs.AuthDTOs;
using AgencyWebApp.Application.DTOs.UserDTOs;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AgencyWebApp.Domain.Enums;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using System.IdentityModel.Tokens.Jwt;

namespace AgencyWebApp.UnitTests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly AuthService _service;

        public AuthServiceTests()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _configMock = new Mock<IConfiguration>();

            // Настраиваем секретный ключ для генерации JWT (как в appsettings.json)
            _configMock.Setup(x => x["Jwt:Secret"]).Returns("ThisIsASuperLongAndSafeSecretKeyForJWTSigning123!");

            _service = new AuthService(
                _userRepoMock.Object,
                _mapperMock.Object,
                _configMock.Object);
        }

        [Fact]
        public async Task RegisterAsync_WhenUserExists_ShouldThrowException()
        {
            // Arrange
            var registerDto = new RegisterDto { Email = "test@example.com", Password = "123" };
            _userRepoMock.Setup(x => x.GetByEmailAsync(registerDto.Email))
                         .ReturnsAsync(new User()); // Возвращаем существующего юзера

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _service.RegisterAsync(registerDto));
        }

        [Fact]
        public async Task LoginAsync_WhenCredentialsValid_ShouldReturnToken()
        {
            // Arrange
            var loginDto = new LoginDto { Email = "test@example.com", Password = "Password123" };
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("Password123");

            var user = new User
            {
                Id = 1,
                Email = loginDto.Email,
                Password = hashedPassword,
                FullName = "Abdulaziz",
                Role = Role.User
            };

            _userRepoMock.Setup(x => x.GetByEmailAsync(loginDto.Email)).ReturnsAsync(user);

            // Act
            var token = await _service.LoginAsync(loginDto);

            // Assert
            token.Should().NotBeNullOrEmpty();

            // Проверяем, что это валидный JWT формат
            var handler = new JwtSecurityTokenHandler();
            handler.CanReadToken(token).Should().BeTrue();
        }

        [Fact]
        public async Task LoginAsync_WhenPasswordWrong_ShouldThrowException()
        {
            // Arrange
            var loginDto = new LoginDto { Email = "test@example.com", Password = "WrongPassword" };
            var correctHashedPassword = BCrypt.Net.BCrypt.HashPassword("RightPassword");

            var user = new User { Email = loginDto.Email, Password = correctHashedPassword };
            _userRepoMock.Setup(x => x.GetByEmailAsync(loginDto.Email)).ReturnsAsync(user);

            // Act & Assert
            var action = async () => await _service.LoginAsync(loginDto);
            await action.Should().ThrowAsync<Exception>().WithMessage("Invalid credentials");
        }
    }
}