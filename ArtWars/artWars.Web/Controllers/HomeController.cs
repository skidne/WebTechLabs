using artWars.Web.Extension;
using artWars.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace artWars.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
			SessionStatus();
			if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
			{
				return RedirectToAction("Index", "Login");
			}

			var user = System.Web.HttpContext.Current.GetMySessionObject();
			UserData u = new UserData
			{
				Username = user.Username,
				Wars = new List<string> { "Cold War", "Hot War", "Shit War" }
			};

			return View(u);
		}

		public ActionResult Battles()
        {
            return View();
        }

        public ActionResult Wars()
        {
            return View();
        }

		public ActionResult War()
		{
			var war = Request.QueryString["war"];

			return View(new UserData
			{
				Username = "Pops",
				SingleWar = war
			});
		}

		[HttpPost]
		public ActionResult War(string btn)
		{
			return RedirectToAction("War", "Home", new { @war = btn });
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