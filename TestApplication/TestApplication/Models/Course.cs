using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class Course
    {
        public int id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="MaxLength is 20")]
        [MinLength(2,ErrorMessage ="MinLength is 2")]
        [UniqueName]
        public string name { get; set; }
        [Required]
        [Range(50,100,ErrorMessage ="Range Between 50,100")]
        public int degree { get; set; }
        [Required]
        [Remote(action:"CheckDegree",controller:"Course",AdditionalFields = "degree")]
        public int Mindegree { get; set; }
        public List<Crsresult> Crsresults { get; set; } = new List<Crsresult>();
        
        
       

    }
}
