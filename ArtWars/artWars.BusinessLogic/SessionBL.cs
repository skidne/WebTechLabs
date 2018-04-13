using artWars.BusinessLogic.Core;
using artWars.BusinessLogic.Interfaces;
using artWars.Domain.Entities.User;
using System.Web;

namespace artWars.BusinessLogic
{
	public class SessionBL : UserApi, ISession
	{
		public ULoginResp UserLogin(ULoginData data)
		{
			return UserLoginAction(data);
		}

		public HttpCookie GenCookie(string loginCredential)
		{
			return Cookie(loginCredential);
		}

		public UserMinimal GetUserByCookie(string apiCookieValue)
		{
			return UserCookie(apiCookieValue);
		}
	}
}
