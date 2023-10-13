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
        public ActionResult DeleteCourse(int id)
        {
            var values = context.Courses.Find(id);
            context.Courses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index", "InstructorCourse");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {

            var categories = context.Categories.ToList();
            List<SelectListItem> category = (from x in categories
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();

            ViewBag.category = category;
            var values = context.Courses.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var values = context.Courses.Find(course.CourseID);
            values.Title = course.Title;
            values.Price = course.Price;
            values.Duration = course.Duration;
            values.ImageUrl = course.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index", "InstructorCourse");
        }


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
            return RedirectToAction("Index", "InstructorCourse");
        }

        [HttpGet]
        public ActionResult AddVideo(int id)
        {

            var values = context.WatchCourses.Where(x => x.CourseID == id).ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult AddVideo(WatchCourse watchCourse)
        {

            context.WatchCourses.Add(watchCourse);
            context.SaveChanges();
            return RedirectToAction("Index", "InstructorCourse");
        }

    }
}