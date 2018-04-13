using System.Web;
using artWars.Domain.Entities.User;

namespace artWars.BusinessLogic.Interfaces
{
    public interface ISession
    {
		ULoginResp UserLogin(ULoginData data);
		HttpCookie GenCookie(string loginCredential);
		UserMinimal GetUserByCookie(string apiCookieValue);
	}
}
