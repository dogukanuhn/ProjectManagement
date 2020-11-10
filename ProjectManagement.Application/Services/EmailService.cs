using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using ProjectManagement.Domain.Common;


namespace ProjectManagement.Application.Services
{
    public class EmailService : IEmailService
    {
     
            public void Send(string from, string to, string subject, string html)
            {
                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                    // send email
                    using var smtp = new SmtpClient();
                    smtp.Connect("localhost", 25, SecureSocketOptions.StartTls);
            
                    smtp.Send(email);
                    smtp.Disconnect(true);

        }
        
    }
}
