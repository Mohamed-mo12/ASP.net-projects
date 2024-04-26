using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class Trainee
    {
        public int id { get; set; }

        [RegularExpression("[a-z] {3,25}")]
        public string  Name { get; set; }
        public string address { get; set; }
        
        public List<Crsresult> Crsresults { get; set; }
    }
}
