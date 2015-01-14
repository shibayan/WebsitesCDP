﻿using System.Configuration;
using System.Web.Mvc;

namespace ExternalConfigurationStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = ConfigurationManager.AppSettings["CustomSetting"];

            return View();
        }
    }
}