using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class RecipeService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeDTO>();
                cfg.CreateMap<RecipeDTO, Recipe>();
            });
            return new Mapper(config);
        }

        public static bool Create(RecipeDTO obj)
        {
            var data = GetMapper().Map<Recipe>(obj);
            return DataAccess.RecipeData().Create(data);
        }

        public static List<RecipeDTO> GetAll()
        {
            var data = DataAccess.RecipeData().Get();
            return GetMapper().Map<List<RecipeDTO>>(data);
        }

        public static RecipeDTO GetById(int id)
        {
            var data = DataAccess.RecipeData().Get(id);
            return GetMapper().Map<RecipeDTO>(data);
        }

        public static bool Update(RecipeDTO obj)
        {
            var data = GetMapper().Map<Recipe>(obj);
            return DataAccess.RecipeData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccess.RecipeData().Delete(id);
        }

        public static List<RecipeDTO> Search(string query)
        {
            var recipes = DataAccess.RecipeData().Get();
            
            var filteredRecipes = recipes.Where(r =>
                r.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                r.Ingredients.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            return GetMapper().Map<List<RecipeDTO>>(filteredRecipes);
        }

        
        public static List<RecipeDTO> GetRecipesByUser(int userId)
        {
            var recipes = DataAccess.RecipeData().Get();
            var userRecipes = recipes.Where(r => r.UserId == userId).ToList();

            return GetMapper().Map<List<RecipeDTO>>(userRecipes);
        }
    }

}
