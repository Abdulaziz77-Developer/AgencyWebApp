using FluentValidation;
using AgencyWebApp.Application.DTOs.FlightDto;

namespace AgencyWebApp.Application.Validators.FlightValidators
{
    public class UpdateFlightDtoValidator : AbstractValidator<UpdateFlightDto>
    {
        public UpdateFlightDtoValidator()
        {
            // Проверяем только если значения переданы (не null)

            RuleFor(x => x.AirPlaneName)
                .MaximumLength(50).WithMessage("Airplane name is too long")
                .When(x => !string.IsNullOrEmpty(x.AirPlaneName));

            RuleFor(x => x.FlightNumber)
                .GreaterThan(0).WithMessage("Flight number must be positive")
                .When(x => x.FlightNumber.HasValue);

            // Логика дат при обновлении
            RuleFor(x => x.ArrivalTime)
                .GreaterThan(x => x.DepartureTime.Value)
                .WithMessage("Arrival time must be after departure time")
                .When(x => x.ArrivalTime.HasValue && x.DepartureTime.HasValue);

            // Координаты
            RuleFor(x => x.FromLatitude).InclusiveBetween(-90, 90).When(x => x.FromLatitude.HasValue);
            RuleFor(x => x.FromLongitude).InclusiveBetween(-180, 180).When(x => x.FromLongitude.HasValue);
            RuleFor(x => x.ToLatitude).InclusiveBetween(-90, 90).When(x => x.ToLatitude.HasValue);
            RuleFor(x => x.ToLongitude).InclusiveBetween(-180, 180).When(x => x.ToLongitude.HasValue);
        }
    }
}