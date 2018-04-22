using System.Web.Mvc;
using System.Linq;
using scribble.Models;
using System.Collections.Generic;
using scribble.ViewModels;
using System.Diagnostics;

namespace scribble.Controllers
{
	[AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
			List<DrawingViewModel> shits = new List<DrawingViewModel>();
			List<Drawing> shits2 = new List<Drawing>();

			using (var db = new MainDbContext())
			{
				if (db.Drawings != null)
					shits2 = db.Drawings.ToList();

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

		public ActionResult About()
		{
			return View();
		}
    }
}