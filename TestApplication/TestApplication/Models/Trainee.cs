namespace TestApplication.Models
{
    public class Trainee
    {
        public int id { get; set; }
        public string  Name { get; set; }
        public string address { get; set; }
        
        public List<Crsresult> Crsresults { get; set; }
    }
}
