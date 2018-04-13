using System.Web;
using artWars.Domain.Entities.User;

namespace artWars.Web.Extension
{
	public static class HttpContextExtensions
	{
		public static UserMinimal GetMySessionObject(this HttpContext current)
		{
			return (UserMinimal)current?.Session["__SessionObject"];
		}

		public static void SetMySessionObject(this HttpContext current, UserMinimal profile)
		{
			current.Session.Add("__SessionObject", profile);
		}
	}
}