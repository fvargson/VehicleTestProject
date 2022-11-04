using AutoMapper;
using Project.Service.DTO.VehicleMake;
using Project.Service.DTO.VehicleModel;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Helpers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<VehicleMake, GetVehicleMakeDto>();
            CreateMap<VehicleMake, GetVehicleMakeDetailsDto>();
            CreateMap<VehicleModel, GetVehicleModelMakeDto>();
            CreateMap<VehicleModel, VehicleModelDto>();
        }
    }
}
