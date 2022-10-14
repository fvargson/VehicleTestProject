using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<VehicleMake> CreateVehicleMakeAsync(VehicleMake newVehicleMake);
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakeAsync(int id);
        Task<VehicleMake> RemoveVehicleMakeAsync(int id);
        Task<VehicleMake> UpdateVehicleMakeAsync(VehicleMake newVehicleMake);
        Task<List<VehicleMake>> FilterVehicleMakeAsync(List<string> filterStrings);
        Task<List<VehicleMake>> SortVehicleMakeAsync();
        Task<List<VehicleMake>> SortDescendingVehicleMakeAsync();
        Task<List<VehicleMake>> PageVehicleMakeAsync(int page, int perPage);
    }
}
