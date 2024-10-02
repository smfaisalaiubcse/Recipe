using DAL.Repos;
using DAL.Interfaces;
using DAL.EF.TableModels;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Recipe, int, bool> RecipeData()
        {
            return new RecipeRepo();
        }

        public static IUserRepo UserData()
        {
            return new UserRepo();
        }
    }
}
