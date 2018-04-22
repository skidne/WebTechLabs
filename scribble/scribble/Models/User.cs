using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace scribble.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Country { get; set; }

		public ICollection<Drawing> UserDrawings { get; set; }

		public User()
		{
			UserDrawings = new List<Drawing>();
		}
	}
}
