using FluentValidation;
using AgencyWebApp.Application.DTOs.ReviewDTOs;

namespace AgencyWebApp.Application.Validators.ReviewValidators
{
    public class UpdateReviewDtoValidator : AbstractValidator<UpdateReviewDto>
    {
        public UpdateReviewDtoValidator()
        {
            // Validate text only if it's being updated
            RuleFor(x => x.Text)
                .MinimumLength(5).WithMessage("Review text is too short (minimum 5 characters).")
                .MaximumLength(1000).WithMessage("Review text is too long (maximum 1000 characters).")
                .When(x => !string.IsNullOrEmpty(x.Text));

            // Business Logic: The update should not result in a "homeless" review
            // (Note: This checks the incoming DTO; in a real scenario, the existing 
            // entity in the DB still holds the old values if these are null)
            RuleFor(x => x)
                .Must(x => x.Text != null || x.TourId.HasValue || x.HotelId.HasValue || x.FlightId.HasValue)
                .WithMessage("At least one field must be provided for the update.");
        }
    }
}