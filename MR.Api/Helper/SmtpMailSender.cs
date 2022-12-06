using MR.Api.Configurations;
using System.Net.Mail;
using System.Text;

namespace MR.Api.Helper
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly ILogger<SmtpEmailSender> _logger;
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _client;
        private SmtpConfiguration _smtpConf;

        public SmtpEmailSender(ILogger<SmtpEmailSender> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _smtpConf = _configuration.GetSection(nameof(SmtpConfiguration)).Get<SmtpConfiguration>();

            _client = new SmtpClient
            {
                Host = _smtpConf.Host,
                Port = _smtpConf.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            if (!string.IsNullOrEmpty(_smtpConf.Password))
                _client.Credentials = new System.Net.NetworkCredential(_smtpConf.Login, _smtpConf.Password);
            else
                _client.UseDefaultCredentials = true;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var from = _smtpConf.From;
                var mail = new MailMessage(from, email);
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = htmlMessage;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure; 


                _client.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
