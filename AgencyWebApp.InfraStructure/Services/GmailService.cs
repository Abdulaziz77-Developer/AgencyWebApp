using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using AgencyWebApp.Application.Services.Interfaces;

namespace AgencyWebApp.Infrastructure.Services
{
    public class GmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public GmailService(IConfiguration config)
        {
            _config = config;
        }

        // Основной метод отправки
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var fromEmail = _config["EmailSettings:SenderEmail"];
            var password = _config["EmailSettings:AppPassword"];
            Console.WriteLine($"--- DEBUG EMAIL ---");
            Console.WriteLine($"FROM (из конфига): '{fromEmail}'");
            Console.WriteLine($"TO (получатель): '{to}'");
            Console.WriteLine($"-------------------");

            if (string.IsNullOrWhiteSpace(fromEmail)) 
                throw new Exception("ОШИБКА: SenderEmail пустой в appsettings.json!");
        
            if (string.IsNullOrWhiteSpace(to)) 
                throw new Exception("ОШИБКА: Адрес получателя (to) пришел пустым!"); 
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fromEmail, password)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail!),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);

            await client.SendMailAsync(mailMessage);
        }

        // Метод специально для кода подтверждения
        public async Task SendOtpEmailAsync(string to, string code)
        {
            string subject = "Код подтверждения бронирования";
            string htmlBody = $@"
                <div style='font-family: Arial; text-align: center; border: 1px solid #ddd; padding: 20px;'>
                    <h2 style='color: #333;'>Подтверждение бронирования</h2>
                    <p>Введите этот код на странице оформления:</p>
                    <h1 style='color: #007bff; font-size: 40px; letter-spacing: 5px;'>{code}</h1>
                    <p style='color: #777;'>Код действителен в течение 10 минут.</p>
                </div>";

            // Просто вызываем базовый метод
            await SendEmailAsync(to, subject, htmlBody);
        }
        public async Task SendBookingConfirmedAsync(string to, string bookingDetails)
        {
            string subject = "Ваше бронирование подтверждено! 🎉";
            string body = $@"
            <h3>Отличные новости!</h3>
            <p>Администратор подтвердил ваше бронирование.</p>
            <p><strong>Детали:</strong> {bookingDetails}</p>
            <p>Ждем вас!</p>";
    
            await SendEmailAsync(to, subject, body);
        }

        public async Task SendBookingRejectedAsync(string to, string reason)
        {
            string subject = "Обновление по вашему бронированию";
            string body = $@"
            <h3>К сожалению, бронирование отклонено</h3>
            <p>Администратор не смог подтвердить ваш запрос.</p>
            {(string.IsNullOrEmpty(reason) ? "" : $"<p><strong>Причина:</strong> {reason}</p>")}
            <p>Пожалуйста, свяжитесь с нами для уточнения деталей.</p>";

            await SendEmailAsync(to, subject, body);
        }
    }
}