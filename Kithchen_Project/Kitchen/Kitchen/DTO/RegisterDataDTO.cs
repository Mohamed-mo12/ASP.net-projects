using Kitchen.Model;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.DTO
{
    public class RegisterDataDTO
    {
        [Required]
        [MaxLength(150,ErrorMessage ="MaxLength is 150")]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Subscription Duration ")]
        public SubscriptionEnum Subscription { get; set; }
    }
}
