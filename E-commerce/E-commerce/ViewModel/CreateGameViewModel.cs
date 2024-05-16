using E_commerce.CustomValid;
using E_commerce.Models;
using E_commerce.Setting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.ViewModel
{
    public class CreateGameViewModel
    {
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories  { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name="Device")]    
        public List<int> selectedDevice { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();


       // [Cover(FileSetting.Allowextension)]
      //  [CoverSize(FileSetting.MaxSizebymega)]
        [Required]
        public IFormFile Cover { get; set; } = default!; 

    }
}
