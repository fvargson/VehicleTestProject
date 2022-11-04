using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.DTO.VehicleModel;

namespace Project.Service.DTO.VehicleMake
{
    public class GetVehicleMakeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModelDto> VehicleModels { get; set; }
    }
}
