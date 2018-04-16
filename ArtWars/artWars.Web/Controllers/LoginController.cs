using artWars.BusinessLogic.Interfaces;
using artWars.Domain.Entities.User;
using artWars.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using artWars.BusinessLogic.DBModel;
using artWars.BusinessLogic.Repositories;
using artWars.Domain.Enums;
using artWars.Helpers;

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

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(UserRegistration user)
		{
			if (ModelState.IsValid)
			{
				//Mapper.Initialize(cfg => cfg.CreateMap<UserLogin, ULoginData>());
				using (var context = new UserContext())
				{
					if (context.Users.FirstOrDefault(u => u.Username == user.Username) != null)
						return View();
					UDBTable newUser = new UDBTable() { Username = user.Username,
						Password = LoginHelper.HashGen(user.Password), LastLogin = DateTime.UtcNow,
						Email =user.Email, Role=URole.User};
					context.Users.Add(newUser);
					context.SaveChanges();
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}