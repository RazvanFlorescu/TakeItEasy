using AutoMapper;
using Entities;
using Models;

namespace BusinessLogicWriter.Helpers
{
    public static class AutoMapperHelper
    {
        public static void IntializeMapper()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<User, UserDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EntityId)).ReverseMap();
                });
        }
    }
}
