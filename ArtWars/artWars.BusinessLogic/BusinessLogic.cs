using artWars.BusinessLogic.Interfaces;

namespace artWars.BusinessLogic
{
    public class BusinessLogic
    {
		public ISession GetSessionBL()
		{
			return new SessionBL();
		}
    }
}
