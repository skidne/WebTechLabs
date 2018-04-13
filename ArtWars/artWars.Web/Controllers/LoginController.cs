using artWars.BusinessLogic.Interfaces;
using artWars.Domain.Entities.User;
using artWars.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace artWars.Web.Controllers
{
    public class LoginController : Controller
    {
		private readonly ISession _session;

		public LoginController()
		{
			var bl = new BusinessLogic.BusinessLogic();
			_session = bl.GetSessionBL();
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin user)
        {
			if (ModelState.IsValid)
			{
				Mapper.Initialize(cfg => cfg.CreateMap<UserLogin, ULoginData>());
				var data = Mapper.Map<ULoginData>(user);

				data.LoginDateTime = DateTime.Now;

				var userLogin = _session.UserLogin(data);
				if (userLogin.Status)
				{
					HttpCookie cookie = _session.GenCookie(user.Username);
					ControllerContext.HttpContext.Response.Cookies.Add(cookie);

					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", userLogin.StatusMsg);
					return View();
				}
			}
            return View();
        }
    }
}