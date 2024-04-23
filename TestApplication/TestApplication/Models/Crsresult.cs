namespace TestApplication.Models
{
    public class Crsresult
    {
        public int id { get; set; }
        public int degree { get; set; }

        public int CourseId { get; set; }
        public Course course { get; set; }

        public  int TraineeID { get; set; }
        public Trainee Trainee { get; set; }


    }
}
