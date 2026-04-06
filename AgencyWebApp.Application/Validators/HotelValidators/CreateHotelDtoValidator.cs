using FluentValidation;
using AgencyWebApp.Application.DTOs.HotelDTOs;

namespace AgencyWebApp.Application.Validators.HotelValidators
{
    public class CreateHotelDtoValidator : AbstractValidator<CreateHotelDto>
    {
        public CreateHotelDtoValidator()
        {
            // 1. Название и адрес
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hotel name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");

            // 2. Локация
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");

            // 3. Гео-координаты
            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");
            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");

            // 4. Описание (сделаем минимум 10 символов для информативности)
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(10).WithMessage("Description is too short.");

            // 5. Финансы
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price per night must be greater than 0.");

            // 6. Фото (простая проверка на URL)
            RuleFor(x => x.PhotoUrl)
                .NotEmpty().WithMessage("Photo URL is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Invalid Photo URL format.");
        }
    }
}