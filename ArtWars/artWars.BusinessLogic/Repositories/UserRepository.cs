using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using artWars.BusinessLogic.DBModel;
using artWars.BusinessLogic.Interfaces;
using artWars.Domain.Entities.User;

namespace artWars.BusinessLogic.Repositories
{
    public class UserRepository : IRepository<UDBTable>
    {
        public UserRepository()
        {
            
        }

        public void Create(UDBTable item)
        {
            using (var context = new UserContext())
            {
                context.Users.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new UserContext())
            {
                var u = context.Users.FirstOrDefault(x => x.Id == id);
                if (u != null)
                    context.Users.Remove(u);
                context.SaveChanges();
            }
        }

        public IEnumerable<UDBTable> Find(Func<UDBTable, bool> predicate)
        {
            using (var context = new UserContext())
            {
                var users = context.Users.Where(predicate);

                return users;
            }
        }

        public UDBTable Get(int id)
        {
            using (var context = new UserContext())
            {
                var u = context.Users.FirstOrDefault(x => x.Id == id);

                return u;
            }
        }

        public IEnumerable<UDBTable> GetAll()
        {
            using (var context = new UserContext())
            {
                var u = context.Users;

                return u;
            }
        }

        public void Update(UDBTable item)
        {
            using (var context = new UserContext())
            {
                var entity = context.Users.Find(item.Id);

                if (entity == null)
                {
                    return;
                }

                context.Entry(entity).CurrentValues.SetValues(item);
            }
        }
    }
}
