namespace AgencyWebApp.Application.Services.Interfaces
{
    public interface IEmailService
    {
        // Базовый метод для любых писем
        Task SendEmailAsync(string to, string subject, string body);
        
        // Удобный метод именно для OTP кода
        Task SendOtpEmailAsync(string to, string code);
    }
}