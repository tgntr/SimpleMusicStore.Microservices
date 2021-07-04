using AutoMapper;
using SimpleMusicStore.Entities;

using SimpleMusicStore.Models;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.MusicLibraries;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMusicStore.UserActivities
{
    public class MappingConfigurations : Profile
    {
        public MappingConfigurations()
        {
            CreateMap<SimpleUser, UserClaims>().ReverseMap();
        }
    }
}
