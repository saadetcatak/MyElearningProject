using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class MapController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            var values = context.Maps.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddMap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMap(Map map)
        {
           context.Maps.Add(map);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteMap(int id)
        {
            var values = context.Maps.Find(id);
            context.Maps.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateMap(int id)
        {
            var values = context.Maps.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateMap(Map map)
        {
            var value = context.Maps.Find(map.MapID);
            value.LocationURL = map.LocationURL;
            value.Status = map.Status;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}