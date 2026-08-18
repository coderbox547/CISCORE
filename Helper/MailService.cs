using System.Net;
using System.Net.Mail;
using CisCore.Models;

namespace CisCore.Helper
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MailService> _logger;

        public MailService(IConfiguration configuration, ILogger<MailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(Mail model)
        {
            var mailSettings = _configuration.GetSection("MailSettings");

            string toAddress   = mailSettings["ToAddress"]!;
            string fromAddress = mailSettings["FromAddress"]!;
            string subject     = mailSettings["Subject"]!;
            string smtpHost    = mailSettings["SmtpHost"]!;
            int    smtpPort    = int.Parse(mailSettings["SmtpPort"]!);
            string smtpUser    = mailSettings["SmtpUser"]!;
            string smtpPass    = mailSettings["SmtpPassword"]!;

            try
            {
                using var mail = new MailMessage(new MailAddress(fromAddress,"Enquiry"), new MailAddress(toAddress));
                mail.Subject  = subject;
                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;

                // Build body and attach file based on form type
                if (model.Position != null && model.file != null)
                {
                    // Career form
                    mail.Body = $"{model.Name},{model.Email},{model.Phone_No},{model.Position}";

                    using var ms = new MemoryStream();
                    await model.file.CopyToAsync(ms);
                    ms.Position = 0;
                    mail.Attachments.Add(new Attachment(ms, model.file.FileName));
                    await SendAsync(mail, smtpHost, smtpPort, smtpUser, smtpPass);
                }
                else if (model.Service != null && model.Role != null)
                {
                    // Contact form
                    mail.Body = $"{model.Name},{model.Email},{model.Phone_No},{model.Message},{model.Role},{model.Service}";
                    await SendAsync(mail, smtpHost, smtpPort, smtpUser, smtpPass);
                }
                else if (model.Country != null && model.Role != null)
                {
                    // Get-a-quote form with file
                    mail.Body = $"{model.Name},{model.Email},{model.Phone_No},{model.Message},{model.Role},{model.Country},{model.Company_Name}";

                    if (model.file != null)
                    {
                        using var ms = new MemoryStream();
                        await model.file.CopyToAsync(ms);
                        ms.Position = 0;
                        mail.Attachments.Add(new Attachment(ms, model.file.FileName));
                    }
                    await SendAsync(mail, smtpHost, smtpPort, smtpUser, smtpPass);
                }
                else if (model.Subscribe != null)
                {
                    // Subscribe form
                    mail.Body = model.Subscribe;
                    await SendAsync(mail, smtpHost, smtpPort, smtpUser, smtpPass);
                }
                else
                {
                    // Generic enquiry / portfolio
                    mail.Body = $"{model.Name},{model.Email},{model.Phone_No},{model.Message}";
                    await SendAsync(mail, smtpHost, smtpPort, smtpUser, smtpPass);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email");
                throw;
            }
        }

        private static async Task SendAsync(MailMessage mail, string host, int port, string user, string password)
        {
            using var smtp = new SmtpClient(host, port)
            {
                EnableSsl            = true,
                UseDefaultCredentials = false,
                Credentials          = new NetworkCredential(user, password),
                DeliveryMethod       = SmtpDeliveryMethod.Network
            };
            // SmtpClient.SendMailAsync in .NET 8
            await smtp.SendMailAsync(mail);
        }
    }
}
