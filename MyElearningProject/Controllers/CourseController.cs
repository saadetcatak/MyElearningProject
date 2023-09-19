﻿using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CourseController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            var values = context.Courses.ToList();
            return View(values);
        }
    }
}