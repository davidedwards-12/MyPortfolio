using System.Net;
using System.Net.Mail;

namespace MyPortfolio.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string to, string subject, string message)
        {
            var smtpClient = new SmtpClient(_config["EmailSettings:SmtpServer"])
            {
                Port = int.Parse(_config["EmailSettings:SmtpPort"]),
                Credentials = new NetworkCredential(_config["EmailSettings:SmtpUser"], _config["EmailSettings:SmtpPass"]),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("no-reply@example.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(to);

            //smtpClient.Send(mailMessage);

            try
            {
                smtpClient.Send(mailMessage);
            } 
            catch(SmtpException ex)
            {
                Console.WriteLine($"SMTP Exception: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }
        }
    }
}
