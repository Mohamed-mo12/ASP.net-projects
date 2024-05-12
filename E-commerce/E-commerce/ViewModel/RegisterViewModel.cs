using System.ComponentModel.DataAnnotations;
using E_commerce.CustomValid; 

namespace E_commerce.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(30,ErrorMessage ="Max Length is 30")]
        [Display(Name ="Full Name")]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
