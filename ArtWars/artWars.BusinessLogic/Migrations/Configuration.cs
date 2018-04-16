using System.Collections.Generic;
using artWars.BusinessLogic.DBModel;
using artWars.Domain.Entities.User;
using artWars.Domain.Enums;

namespace artWars.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<artWars.BusinessLogic.DBModel.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "artWars.BusinessLogic.DBModel.UserContext";
        }

        protected override void Seed(UserContext context)
        {
            var users = new List<UDBTable>
            {
                new UDBTable
                {
                    Email = "chik@pok.com",
                    LastLogin = DateTime.UtcNow,
                    Password = "123456789",
                    Role = URole.User,
                    Username = "chikchick"
                },
                new UDBTable
                {
                    Email = "prakilop@mail.ru",
                    LastLogin = DateTime.UtcNow,
                    Password = "qwer1234",
                    Role = URole.Admin,
                    Username = "prakilop"
                }
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}
