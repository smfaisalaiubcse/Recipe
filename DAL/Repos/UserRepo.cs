using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IUserRepo
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var exObj = Get(obj.Id);
            if (exObj != null)
            {
                db.Entry(exObj).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var exObj = Get(id);
            if (exObj != null)
            {
                db.Users.Remove(exObj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }

}
