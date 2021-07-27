using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Education.Service
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            //CreateMap<UserService,IUserService>()
            //    .ForMember(d => d, m => m.MapFrom(m => m.));
        }
    }
}
