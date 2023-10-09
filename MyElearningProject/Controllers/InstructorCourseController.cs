using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorCourseController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            var email = Session["CurrentMail"];
            var values = context.Courses.Where(x => x.Instructor.Email == email).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult VideoList(int id)
        {
          
            var values = context.WatchCourses.Where(x => x.CourseID == id).ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult VideoList(WatchCourse watchCourse)
        {
           
            context.WatchCourses.Add(watchCourse);
            context.SaveChanges();
            return RedirectToAction("Index","InstructorCourse");
        }
        
    }
}