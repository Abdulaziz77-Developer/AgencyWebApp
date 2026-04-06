using FluentValidation;
using AgencyWebApp.Application.DTOs.HotelDTOs;

namespace AgencyWebApp.Application.Validators.HotelValidators
{
    public class UpdateHotelDtoValidator : AbstractValidator<UpdateHotelDto>
    {
        public UpdateHotelDtoValidator()
        {
            // Название (если меняется)
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.Name));

            // Гео-координаты
            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Invalid Latitude.")
                .When(x => x.Latitude.HasValue);

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Invalid Longitude.")
                .When(x => x.Longitude.HasValue);

            // Описание
            RuleFor(x => x.Description)
                .MinimumLength(10).WithMessage("Description is too short.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            // Цена (обязательна в твоем DTO, так как decimal не nullable)
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            // Фото
            RuleFor(x => x.PhotoUrl)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Invalid Photo URL format.")
                .When(x => !string.IsNullOrEmpty(x.PhotoUrl));
        }
    }
}