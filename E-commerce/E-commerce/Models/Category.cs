using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Game> Game { get; set; } = new List<Game>();


    }
}
