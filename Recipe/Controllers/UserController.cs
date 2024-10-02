using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace Recipe.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
      

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(UserDTO userDto)
        {
            try
            {
                var success = UserService.Create(userDto);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User registered successfully.");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to register user.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
