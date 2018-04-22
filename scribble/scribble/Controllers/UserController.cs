using scribble.Libs;
using scribble.Models;
using scribble.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace scribble.Controllers
{
	[Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
			List<DrawingViewModel> shits = new List<DrawingViewModel>();
			List<Drawing> shits2 = new List<Drawing>();

			using (var db = new MainDbContext())
			{
				if (db.Drawings != null)
					shits2 = db.Drawings.Where(x => x.DrawingCreator.Username == User.Identity.Name).ToList();

				foreach (var s in shits2)
				{
					DrawingViewModel tmp = new DrawingViewModel()
					{
						DrawingBytes = s.ImageUrl,
						Title = s.Title,
						Description = s.Description,
						Created = s.Created,
						DrawingCreator = s.DrawingCreator.Username
					};
					shits.Add(tmp);
				}
			}
			return View(shits);
        }

		public ActionResult DeleteDrawing(string url)
		{
			using (var db = new MainDbContext())
			{
				var drawingDel = db.Drawings.Where(d => d.ImageUrl == url).FirstOrDefault();
				db.Drawings.Remove(drawingDel);
				db.SaveChanges();
			}
			return RedirectToAction("Index", "User");
		}

		public ActionResult Draw()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Settings()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Settings(UserUpdateModel userm)
		{
			using (var db = new MainDbContext())
			{
				var user = db.Users.Where(u => u.Username == User.Identity.Name).FirstOrDefault();

				if (user != null)
				{
					if (user.Password == Encryption.Encrypt(userm.OldPassword))
					{
						if (userm.NewPassword == userm.ConfirmPassword)
						{
							db.Entry(user).State = EntityState.Modified;
							user.Password = Encryption.Encrypt(userm.NewPassword);
							db.SaveChanges();
						}
						else
							ModelState.AddModelError("ConfirmPassword", "Passwords don't match.");
					}
					else
						ModelState.AddModelError("OldPassword", "Wrong password.");
				}
			}
			return View();
		}

		[HttpPost]
		public ActionResult SaveShitDrawing(DrawingViewModel drawingModel)
		{
			var newImgUrl = ZaebashitiKartinku(drawingModel.DrawingBytes);

			using (var db = new MainDbContext())
			{
				var currentUserName= User.Identity.Name;
				var creatorUser = db.Users.Where(u => u.Username == currentUserName).FirstOrDefault();

				var newDrawing = new Drawing
				{
					ImageUrl = newImgUrl,
					Title = drawingModel.Title,
					Description = drawingModel.Description,
					Created = DateTime.Now,
					DrawingCreator = creatorUser
				};
				db.Drawings.Add(newDrawing);
				db.SaveChanges();
			}
			return RedirectToAction("Index", "Home");
		}

		private string ZaebashitiKartinku(string kartinkaData)
		{
			var base64Data = Regex.Match(kartinkaData, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
			var binData = Convert.FromBase64String(base64Data);

			var milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			var tmpFilename = "skdn" + milliseconds.ToString() + ".png";
			var path = Server.MapPath("~/Uploads/skdn");
			var urlBuilder = new UriBuilder(Request.Url.AbsoluteUri)
			{
				Path = Url.Content("~/Uploads/skdn" + "/" + tmpFilename),
				Query = null,
			};
			var url = urlBuilder.ToString();

			using (var mss = new MemoryStream(binData))
			{
				var img = Image.FromStream(mss);
				img.Save(Path.Combine(path, tmpFilename));
			}

			return url;
		}

		public ActionResult SaveShitDrawing()
		{
			return Content("Ushel nahui otsiuda");
		}
	}
}