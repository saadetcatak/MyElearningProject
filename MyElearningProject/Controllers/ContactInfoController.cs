using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ContactInfoController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            var values = context.ContactInfos.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContactInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContactInfo(ContactInfo contactInfo)
        {
            context.ContactInfos.Add(contactInfo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContactInfo(int id)
        {
            var values = context.ContactInfos.Find(id);
            context.ContactInfos.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContactInfo(int id)
        {
            var value = context.ContactInfos.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            var value = context.ContactInfos.Find(contactInfo.ContactInfoID);
            value.Address = contactInfo.Address;
            value.Phone = contactInfo.Phone;
            value.Email = contactInfo.Email;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}