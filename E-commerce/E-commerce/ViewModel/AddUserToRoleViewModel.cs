using System.ComponentModel.DataAnnotations;

namespace E_commerce.ViewModel
{
    public class AddUserToRoleViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; set; }
        [Required]
        public string RoleName { get; set; }

    }
}
