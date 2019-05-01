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
                    cfg.CreateMap<UserDto, User>().ForMember(dest => dest.EntityId, opt => opt.MapFrom(src => src.EntityId));
                });
        }
    }
}
