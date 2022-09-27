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
        Task<VehicleMake> CreateVehicleMake(VehicleMake new_vehicleMake);
        IEnumerable<VehicleMake> ReadVehicleMakes();
        Task<VehicleMake> DetailsVehicleMake(int id);
        Task<VehicleMake> DeleteVehicleMake(int id);
        Task<VehicleMake> UpdateVehicleMake(VehicleMake new_vehicleMake);
        Task<VehicleModel> CreateVehicleModel(VehicleModel new_vehicleModel);
        IEnumerable<VehicleModel> ReadVehicleModels();
        Task<VehicleModel> DetailsVehicleModel(int id);
        Task<VehicleModel> DeleteVehicleModel(int id);
        Task<VehicleModel> UpdateVehicleModel(VehicleModel new_vehicleModel);
        List<VehicleMake> FilterVehicleMake(List<string> filter_words, List<VehicleMake> vehicleMakes);
        List<VehicleModel> FilterVehicleModel(List<string> filter_words, List<VehicleModel> vehicleModels);
        List<VehicleMake> SortVehicleMake(List<VehicleMake> vehicleMakes, bool? descending);
        List<VehicleModel> SortVehcleModel(List<VehicleModel> vehicleModels, bool? descending);
        List<VehicleMake> PageVahicleMake(int page, int perpage, List<VehicleMake> vehicleMakes);
        List<VehicleModel> PageVahicleModel(int page, int perpage, List<VehicleModel> vehicleModels);
    }
}
