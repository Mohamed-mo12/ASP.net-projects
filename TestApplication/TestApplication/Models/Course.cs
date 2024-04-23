namespace TestApplication.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int degree { get; set; }
        public int Mindegree { get; set; }
        public List<Crsresult> Crsresults { get; set; }
    }
}
