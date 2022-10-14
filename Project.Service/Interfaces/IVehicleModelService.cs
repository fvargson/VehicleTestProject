using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<VehicleModel> CreateVehicleModelAsync(VehicleModel vehicleModel);
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<VehicleModel> GetVehicleModelAsync(int id);
        Task<VehicleModel> RemoveVehicleModelAsync(int id);
        Task<VehicleModel> UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task<List<VehicleModel>> FilterVehicleModelAsync(List<string> filterStrings);
        Task<List<VehicleModel>> SortVehicleModelAsync();
        Task<List<VehicleModel>> SortDescendingVehicleModelAsync();
        Task<List<VehicleModel>> PageVehicleModelAsync(int page, int perPage);
    }
}
