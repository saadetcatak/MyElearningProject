using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ReviewController : Controller
    {
        ElearningContext context = new ElearningContext();

        [HttpGet]
        public ActionResult Index()
        {
            var student =context.Students.ToList();
            List<SelectListItem> studentList = (from x in student
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.StudentID.ToString()
                                                }).ToList();
            ViewBag.student = studentList;


            var course =context.Courses.ToList();
            List<SelectListItem> courseList = (from x in course
                                               select new SelectListItem
                                               {
                                                   Text = x.Title,
                                                   Value = x.CourseID.ToString()
                                               }).ToList();
            ViewBag.course = courseList;

            return View();
        }

        [HttpPost]
        public ActionResult Index(Review review)
        {
            var user = context.Students.Find(review);
            review.ReviewID = user.StudentID;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
