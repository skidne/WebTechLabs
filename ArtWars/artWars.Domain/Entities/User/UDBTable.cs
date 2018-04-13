using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using artWars.Domain.Enums;

namespace artWars.Domain.Entities.User
{
    public class UDBTable
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Username")]
		[StringLength(20, MinimumLength = 5, ErrorMessage = "Cannot be longer than 20 characters.")]
		public string Username { get; set; }

		[Required]
		[Display(Name = "Password")]
		[StringLength(40, MinimumLength = 8, ErrorMessage = "Cannot be shorter than 8 characters.")]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Email Address")]
		[StringLength(30)]
		public string Email { get; set; }

		[DataType(DataType.Date)]
		public DateTime LastLogin { get; set; }

		public URole Role { get; set; }
    }
}
