using System;
using System.Collections.Generic;
using artWars.Domain.Entities.User;
using System.Data.Entity;
using artWars.BusinessLogic.DBModel.Seed;
using artWars.BusinessLogic.Migrations;
using artWars.Domain.Enums;

namespace artWars.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        static UserContext()
        {
            System.Data.Entity.Database.SetInitializer(new UserDbInitializer());
        }

        public UserContext() : base("name=artWars")
        {

        }

		public virtual DbSet<UDBTable> Users { get; set; }
    }

    public class UserDbInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            
        }
    }
}
