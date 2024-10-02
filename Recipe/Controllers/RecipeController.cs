using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Recipe.Controllers
{
    [RoutePrefix("api/recipes")]
    public class RecipeController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = RecipeService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpGet]
        [Route("details/{id}")]
        public HttpResponseMessage GetDetails(int id)
        {
            try
            {
                var data = RecipeService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(RecipeDTO recipe)
        {
            try
            {
                var data = RecipeService.Create(recipe);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(RecipeDTO recipe)
        {
            try
            {
                var data = RecipeService.Update(recipe);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

       
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = RecipeService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("search/{term}")]
        public HttpResponseMessage SearchRecipes(string term)
        {
            try
            {
                var recipes = RecipeService.Search(term);
                if (recipes == null || recipes.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No recipes found.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, recipes);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("user/{userId}")]
        public HttpResponseMessage GetRecipesByUser(int userId)
        {
            try
            {
                var data = RecipeService.GetRecipesByUser(userId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
