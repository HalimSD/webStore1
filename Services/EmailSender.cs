using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace WebPWrecover.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
             var message1 = new MimeMessage();

                message1.From.Add(new MailboxAddress("Banana Boat", "testprojecthr@gmail.com"));
                message1.To.Add(new MailboxAddress(email));
                message1.Subject = subject.ToString();
                var builder = new BodyBuilder();
                builder.HtmlBody = message;
                message1.Body = builder.ToMessageBody();
                var client = new SmtpClient();
               
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("testprojecthr@gmail.com", "1.TestProjectC");
                    client.Send(message1);
               

                   return client.SendAsync(message1);

            // string api1 = "SG.P7RtRsyNSlWQ";
            // string api2 = "uSCP2fDqvQ.6";
            // string api3 = "cJ4QvUWqLpzE755nkQ-G";
            // string api4 = "Bcc2YJvngOm85TUwEHEPvk";
           
            // apiKey = api1 + api2 + api3 + api4;
            // var client = new SendGridClient(apiKey);
            // var msg = new SendGridMessage()
            // {
            //     From = new EmailAddress("testprojecthr@gmail.com", "Banana Boat"),
            //     Subject = subject,
            //     PlainTextContent = message,
            //     HtmlContent = message
            // };
            // msg.AddTo(new EmailAddress(email));

            // // Disable click tracking.
            // // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            // msg.SetClickTracking(true, true);

            // return client.SendEmailAsync(msg);

            // {
            //     var email = model.Email;
            //     var message = new MimeMessage();

            //     message.From.Add(new MailboxAddress("Banana Boat", "testprojecthr@gmail.com"));
            //     message.To.Add(new MailboxAddress(email));
            //     message.Subject = "Your order";
            //     var builder = new BodyBuilder();
            //     builder.TextBody = @"Beste klant,
            //     Bedankt voor je bestelling. 
            //     Je facatuur vind je terug in de bijlage van deze mail.";
            //     builder.Attachments.Add(_appEnvironment.WebRootPath + "/images/reportPDF/Report.pdf");
            //     message.Body = builder.ToMessageBody();
            //     using (var client = new SmtpClient())
            //     {
            //         client.Connect("smtp.gmail.com", 587, false);
            //         client.Authenticate("testprojecthr@gmail.com", "1.Password");
            //         client.Send(message);
            //         client.Disconnect(true);
            //     }
            // }
        }
    }
}