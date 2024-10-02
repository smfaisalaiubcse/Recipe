using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }

        public static bool Create(UserDTO obj)
        {
            var data = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Create(data);
        }

        public static UserDTO GetByUsernameAndPassword(string username, string password)
        {
            var data = DataAccess.UserData().GetByUsernameAndPassword(username, password);
            return GetMapper().Map<UserDTO>(data);
        }
    }

}
