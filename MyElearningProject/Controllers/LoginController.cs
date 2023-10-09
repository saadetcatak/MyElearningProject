using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;

namespace MyElearningProject.Controllers
{
    public class LoginController : Controller
    {
        ElearningContext context = new ElearningContext();


        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(Student student)
        {
            var values = context.Students.FirstOrDefault(x => x.Email == student.Email && x.Password == student.Password);
            if(values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.Email == admin.Email && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        [HttpGet]
        public ActionResult InstructorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InstructorLogin(Instructor instructor)
        {
            var values = context.Instructors.FirstOrDefault(x => x.Email == instructor.Email && x.Password == instructor.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["CurrentMail"] = values.Email;
                Session.Timeout = 60;
                return RedirectToAction("Index", "InstructorAnalysis");
            }
            return View();
        }
    }
}