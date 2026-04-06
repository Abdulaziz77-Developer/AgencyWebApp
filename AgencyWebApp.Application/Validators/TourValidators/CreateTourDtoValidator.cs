using FluentValidation;
using AgencyWebApp.Application.DTOs.TourDTOs;

namespace AgencyWebApp.Application.Validators.TourValidators
{
    public class CreateTourDtoValidator : AbstractValidator<CreateTourDto>
    {
        public CreateTourDtoValidator()
        {
            // Basic Information
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Tour title is required.")
                .MaximumLength(150).WithMessage("Title cannot exceed 150 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(20).WithMessage("Description should be at least 20 characters long.");

            RuleFor(x => x.Region)
                .NotEmpty().WithMessage("Region is required.");

            // Financials
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            // Relationships
            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("A valid HotelId must be assigned to the tour.");

            // Geography (Start point)
            RuleFor(x => x.StartLatitude)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

            RuleFor(x => x.StartLongitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");

            // Media
            RuleFor(x => x.PhotoUrl)
                .NotEmpty().WithMessage("Photo URL is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Invalid Photo URL format.");
        }
    }
}