using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class SubscribeController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            var values = context.Subscribes.ToList();
            return View(values);
        }
    }
}