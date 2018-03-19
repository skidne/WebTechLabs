using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace artWars.Skywalker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Battles()
        {
            return View();
        }

        public ActionResult Wars()
        {
            return View();
        }

        public ActionResult Postbellum()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}