﻿using Project.Service.DTO.VehicleMake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.DTO.VehicleModel
{
    public class GetVehicleModelMakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public GetVehicleMakeDto VehicleMake { get; set; }
    }
}
