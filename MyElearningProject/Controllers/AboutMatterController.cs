using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AboutMatterController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            var values = context.AboutMatters.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAboutMatter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAboutMatter(AboutMatter aboutMatter)
        {
            context.AboutMatters.Add(aboutMatter);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAboutMatter(int id)
        {
            var values = context.AboutMatters.Find(id);
            context.AboutMatters.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAboutMatter(int id)
        {
            var value = context.AboutMatters.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAboutMatter(AboutMatter aboutMatter)
        {
            var value = context.AboutMatters.Find(aboutMatter.AboutMatterID);
            value.Matter = aboutMatter.Matter;
            context.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}