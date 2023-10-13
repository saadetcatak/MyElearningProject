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
            var email = Session["CurrentMail"];
            var studentID = context.Students.Where(x => x.Email == email.ToString()).Select(x => x.StudentID).FirstOrDefault();
            review.StudentID = studentID;
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index","StudentCourse");
        }
    }
}
