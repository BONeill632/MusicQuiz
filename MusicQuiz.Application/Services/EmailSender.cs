using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MusicQuiz.Application.Interfaces;

namespace MusicQuiz.Application.Services
{
    public class EmailSender(IConfiguration configuration, ILogger<EmailSender> logger) : IEmailSender
    {
        /// <summary>
        /// Send an email asynchronously.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpServer = configuration["EmailSettings:SmtpServer"];
            var port = int.Parse(configuration["EmailSettings:Port"]);
            var senderEmail = configuration["EmailSettings:SenderEmail"];
            var senderPassword = configuration["EmailSettings:SenderPassword"];
            var enableSsl = bool.Parse(configuration["EmailSettings:EnableSSL"]);

            using var client = new SmtpClient(smtpServer)
            {
                Port = port,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = enableSsl
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            try
            {
                await client.SendMailAsync(mailMessage);
                logger.LogInformation("Email sent to {Email}", email);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Email sending failed");
                throw new InvalidOperationException("Failed to send email.", ex);
            }
        }
    }
}
