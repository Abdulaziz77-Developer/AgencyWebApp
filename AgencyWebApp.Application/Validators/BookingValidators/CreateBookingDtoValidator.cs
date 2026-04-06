using FluentValidation;
using AgencyWebApp.Application.DTOs.BookingDTOs;

namespace AgencyWebApp.Application.Validators.BookingValidators
{
    public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingDtoValidator()
        {
            
            // UserId is not provided or is less than or equal to 0, the validation will fail with a message indicating that UserId must be a positive number.
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be a positive number.");

            // Validation rules for creating a booking:
            // 1. UserId is required and must be a positive integer (greater than 0)

            RuleFor(x => x)
                .Must(x => x.TourId.HasValue || x.HotelId.HasValue || x.FlightId.HasValue)
                .WithMessage("At least one service (Tour, Hotel, or Flight) must be selected for booking.");

            // 3. Tourid is optional, but if provided, it must be greater than 0
            RuleFor(x => x.TourId)
                .GreaterThan(0).WithMessage("Invalid TourId.")
                .When(x => x.TourId.HasValue);

            // 4. HotelId is optional, but if provided, it must be greater than 0
            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Invalid HotelId.")
                .When(x => x.HotelId.HasValue);

            // 5. FlightId is optional, but if provided, it must be greater than 0
            RuleFor(x => x.FlightId)
                .GreaterThan(0).WithMessage("Invalid FlightId.")
                .When(x => x.FlightId.HasValue);
        }
    }
}