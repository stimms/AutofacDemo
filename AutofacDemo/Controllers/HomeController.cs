using AutofacDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AutofacDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly INameResolver _nameResolver;
        public HomeController(INameResolver nameResolver)
        {
            _nameResolver = nameResolver;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _nameResolver.GetName("Ollie");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}