using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using artWars.Domain.Entities.User;
using artWars.Domain.Enums;

namespace artWars.BusinessLogic.DBModel.Seed
{
    public class UDBTableInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            
        }
    }
}
