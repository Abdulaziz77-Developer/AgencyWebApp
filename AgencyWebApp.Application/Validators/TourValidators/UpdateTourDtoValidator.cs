using FluentValidation;
using AgencyWebApp.Application.DTOs.TourDTOs;

namespace AgencyWebApp.Application.Validators.TourValidators
{
    public class UpdateTourDtoValidator : AbstractValidator<UpdateTourDto>
    {
        public UpdateTourDtoValidator()
        {
            // Title validation (if provided)
            RuleFor(x => x.Title)
                .MaximumLength(150).WithMessage("Title cannot exceed 150 characters.")
                .When(x => !string.IsNullOrEmpty(x.Title));

            // Description validation (if provided)
            RuleFor(x => x.Description)
                .MinimumLength(20).WithMessage("Description should be at least 20 characters long.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            // Price validation
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.")
                .When(x => x.Price.HasValue);

            // Duration validation
            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Duration must be at least 1 day.")
                .When(x => x.Duration.HasValue);

            // Rating validation (Standard 1-5 scale)
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            // Geography validation
            RuleFor(x => x.StartLatitude)
                .InclusiveBetween(-90, 90).WithMessage("Invalid Latitude.")
                .When(x => x.StartLatitude.HasValue);

            RuleFor(x => x.StartLongitude)
                .InclusiveBetween(-180, 180).WithMessage("Invalid Longitude.")
                .When(x => x.StartLongitude.HasValue);

            // Photo validation
            RuleFor(x => x.PhotoUrl)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Invalid Photo URL format.")
                .When(x => !string.IsNullOrEmpty(x.PhotoUrl));
        }
    }
}