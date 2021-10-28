using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VisitorManager.Core.Domain;
using VisitorManager.Infrastructure.DTO;

namespace VisitorManager.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Store, StoreDto>();
                cfg.CreateMap<User, UserDetailDto>();
                cfg.CreateMap<Device, DeviceDto>();
            })
            .CreateMapper();
    }
}
