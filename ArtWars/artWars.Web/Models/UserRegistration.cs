using System.ComponentModel.DataAnnotations;

namespace artWars.Web.Models
{
	public class UserRegistration
	{
		[Required]
		[Display(Name = "Username")]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "Cannot be longer than 20 characters.")]
		public string Username { get; set; }

		[Required]
		[Display(Name = "Password")]
		//[DataType(DataType.Password)]
		[StringLength(40, MinimumLength = 8, ErrorMessage = "Cannot be shorter than 8 characters.")]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Email Address")]
		[StringLength(30)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}