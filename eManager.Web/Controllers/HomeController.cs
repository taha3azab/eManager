﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Domains;
using eManager.Web.Infrastructure;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public HomeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var allDepartments = _db.Departments;

            return View(allDepartments);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
