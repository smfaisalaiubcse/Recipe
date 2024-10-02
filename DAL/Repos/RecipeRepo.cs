using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repos
{
    internal class RecipeRepo : Repo, IRepo<Recipe, int, bool>
    {
        public bool Create(Recipe obj)
        {
            db.Recipes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Recipe> Get()
        {
            return db.Recipes.Include(r => r.User).ToList();
        }

        public Recipe Get(int id)
        {
            return db.Recipes.Include(r => r.User).FirstOrDefault(r => r.Id == id);
        }

        public bool Update(Recipe obj)
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
                db.Recipes.Remove(exObj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
