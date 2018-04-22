using scribble.Libs;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using scribble.ViewModels;
using System.Web.Security;
using System;

namespace scribble.Controllers
{
	[AllowAnonymous]
	public class AuthController : Controller
    {
		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(UserLoginModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			using (var db = new MainDbContext())
			{
				var emailCheck = db.Users.FirstOrDefault(u => u.Email == model.Email);
				var getPswd = db.Users.Where(u => u.Email == model.Email).Select(u => u.Password);
				var listPswd = getPswd.ToList();
				var decryptPswd = (!listPswd.Any()) ? null : Decryption.Decrypt(getPswd.ToList()[0]);

				if (model.Email != null && model.Password == decryptPswd)
				{
					var getMail = db.Users.Where(u => u.Email == model.Email).Select(u => u.Email);
					var getName = db.Users.Where(u => u.Email == model.Email).Select(u => u.Username);
					var getCountry = db.Users.Where(u => u.Email == model.Email).Select(u => u.Country);
					var identity = new ClaimsIdentity(new[] {
						new Claim(ClaimTypes.Name, getName.ToList()[0]),
						new Claim(ClaimTypes.Email, getMail.ToList()[0]),
						new Claim(ClaimTypes.Country, getCountry.ToList()[0])
					}, "ApplicationCookie");

					Request.GetOwinContext().Authentication.SignIn(identity);

					return RedirectToAction("Index", "Home");
				}
			}
			ModelState.AddModelError("", "Invalid Email or Password");

			return View(model);
		}

		public ActionResult LogOut()
		{
			Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");

			return RedirectToAction("Index", "Home");
		}

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var emailExists = EmailExists(model.Email);
				var usernameExists = UsernameExists(model.Username);

				if (emailExists)
					ModelState.AddModelError("Email", "Email already in use.");
				if (usernameExists)
					ModelState.AddModelError("Username", "Username already in use.");
				
				if (!usernameExists && !emailExists)
					using (var db = new MainDbContext())
					{
						var user = db.Users.Create();
						user.Email = model.Email;
						user.Password = Encryption.Encrypt(model.Password);
						user.Username = model.Username;
						user.Country = model.Country;
						db.Users.Add(user);
						db.SaveChanges();

						return RedirectToAction("Login", "Auth");
					}
			}
			else
				ModelState.AddModelError("", "Invalid input");

			return View();
		}

		private bool EmailExists(string email)
		{
			using (var db = new MainDbContext())
			{
				var user = db.Users.Where(u => u.Email == email).FirstOrDefault();
		
				if (user != null)
					return true;
			}
			return false;
		}

		private bool UsernameExists(string username)
		{
			using (var db = new MainDbContext())
			{
				var user = db.Users.Where(u => u.Username == username).FirstOrDefault();

				if (user != null)
					return true;
			}
			return false;
		}
	}
}