using FluentValidation;
using AgencyWebApp.Application.DTOs.FlightDto;

namespace AgencyWebApp.Application.Validators.FlightValidators
{
    public class CreateFlightDtoValidator : AbstractValidator<CreateFlightDto>
    {
        public CreateFlightDtoValidator()
        {
            // 1. Самолет и номер рейса
            RuleFor(x => x.AirPlaneName)
                .NotEmpty().WithMessage("Airplane name is required")
                .MaximumLength(50).WithMessage("Name is too long");

            RuleFor(x => x.FlightNumber)
                .GreaterThan(0).WithMessage("Flight number must be positive");

            // 2. Города (Откуда -> Куда)
            RuleFor(x => x.FromCity).NotEmpty().WithMessage("Departure city is required");
            RuleFor(x => x.ToCity).NotEmpty().WithMessage("Arrival city is required");

            // 3. Логика времени (Самое важное!)
            RuleFor(x => x.DepartureTime)
                .GreaterThan(DateTime.UtcNow).WithMessage("Departure time must be in the future");

            RuleFor(x => x.ArrivalTime)
                .NotEmpty().WithMessage("Arrival time is required")
                .GreaterThan(x => x.DepartureTime).WithMessage("Arrival time must be after departure time");

            // 4. Координаты (Гео-валидация)
            RuleFor(x => x.FromLatitude).InclusiveBetween(-90, 90).WithMessage("Invalid departure latitude");
            RuleFor(x => x.FromLongitude).InclusiveBetween(-180, 180).WithMessage("Invalid departure longitude");
            RuleFor(x => x.ToLatitude).InclusiveBetween(-90, 90).WithMessage("Invalid arrival latitude");
            RuleFor(x => x.ToLongitude).InclusiveBetween(-180, 180).WithMessage("Invalid arrival longitude");

            // 5. Деньги и статус
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Flight status is required");
        }
    }
}