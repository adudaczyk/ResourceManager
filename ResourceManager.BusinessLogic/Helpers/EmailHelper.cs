using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ResourceManager.BusinessLogic.Helpers
{
    public class EmailHelper
    {
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendUserVerificationEmail(string email)
        {
            var subject = "Resource Manager - Verification Link";
            var body = "Please confirm your account by clicking this link: xxx";

            SendEmail(email, subject, body);
        }

        public void SendResetPasswordLink(string email)
        {
            var subject = "Resource Manager - Reset Password Link";
            var body = "Please reset your password by clicking this link: xxx";

            SendEmail(email, subject, body);
        }

        private void SendEmail(string email, string subject, string body)
        {
            SmtpClient client = new SmtpClient(_configuration["SMTP_Server"]);
            client.Port = int.Parse(_configuration["SMTP_Port"]);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_configuration["Email_Login"], _configuration["Email_Password"]);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("no-reply@ebrit.com");
            mailMessage.To.Add(email);
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            client.Send(mailMessage);
        }
    }
}
