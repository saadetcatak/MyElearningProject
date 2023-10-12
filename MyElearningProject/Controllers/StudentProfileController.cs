using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class StudentProfileController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index(int id)
        {
            var values = context.Students.Find(id);

            return View();
        }
    }
}