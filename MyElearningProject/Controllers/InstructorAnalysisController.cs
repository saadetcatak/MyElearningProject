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

        public PartialViewResult InstructorPanelPartial(int id)
        {
            id = 1;
            var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
            return PartialView(values);
        }

        public PartialViewResult CommentPartial()
        {
            return PartialView();
        }
    }
}