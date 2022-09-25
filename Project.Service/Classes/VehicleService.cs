using Project.Service.Interfaces;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Classes
{
    public class VehicleService : IVehicleService
    {
        public VehicleMake CreateVehicleMake(VehicleMake new_vehicleMake)
        {
            throw new NotImplementedException();
        }

        public VehicleMake CreateVehicleModel(VehicleModel new_vehicleModel)
        {
            throw new NotImplementedException();
        }

        public VehicleMake DeleteVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleModel DeleteVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleMake DetailsVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleModel DetailsVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public List<VehicleMake> FilterVehicleMake(List<string>? filter_words, List<VehicleMake> vehicleMakes)
        {
            throw new NotImplementedException();
        }

        public List<VehicleModel> FilterVehicleModel(List<string>? filter_words, List<VehicleModel> vehicleModels)
        {
            throw new NotImplementedException();
        }

        public List<VehicleMake> PageVahicleMake(int page, List<VehicleMake> vehicleMakes)
        {
            throw new NotImplementedException();
        }

        public List<VehicleModel> PageVahicleModel(int page, List<VehicleModel> vehicleModels)
        {
            throw new NotImplementedException();
        }

        public List<VehicleMake> ReadVehicleMakes()
        {
            throw new NotImplementedException();
        }

        public List<VehicleModel> ReadVehicleModels()
        {
            throw new NotImplementedException();
        }

        public List<VehicleModel> SortVehcleModel(bool? descending, List<VehicleModel> vehicleModels)
        {
            throw new NotImplementedException();
        }

        public List<VehicleMake> SortVehicleMake(bool? descending, List<VehicleMake> vehicleMakes)
        {
            throw new NotImplementedException();
        }

        public VehicleMake UpdateVehicleMake(VehicleMake new_vehicleMake)
        {
            throw new NotImplementedException();
        }

        public VehicleModel UpdateVehicleModel(VehicleModel new_vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
