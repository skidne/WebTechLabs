using artWars.Domain.Entities.User;
using System.Data.Entity;

namespace artWars.BusinessLogic.DBModel
{
	public class SessionContext : DbContext
	{
		public SessionContext() : base("name=artWars")
		{ }

		public virtual DbSet<Session> Sessions { get; set; }
	}
}