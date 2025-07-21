namespace ParadiseAvenueMuslimCemetery
{
    public interface IEmailSender
    {
        Task SendEmailAsync(String Name, String EmailAddress, String Amount);
    }
}
