using AutoMapper;
using SonsuzBilgiV2.Entities.Concrete;
using SonsuzBilgiV2.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();  
            CreateMap<User,UserAddDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
        }
    }
}
