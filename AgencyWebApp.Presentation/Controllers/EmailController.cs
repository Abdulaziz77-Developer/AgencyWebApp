using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using AgencyWebApp.Application.Services.Interfaces;

namespace AgencyWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache; // Для временного хранения кода

        public OtpController(IEmailService emailService, IMemoryCache cache)
        {
            _emailService = emailService;
            _cache = cache;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequest request)
        {
            if (string.IsNullOrEmpty(request.Email)) return BadRequest("Email обязателен");

            // 1. Генерируем случайный код
            var code = new Random().Next(100000, 999999).ToString();

            // 2. Сохраняем в кэш на 5 минут (ключ — email)
            _cache.Set(request.Email, code, TimeSpan.FromMinutes(5));

            // 3. Отправляем письмо через твой исправленный сервис
            await _emailService.SendOtpEmailAsync(request.Email, code);

            return Ok(new { message = "Код отправлен" });
        }

        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp([FromBody] OtpVerifyRequest request)
        {
            // Проверяем, есть ли такой код в памяти для этого email
            if (_cache.TryGetValue(request.Email, out string? savedCode))
            {
                if (savedCode == request.Code)
                {
                    return Ok(new { success = true });
                }
            }
            return BadRequest(new { success = false, message = "Неверный или просроченный код" });
        }
        [HttpPost("confirm-notification")]
        public async Task<IActionResult> SendConfirmation([FromQuery] string email, [FromQuery] int id)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Email is required");

            await _emailService.SendBookingConfirmedAsync(email, $"Бронирование #{id}");
            return Ok(new { message = "Письмо о подтверждении отправлено" });
        }
        [HttpPost("reject-notification")]
        public async Task<IActionResult> SendRejection([FromQuery] string email, [FromQuery] int id)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Email is required");

            await _emailService.SendBookingRejectedAsync(email, "К сожалению, мы не смогли подтвердить ваше бронирование.");
            return Ok(new { message = "Письмо об отказе отправлено" });
        }
    }

    // Модели для запросов
    public record OtpRequest(string Email);
    public record OtpVerifyRequest(string Email, string Code);
}