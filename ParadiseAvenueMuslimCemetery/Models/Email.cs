using System.ComponentModel.DataAnnotations;

namespace ParadiseAvenueMuslimCemetery.Models
{
    public class Email
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Amount { get; set; }
    }
}
