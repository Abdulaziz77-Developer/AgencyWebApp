using FluentValidation;
using AgencyWebApp.Application.DTOs.UserDTOs;

namespace AgencyWebApp.Application.Validators.UserValidators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            // Name validation (if provided)
            RuleFor(x => x.FullName)
                .MinimumLength(3).WithMessage("Full name must be at least 3 characters.")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.FullName));

            // Email validation (if provided)
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("A valid email address is required.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            // Password security (if provided)
            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("New password must be at least 8 characters.")
                .Matches(@"[A-Z]").WithMessage("New password must contain an uppercase letter.")
                .Matches(@"[a-z]").WithMessage("New password must contain a lowercase letter.")
                .Matches(@"[0-9]").WithMessage("New password must contain a digit.")
                .When(x => !string.IsNullOrEmpty(x.Password));

            // Role validation (if provided)
            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Invalid user role.")
                .When(x => x.Role.HasValue);

            // Coordinates are skipped as per your previous instruction
        }
    }
}