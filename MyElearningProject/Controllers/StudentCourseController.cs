using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class StudentCourseController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
          
            var values = Session["CurrentMail"];
            ViewBag.name = context.Students.Where(x => x.Email == values).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            var value = context.Courses.ToList();
            return View(value);

        }
        public ActionResult WatchCourse(int id, string name)
        {
            var values = context.WatchCourses.ToList().Where(x => x.CourseID == id).ToList();
            ViewBag.courseName = name;
            return View(values);
        }
    }
}