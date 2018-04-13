using System;

namespace artWars.Domain.Entities.User
{
    public class ULoginData
    {
		public string UserName { get; set; }
		public string Password { get; set; }
		public DateTime LoginDateTime { get; set; }
    }
}
