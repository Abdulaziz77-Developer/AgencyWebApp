using AgencyWebApp.Application.DTOs.UserDTOs;
using AgencyWebApp.Application.Services.Interfaces;
using AgencyWebApp.Domain.Models;
using AgencyWebApp.Domain.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;

namespace AgencyWebApp.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserDto> _createValidator;
        private readonly IValidator<UpdateUserDto> _updateValidator;

        public UserService(IUserRepository userRepo, IMapper mapper, IValidator<UpdateUserDto> updateValidator, IValidator<CreateUserDto> createValidator)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
          
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            // 1. Validate the incoming user data (FullName, Email format, Password strength)
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                // Extract the specific error message from CreateUserDtoValidator
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // 2. Check if a user with this email already exists
            var existingUser = await _userRepo.GetByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists");
            }

            // 3. Map the DTO to the User domain model
            var user = _mapper.Map<User>(dto);

            // 4. Save the new user to the database
            var created = await _userRepo.CreateAsync(user);

            // 5. Return the result mapped to a UserDto
            return _mapper.Map<UserDto>(created);
        }

        public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
        {
            // 1. Validate the update request
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.First().ErrorMessage;
                throw new Exception(errorMessage);
            }

            // 2. Retrieve the existing user
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            // 3. Handle Password Hashing manually if provided
            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                // Set password to null in DTO so AutoMapper doesn't overwrite the hash with plain text
                dto.Password = null;
            }

            // 4. Apply remaining updates using AutoMapper
            // This handles FullName, Email, Role, and Coordinates automatically
            _mapper.Map(dto, user);

            // 5. Persist changes to the database
            await _userRepo.SaveChangesAsync();

            // 6. Return the updated result
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepo.DeleteAsync(id);
        }
    }

}
