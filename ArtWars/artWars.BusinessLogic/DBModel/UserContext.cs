using artWars.Domain.Entities.User;
using System.Data.Entity;

namespace artWars.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
		public UserContext() : base("name=artWars")
		{ }

		public virtual DbSet<UDBTable> Users { get; set; }
    }
}
