using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scribble.ViewModels
{
	public class DrawingViewModel
	{
		public string DrawingBytes { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime Created { get; set; }

		public string DrawingCreator { get; set; }
	}
}