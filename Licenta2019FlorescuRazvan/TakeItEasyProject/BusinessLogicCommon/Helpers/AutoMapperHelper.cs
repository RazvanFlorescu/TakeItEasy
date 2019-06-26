using AutoMapper;
using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogicCommon.Helpers
{
    public static class AutoMapperHelper
    {
        public static void IntializeMapper()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<User, UserDto>();
                    cfg.CreateMap<Image, ImageDto>();
                    cfg.CreateMap<Vacation, VacationDto>();
                    cfg.CreateMap<Location, LocationDto>();
                    cfg.CreateMap<Notification, NotificationDto>();
                    cfg.CreateMap<VacationJoining, VacationJoiningDto>();
                    cfg.CreateMap<WishItem, WishItemDto>();
                });
        }
    }
}
