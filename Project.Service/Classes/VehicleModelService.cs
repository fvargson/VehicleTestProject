using Microsoft.EntityFrameworkCore;
using Project.Service.Interfaces;
using Project.Service.Models;
using Project.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Helpers;

namespace Project.Service.Classes
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly ApplicationDbContext _context;
        public VehicleModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountVehicleModelByMakeAsync(int? makeId)
        {
            var result = await _context.VehicleModels.Where(vm => (makeId != 0)? vm.MakeId == makeId: true).CountAsync();

            return result;
        }
        public async Task<VehicleModel> CreateVehicleModelAsync(VehicleModel vehicleModel)
        {
            var addedVehicleModel = await _context.VehicleModels.AddAsync(vehicleModel);
            await _context.SaveChangesAsync();

            return addedVehicleModel.Entity;
        }

        public async Task<VehicleModel> GetVehicleModelAsync(int id)
        {
            var result = await _context.VehicleModels.Where(vm => vm.Id == id).Include(vm => vm.VehicleMake).SingleOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync()
        {
            var result = await _context.VehicleModels.ToListAsync();

            return result;
        }

        public async Task<VehicleModel> RemoveVehicleModelAsync(int id)
        {
            var oldVehicleModel = await GetVehicleModelAsync(id);
            var result = _context.VehicleModels.Remove(oldVehicleModel);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<VehicleModel>> SortFilterPageModelAsync(Filtering filtering, Paging paging, Sort sorting)
        {
            var result =
                (sorting.Sorting == Sorting.Asc)
                    ? await _context
                                .VehicleModels
                                .Where(vm => (filtering.FilterId == 0)? true: vm.MakeId == filtering.FilterId)
                                .OrderBy(vm => vm.Name)
                                .Skip((paging.CurrentPage - 1) * paging.PerPage)
                                .Take(paging.PerPage)
                                .Include(_ => _.VehicleMake)
                                .ToListAsync()
                    : await _context
                                .VehicleModels
                                .Where(vm => (filtering.FilterId == 0)? true : vm.MakeId == filtering.FilterId)
                                .OrderByDescending(vm => vm.Name)
                                .Skip((paging.CurrentPage - 1) * paging.PerPage)
                                .Take(paging.PerPage)
                                .Include(_ => _.VehicleMake)
                                .ToListAsync();
            return result;
        }

        public async Task<VehicleModel> UpdateVehicleModelAsync(VehicleModel newVehicleModel)
        {
            var updatedVehicleModel = await _context.VehicleModels.FindAsync(newVehicleModel.Id);
            updatedVehicleModel.Name = newVehicleModel.Name;
            updatedVehicleModel.Abrv = newVehicleModel.Abrv;
            await _context.SaveChangesAsync();

            return updatedVehicleModel;
        }
    }
}
