using Project.Service.Helpers;
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
        Task<int> CountVehicleModelByMakeAsync(int? makeId);
        Task<VehicleModel> CreateVehicleModelAsync(VehicleModel vehicleModel);
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<VehicleModel> GetVehicleModelAsync(int id);
        Task<VehicleModel> RemoveVehicleModelAsync(int id);
        Task<VehicleModel> UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task<List<VehicleModel>> SortFilterPageModelAsync(Filtering filtering, Paging paging, Sort sorting);
    }
}
