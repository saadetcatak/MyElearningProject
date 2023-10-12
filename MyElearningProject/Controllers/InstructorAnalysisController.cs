using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyElearningProject.DAL.Context;

namespace MyElearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult InstructorPanelPartial()
        {
            var values = Session["CurrentMail"];
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Instructors.Where(x => x.Email == values).Select(y => y.Name +" " + y.Surname).FirstOrDefault();
            
            var values2 = context.Instructors.Where(x => x.Email == values).FirstOrDefault();

            var v1 = context.Instructors.Where(x => x.Email==values).Select(y => y.InstructorID).FirstOrDefault();
            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == v1).Count();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();

            ViewBag.commentCount = context.Comments.Where(x => v2.Contains(x.CourseID)).Count();

            return PartialView(values2);
        }

        public PartialViewResult CommentPartial()
        {
            var values = Session["CurrentMail"];
            //select InstructorID from Instructors where Name='Saadet' and Surname='Çatak'=v1
            var v1 = context.Instructors.Where(x => x.Email==values).Select(y => y.InstructorID).FirstOrDefault();
            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == v1).Count();



            //select CourseID from Courses where InstructorID
            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();
            ViewBag.commentCoumt= context.Comments.Where(x => v2.Contains(x.CourseID)).Count();



            //select*from Comments where CourseID
            var v3 = context.Comments.Where(x => v2.Contains(x.CourseID)).ToList();

            return PartialView(v3);
        }

        public PartialViewResult CourseListByInstructor()
        {
            var values = Session["CurrentMail"];
            
            var v1 = context.Instructors.Where(x => x.Email == values).Select(y => y.InstructorID).FirstOrDefault();
            ViewBag.commentCount = context.Courses.Where(x => x.InstructorID == v1).Count();
            var values2= context.Courses.Where(x => x.InstructorID == v1).ToList();
            return PartialView(values2);
        }
    }
}