using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyElearningProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            var values = Session["CurrentMail"];
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Admins.Where(x => x.Email == values).Select(y => y.NameSurname).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialPageRowtitle()
        {

            return PartialView();
        }

        public PartialViewResult PartialPreloader()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
    }
}