using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ParadiseAvenueMuslimCemetery.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;


namespace ParadiseAvenueMuslimCemetery
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string Name, string EmailAddress, string Amount)
        {
            var mail = "noreply.serviceprovider.pk@gmail.com";
            var pw = "vdch wypq eayl bwwr";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            var subject = "New Donation Received";
            var body = $"The user \"{EmailAddress}\" wants to donate ${Amount} for Paradise Avenue Muslim Charity.";

            var message = new MailMessage(from: mail, to: EmailAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = false // Set true if using HTML body
            };

            return client.SendMailAsync(message);
        }


        public Task SendEmailForSignupAsync(ParadiseAvenueMuslimCemetery.Models.Email email)
        {
            var mail = "noreply.serviceprovider.pk@gmail.com";
            var pw = "vdch wypq eayl bwwr";

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };
            var subject = "New Email Registered";
            var body = $"User with email \"{email.EmailAddress}\" has Been Registered on Paradise Avenue Muslim Cemetery.";

            var message = new MailMessage(from: mail, to: email.EmailAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = false // Set true if using HTML body
            };

            return smtp.SendMailAsync(message);
        }

        public Task SendEmailForRegistrationAsync(Registration registration)
        {
            var mail = "noreply.serviceprovider.pk@gmail.com";
            var pw = "vdch wypq eayl bwwr";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            var subject = "New Burial Registration Received";
            var body = $@"
        A new registration has been submitted:

        Name of Deceased: {registration.DeceasedName}
        Gender: {registration.Gender}
        Date of Birth: {registration.Dob:yyyy-MM-dd}
        Date of Death: {registration.Dod:yyyy-MM-dd}
        Burial Date: {registration.BurialDate:yyyy-MM-dd}
        Burial Time: {registration.BurialTime}
        Hospital: {registration.Hospital}
        Funeral Home: {registration.FuneralHome}
        Home Phone: {registration.HomePhone}
        Cell Phone: {registration.CellPhone}
        Address: {registration.Address}, {registration.City}, {registration.State}, {registration.Zip}
        Email: {registration.Email}
        Legal Representative Name: {registration.LegalName}
    ";

            var message = new MailMessage(from: mail, to: registration.Email)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            return client.SendMailAsync(message);
        }






        //public Task SendEmailForRegistrationAsync(String DeceasedName, String Gender, DateTime Dob, DateTime Dod, DateTime BurialDate, TimeSpan BurialTime, string HomePhone, string CellPhone, string Address, string State, string Zip, String Email, String LegalName, String FuneralHome)

        //{
        //    var mail = "noreply.serviceprovider.pk@gmail.com";
        //    var pw = "vdch wypq eayl bwwr";

        //    var client = new SmtpClient("smtp.gmail.com", 587)
        //    {
        //        EnableSsl = true,
        //        Credentials = new NetworkCredential(mail, pw)
        //    };

        //    var subject = "New Donation Received";
        //    var body = $"The user \"{Email}\" wants to donate ${} for Paradise Avenue Muslim Charity.";

        //    var message = new MailMessage(from: mail, to: Email)
        //    {
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = false // Set true if using HTML body
        //    };

        //    return client.SendMailAsync(message);
        //}



        //public Task SendEmailAsync(String Name, String EmailAddress, String Amount) 
        //{
        //    var mail = "noreply.serviceprovider.pk@gmail.com";
        //    var pw = "vdch wypq eayl bwwr";

        //    var client = new SmtpClient("smtp.gmail.com", 587)
        //    {
        //        EnableSsl = true,
        //        Credentials = new NetworkCredential(mail, pw)

        //    };
        //    return client.SendMailAsync(
        //        new MailMessage(from: mail,
        //to: EmailAddress,
        //        Name,
        //        Amount)
        //        );

        //}

    }
}
