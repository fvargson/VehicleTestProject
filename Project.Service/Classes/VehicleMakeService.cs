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

        public async Task<int> CountVehicleMakeAsync()
        {
            var result = await _context.VehicleMakes.CountAsync();

            return result;
        }

        public async Task<VehicleMake> CreateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            var addedVehicleModel = await _context.VehicleMakes.AddAsync(vehicleMake);
            await _context.SaveChangesAsync();

            return addedVehicleModel.Entity;
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

        public async Task<VehicleMake> RemoveVehicleMakeAsync(int id)
        {
            var oldVehicleMake = await GetVehicleMakeAsync(id);
            var result = _context.VehicleMakes.Remove(oldVehicleMake);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<VehicleMake>> SortFilterPageMakeAsync(int page, List<string> filterStrings, int perPage = 10, Sorting order = Sorting.Asc)
        {
            var result = 
                (order == Sorting.Asc)
                    ? await _context.VehicleMakes.Where(vm => filterStrings.Contains(vm.Name) || filterStrings.Count() == 0).OrderBy(vm => vm.Name).Skip((page - 1) * perPage).Take(perPage).ToListAsync()
                    : await _context.VehicleMakes.Where(vm => filterStrings.Contains(vm.Name) || filterStrings.Count() == 0).OrderByDescending(vm => vm.Name).Skip((page - 1) * perPage).Take(perPage).ToListAsync();
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
