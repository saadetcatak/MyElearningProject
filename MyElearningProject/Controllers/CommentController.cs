using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CommentController : Controller
    {
        ElearningContext context = new ElearningContext();

        [HttpGet]
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            var course = context.Courses.ToList();
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
        public ActionResult Index(Comment comment)
        {
            var values = context.Courses.Find(comment.CourseID);
            comment.CommentStatus = true;
            comment.CourseID =values.CourseID;
            context.Comments.Add(comment);          
            return RedirectToAction("Index", "StudentCourse");


        }

    }
}