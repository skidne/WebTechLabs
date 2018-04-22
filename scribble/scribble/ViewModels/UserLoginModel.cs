using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace scribble.ViewModels
{
	public class UserLoginModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }//uuite oleac
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}