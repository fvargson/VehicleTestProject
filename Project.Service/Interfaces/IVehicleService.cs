using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleService
    {
        VehicleMake CreateVehicleMake(VehicleMake new_vehicleMake);
        List<VehicleMake> ReadVehicleMakes();
        VehicleMake DetailsVehicleMake(int id);
        VehicleMake DeleteVehicleMake(int id);
        VehicleMake UpdateVehicleMake(VehicleMake new_vehicleMake);
        VehicleMake CreateVehicleModel(VehicleModel new_vehicleModel);
        List<VehicleModel> ReadVehicleModels();
        VehicleModel DetailsVehicleModel(int id);
        VehicleModel DeleteVehicleModel(int id);
        VehicleModel UpdateVehicleModel(VehicleModel new_vehicleModel);
        List<VehicleMake> FilterVehicleMake(List<string>? filter_words, List<VehicleMake> vehicleMakes);
        List<VehicleModel> FilterVehicleModel(List<string>? filter_words, List<VehicleModel> vehicleModels);
        List<VehicleMake> SortVehicleMake(bool? descending, List<VehicleMake> vehicleMakes);
        List<VehicleModel> SortVehcleModel(bool? descending, List<VehicleModel> vehicleModels);
        List<VehicleMake> PageVahicleMake(int page, List<VehicleMake> vehicleMakes);
        List<VehicleModel> PageVahicleModel(int page, List<VehicleModel> vehicleModels);
    }
}
