using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace artWars.Web.Models
{
	public class UserData
	{
		public string Username { get; set; }
		public List<string> Wars { get; set; }
		public string SingleWar { get; set; }
	}
}