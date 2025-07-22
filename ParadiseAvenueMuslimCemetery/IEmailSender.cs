using ParadiseAvenueMuslimCemetery.Models;

namespace ParadiseAvenueMuslimCemetery
{
    public interface IEmailSender
    {
        Task SendEmailAsync(String Name, String EmailAddress, String Amount);
        Task SendEmailForRegistrationAsync(Registration registration);

        Task SendEmailForSignupAsync(Email email);

    }
}
