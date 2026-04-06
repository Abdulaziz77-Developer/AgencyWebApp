using FluentValidation;
using AgencyWebApp.Application.DTOs.ReviewDTOs;

namespace AgencyWebApp.Application.Validators.ReviewValidators
{
    public class CreateReviewDtoValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewDtoValidator()
        {
            // User identification
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("A valid UserId is required.");

            // Review text requirements
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Review text cannot be empty.")
                .MinimumLength(5).WithMessage("Review text is too short (minimum 5 characters).")
                .MaximumLength(1000).WithMessage("Review text is too long (maximum 1000 characters).");

            // Business Logic: A review must belong to something
            RuleFor(x => x)
                .Must(x => x.TourId.HasValue || x.HotelId.HasValue || x.FlightId.HasValue)
                .WithMessage("A review must be linked to a Tour, Hotel, or Flight.");
        }
    }
}