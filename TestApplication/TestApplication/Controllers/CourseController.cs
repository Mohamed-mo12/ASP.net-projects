using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class CourseController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult GetALL()
        {
            var result = context.Courses.Include(x => x.Crsresults).ToList();
            return View("Index",result);
        }

        public IActionResult GetDetails(int id) {

            var result = context.Courses.Find(id);
            return View("Show", result); 
        
        }

        public IActionResult newcourse() {

            return View("NewCourse");
        
        }
        // primitive type 
        public IActionResult SaveData(string name, int degree ) {
            Course course = new Course();
            course.name = name;
            course.degree = degree;
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("GetALL");

        }
        // with complex type 
        public IActionResult SaveData2(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("GetALL");

        }

        // Edit 
        public IActionResult Edit(int id ) {

            var course = context.Courses.FirstOrDefault(p=>p.id==id);
            return View("Edit", course); 
        
        }

        [HttpPost]
        public IActionResult SaveEdit(Course course ,int id) {
            var editcourse = context.Courses.FirstOrDefault(x => x.id == id);
            editcourse.name = course.name;
            editcourse.degree = course.degree;
            context.SaveChanges(); 
            return RedirectToAction("GetALL");
        
        }

       

    }
}
