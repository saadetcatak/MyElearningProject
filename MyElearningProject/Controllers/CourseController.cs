using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CourseController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            var values = context.Courses.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.v = categories;

            List<SelectListItem> instructors = (from y in context.Instructors.ToList().OrderBy(z=>z.Name)
                                                select new SelectListItem
                                                {
                                                    Text = y.Name + " " + y.Surname,
                                                    Value = y.InstructorID.ToString()
                                                }).ToList();
            ViewBag.v2 = instructors;

            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            var values = context.Courses.Find(id);
            context.Courses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.v = categories;

            List<SelectListItem> instructors = (from y in context.Instructors.ToList().OrderBy(z => z.Name)
                                                select new SelectListItem
                                                {
                                                    Text = y.Name + " " + y.Surname,
                                                    Value = y.InstructorID.ToString()
                                                }).ToList();
            ViewBag.v2 = instructors;
            var value = context.Courses.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseID);
            value.Title = course.Title;
            value.CategoryID = course.CategoryID;
            value.Price = course.Price;
            value.Duration = course.Duration;
            value.ImageUrl = course.ImageUrl;
            value.InstructorID = course.InstructorID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}