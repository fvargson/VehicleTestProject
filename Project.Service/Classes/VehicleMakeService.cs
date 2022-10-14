using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Interfaces;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Classes
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly ApplicationDbContext _context;
        public VehicleMakeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleMake> CreateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            var addedVehicleModel = await _context.VehicleMakes.AddAsync(vehicleMake);
            await _context.SaveChangesAsync();

            return addedVehicleModel.Entity;
        }

        public async Task<List<VehicleMake>> FilterVehicleMakeAsync(List<string> filterStrings)
        {
            var result = await _context.VehicleMakes.Where(vm => filterStrings.Contains(vm.Name) || filterStrings.Contains(vm.Abrv)).ToListAsync();

            return result;
        }

        public async Task<VehicleMake> GetVehicleMakeAsync(int id)
        {
            var result = await _context.VehicleMakes.SingleOrDefaultAsync(vm => vm.Id == id);

            return result;
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync()
        {
            var result = await _context.VehicleMakes.ToListAsync();

            return result;
        }

        public async Task<List<VehicleMake>> PageVehicleMakeAsync(int page, int perPage)
        {
            var result = await _context.VehicleMakes.Skip((page - 1) * perPage).Take(perPage).ToListAsync();

            return result;
        }

        public async Task<VehicleMake> RemoveVehicleMakeAsync(int id)
        {
            var oldVehicleMake = await GetVehicleMakeAsync(id);
            var result = _context.VehicleMakes.Remove(oldVehicleMake);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<VehicleMake>> SortDescendingVehicleMakeAsync()
        {
            var result = await _context.VehicleMakes.OrderByDescending(vm => vm.Name).ToListAsync();

            return result;
        }

        public async Task<List<VehicleMake>> SortVehicleMakeAsync()
        {
            var result = await _context.VehicleMakes.OrderBy(vm => vm.Name).ToListAsync();

            return result;
        }

        public async Task<VehicleMake> UpdateVehicleMakeAsync(VehicleMake newVehicleMake)
        {
            var updatedVehicleMake = await _context.VehicleMakes.FindAsync(newVehicleMake.Id);
            updatedVehicleMake.Name = newVehicleMake.Name;
            updatedVehicleMake.Abrv = newVehicleMake.Abrv;
            await _context.SaveChangesAsync();

            return updatedVehicleMake;
        }
    }
}
