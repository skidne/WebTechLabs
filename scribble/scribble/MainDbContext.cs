using scribble.Models;
using System.Data.Entity;

namespace scribble
{
	public class MainDbContext : DbContext
	{
		public MainDbContext() : base("name=KEKconnect")
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainDbContext>());
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Drawing> Drawings { get; set; }
 	}
}