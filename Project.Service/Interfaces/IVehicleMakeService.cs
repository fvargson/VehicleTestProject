using Project.Service.Helpers;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public enum Sorting
    {
        Desc,
        Asc
    }
    public interface IVehicleMakeService
    {
        Task<int> CountVehicleMakeAsync();
        Task<VehicleMake> CreateVehicleMakeAsync(VehicleMake newVehicleMake);
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakeAsync(int id);
        Task<VehicleMake> GetVehicleMakeModelsAsync(int id);
        Task<VehicleMake> RemoveVehicleMakeAsync(int id);
        Task<VehicleMake> UpdateVehicleMakeAsync(VehicleMake newVehicleMake);
        Task<List<VehicleMake>> SortFilterPageMakeAsync(Paging paging, Sort sort);
    }
}
