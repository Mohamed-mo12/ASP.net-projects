using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplication.Models;
using TestApplication.ViewModel;

namespace TestApplication.Controllers
{
    public class CourseController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult GetALL()
        {
        //    CourseandTraineeviewmodel courseandTraineeviewmodel = new CourseandTraineeviewmodel();
             var result = context.Courses.Include(x => x.Crsresults).ToList();
         //   var result = context.Courses.FirstOrDefault();
          //  courseandTraineeviewmodel.name = result.name;
           // courseandTraineeviewmodel.degree = result.degree;
           // courseandTraineeviewmodel.Mindegree = result.Mindegree;
           // var r = context.trainees.FirstOrDefault();
            //courseandTraineeviewmodel.Name = r.Name;

            return View("Index",result);
        }

        public IActionResult GetDetails(int id) {

            var result = context.Courses.Find(id);
            return View("Show", result); 
        
        }
        public IActionResult Add() {
            //  var result = context.Courses.Include(x => x.Crsresults).ToList();
            ViewData["Crs"] = context.crsresults.ToList();
            return View("Addcourse");
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveAdd(Course course) {

            if (ModelState.IsValid==true)
            {

                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("GetALL");
            }
            else
            {
                return View("Addcourse");
            }



        }

        public IActionResult update(int id) {
            var result = context.Courses.Find(id);
            ViewData["crs"] = context.crsresults.FirstOrDefault(x => x.id == id);
            return View("Updatecourse",result);
        
        }
        public IActionResult saveupdate(int id,Course course) {

            if (ModelState.IsValid==true)
            {

                    var r = context.Courses.FirstOrDefault(x => x.id == id);
                    r.name = course.name;
                    r.degree = course.degree;
                    r.Mindegree = course.Mindegree;
                    context.SaveChanges();
                    return RedirectToAction("GetALL");
            }

                return View("Updatecourse");
            

                  
        
        
        }
        public IActionResult Delete(int id , Course course )
        {
            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction("GetALL");


        }
        public IActionResult CheckDegree(int degree,int Mindegree) {

            if (Mindegree < degree)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        
        }

       

    }
}
/*
       [HttpGet]
        public IActionResult newcourse() {

            return View("NewCourse");
        
        }
        // primitive type 
        public IActionResult SaveData(string name, int degree ) {
            if (ModelState.IsValid==true)
            {
                Course course = new Course();
                course.name = name;
                course.degree = degree;
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("GetALL");
            }
            else
            {
                return View("NewCourse");
            }
            

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
            if (ModelState.IsValid==true)
            {
                editcourse.name = course.name;
                editcourse.degree = course.degree;
                context.SaveChanges();
                return RedirectToAction("GetALL");
            }
            else
            {
                return View("Edit"); 
            }
           
           
        
        }
 */