using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Device
    {
        public int Id { get; set; }

        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Icon { get; set; } = string.Empty; 
    }
}
