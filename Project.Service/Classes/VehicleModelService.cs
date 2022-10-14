using Microsoft.EntityFrameworkCore;
using Project.Service.Interfaces;
using Project.Service.Models;
using Project.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Classes
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly ApplicationDbContext _context;
        public VehicleModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleModel> CreateVehicleModelAsync(VehicleModel vehicleModel)
        {
            var addedVehicleModel = await _context.VehicleModels.AddAsync(vehicleModel);
            await _context.SaveChangesAsync();

            return addedVehicleModel.Entity;
        }

        public async Task<List<VehicleModel>> FilterVehicleModelAsync(List<string> filterStrings)
        {
            var result = await _context.VehicleModels.Where(vm => filterStrings.Contains(vm.Name) || filterStrings.Contains(vm.Abrv)).ToListAsync();

            return result;
        }

        public async Task<VehicleModel> GetVehicleModelAsync(int id)
        {
            var result = await _context.VehicleModels.SingleOrDefaultAsync(vm => vm.Id == id);

            return result;
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync()
        {
            var result = await _context.VehicleModels.ToListAsync();

            return result;
        }

        public async Task<List<VehicleModel>> PageVehicleModelAsync(int page, int perPage)
        {
            var result = await _context.VehicleModels.Skip((page - 1) * perPage).Take(perPage).ToListAsync();

            return result;
        }

        public async Task<VehicleModel> RemoveVehicleModelAsync(int id)
        {
            var oldVehicleModel = await GetVehicleModelAsync(id);
            var result = _context.VehicleModels.Remove(oldVehicleModel);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<VehicleModel>> SortDescendingVehicleModelAsync()
        {
            var result = await _context.VehicleModels.OrderByDescending(vm => vm.Name).ToListAsync();

            return result;
        }

        public async Task<List<VehicleModel>> SortVehicleModelAsync()
        {
            var result = await _context.VehicleModels.OrderBy(vm => vm.Name).ToListAsync();

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
