using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scribble.Models
{
	public class Drawing
	{
		[Key]
		public int Id { get; set; }

		public string ImageUrl { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public DateTime Created { get; set; }

		public virtual User DrawingCreator { get; set; }
	}
}