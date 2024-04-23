using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class TraineeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult StudentDegree(int id)
        {
            var result = context.trainees.Find(id); 

           var studentName = (from p in context.trainees
                             where p.id == id
                             select p.Name).FirstOrDefault();
            
           ViewBag.Name = studentName;

            var studentdegree = (from p in context.crsresults
                                where p.TraineeID == id
                                select p.degree).FirstOrDefault();

            var student = context.trainees.Where(x => x.id == id).
                Select(x => x.Name).FirstOrDefault();
            ViewBag.Names = student;

            ViewBag.degree = studentdegree;

            var courseName = (from p in context.crsresults
                             join y in context.trainees on p.TraineeID equals y.id
                             join z in context.Courses on p.CourseId equals z.id
                             where y.id == id
                             select z.name).FirstOrDefault();

            ViewBag.coursename = courseName;                  

                                 

            return View("Show2",result);
        }
    }
}
