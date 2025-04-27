using System.Threading.Tasks;

namespace MusicQuiz.Application.Interfaces
{
    public interface IEmailSender
    {
        /// <summary>
        /// Send an email asynchronously.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}