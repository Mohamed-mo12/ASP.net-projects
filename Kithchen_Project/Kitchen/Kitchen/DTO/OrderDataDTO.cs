using System.ComponentModel.DataAnnotations;

namespace Kitchen.DTO
{
    public class OrderDataDTO
    {
        [Required]
        [MaxLength(150)]
        [Display(Name="Full Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name="Phone Number")]
        public int Phone { get; set; }
        [Required]
        [MaxLength(500)]
        [Display(Name= "Delivery Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name= "Additional Notes")]
        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
