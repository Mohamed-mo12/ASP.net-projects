using System.ComponentModel.DataAnnotations;

namespace E_commerce.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
