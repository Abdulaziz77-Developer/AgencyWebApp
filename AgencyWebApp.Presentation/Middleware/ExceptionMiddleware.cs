using System.Net;
using System.Text.Json;

namespace AgencyWebApp.Web.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Идем дальше по конвейеру (к контроллеру)
                await _next(context);
            }
            catch (Exception ex)
            {
                // Если где-то в сервисе упал throw new Exception — мы его поймаем здесь!
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            // По умолчанию возвращаем 400 (Bad Request), так как наши сервисы 
            // кидают ошибки валидации или "Not Found" через Exception
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message, // Тот самый текст из throw new Exception
                Detailed = exception.InnerException?.Message // Для отладки
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}