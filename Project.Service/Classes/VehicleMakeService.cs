using Microsoft.EntityFrameworkCore;
using Project.Service.Data;
using Project.Service.Helpers;
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

        public async Task<VehicleMake> GetVehicleMakeModelsAsync(int id)
        {
            var result = await _context.VehicleMakes.Where(vm => vm.Id == id).Include(vm => vm.VehicleModels).SingleOrDefaultAsync();

            return result;
        }

        public async Task<VehicleMake> RemoveVehicleMakeAsync(int id)
        {
            var oldVehicleMake = await GetVehicleMakeAsync(id);
            var result = _context.VehicleMakes.Remove(oldVehicleMake);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<VehicleMake>> SortFilterPageMakeAsync(Paging paging, Sort sorting)
        {
            var result = 
                (sorting.Sorting == Sorting.Asc)
                    ? await _context
                                .VehicleMakes
                                .OrderBy(vm => vm.Name)
                                .Skip((paging.CurrentPage - 1) * paging.PerPage)
                                .Take(paging.PerPage)
                                .ToListAsync()
                    : await _context
                                .VehicleMakes
                                .OrderByDescending(vm => vm.Name)
                                .Skip((paging.CurrentPage - 1) * paging.PerPage)
                                .Take(paging.PerPage)
                                .ToListAsync();
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
