using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
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
        public ActionResult DeleteSubscribe(int id)
        {
            var values = context.Subscribes.Find(id);
            context.Subscribes.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSubscribe(int id)
        {
            var values = context.Subscribes.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSubscribe(Subscribe subscribe)
        {
            var value = context.Subscribes.Find(subscribe.SubscribeID);
            value.Mail = subscribe.Mail;       
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}