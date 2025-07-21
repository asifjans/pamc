using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;


namespace ParadiseAvenueMuslimCemetery
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(String Name, String EmailAddress, String Amount) 
        {
            var mail = "noreply.serviceprovider.pk@gmail.com";
            var pw = "vdch wypq eayl bwwr";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)

            };
            return client.SendMailAsync(
                new MailMessage(from: mail,
        to: EmailAddress,
                Name,
                Amount)
                );

        }

    }
}
