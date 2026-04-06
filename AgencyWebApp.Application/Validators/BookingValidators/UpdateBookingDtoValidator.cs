using FluentValidation;
using AgencyWebApp.Application.DTOs.BookingDTOs;

namespace AgencyWebApp.Application.Validators.BookingValidators
{
    public class UpdateBookingDtoValidator : AbstractValidator<UpdateBookingDto>
    {
        public UpdateBookingDtoValidator()
        {
            // Validation rules for updating a booking:
            // We allow updates to the booking, but we want to ensure that the update is valid and does not result in an empty booking.
            // The main rules are:
            // 1. Status must be defined (usually bool always has a value, but we want to fix the logic here)
            // We do not restrict it, as it can be both true and false.
            // If the user tries to update the booking and removes all services (Tour, Hotel, Flight), we want to prevent that, as it would result in an empty booking.
            RuleFor(x => x)
                .Must(x => x.TourId.HasValue || x.HotelId.HasValue || x.FlightId.HasValue)
                .WithMessage("Updating failed: A booking cannot be empty. Select at least one service.");

            // 3. Validation for TourId, HotelId, and FlightId (if they are provided, they must be greater than 0)
            RuleFor(x => x.TourId)
                .GreaterThan(0).WithMessage("Invalid TourId.")
                .When(x => x.TourId.HasValue);

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Invalid HotelId.")
                .When(x => x.HotelId.HasValue);

            RuleFor(x => x.FlightId)
                .GreaterThan(0).WithMessage("Invalid FlightId.")
                .When(x => x.FlightId.HasValue);
        }
    }
}