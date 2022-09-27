using Ninject.Infrastructure.Language;
using Project.Service.Interfaces;
using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Classes
{
    public class VehicleService : IVehicleService
    {
        private ApplicationDbContext _context;
        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleMake> CreateVehicleMake(VehicleMake new_vehicleMake)
        {
            var result = await _context.VehicleMakes.AddAsync(new_vehicleMake);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VehicleModel> CreateVehicleModel(VehicleModel new_vehicleModel)
        {
            var result = await _context.VehicleModels.AddAsync(new_vehicleModel);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VehicleMake> DeleteVehicleMake(int id)
        {
            var old_VehicleMake = await DetailsVehicleMake(id);
            var result = _context.VehicleMakes.Remove(old_VehicleMake);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VehicleModel> DeleteVehicleModel(int id)
        {
            var old_vehicleModel = await DetailsVehicleModel(id);
            var result = _context.VehicleModels.Remove(old_vehicleModel);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VehicleMake> DetailsVehicleMake(int id)
        {
            var result = await _context.VehicleMakes.FindAsync(id);
            return result;
        }

        public async Task<VehicleModel> DetailsVehicleModel(int id)
        {
            var result = await _context.VehicleModels.FindAsync(id);
            return result;
        }

        // filter, paging and sort will be used on list of VehicleMakes/VehicleModels which initally can start as an entire list from database

        public List<VehicleMake> FilterVehicleMake(List<string> filter_words, List<VehicleMake> vehicleMakes)
        {
            var filtered_vehicleMakes = new List<VehicleMake>();

            foreach (string filter_word in filter_words)
            {
                foreach (var vehicleMake in vehicleMakes)
                {
                    if (vehicleMake.Name.ToLower().Contains(filter_word.ToLower()) || vehicleMake.Abrv.ToLower().Contains(filter_word.ToLower()))
                    {
                        filtered_vehicleMakes.Add(vehicleMake);
                    }
                }
            }

            return filtered_vehicleMakes.Distinct().ToList();
        }

        public List<VehicleModel> FilterVehicleModel(List<string> filter_words, List<VehicleModel> vehicleModels)
        {
            var filtered_vehicleModels = new List<VehicleModel>();

            foreach (string filter_word in filter_words)
            {
                foreach (var vehicleModel in vehicleModels)
                {
                    if (vehicleModel.Name.ToLower().Contains(filter_word.ToLower()) || vehicleModel.Abrv.ToLower().Contains(filter_word.ToLower()) || (filter_words.Count() == 1 && vehicleModel.VehicleMake.Name.ToLower() == filter_word.ToLower()))
                    {
                        filtered_vehicleModels.Add(vehicleModel);
                    }
                }
            }

            return filtered_vehicleModels.Distinct().ToList();
        }

        public List<VehicleMake> PageVahicleMake(int page, int perpage, List<VehicleMake> vehicleMakes)
        {
            if (vehicleMakes.Count() < page * perpage)
            {
                return new List<VehicleMake>();
            }
            return vehicleMakes.Skip((page - 1) * perpage).Take(perpage).ToList();
        }

        public List<VehicleModel> PageVahicleModel(int page, int perpage, List<VehicleModel> vehicleModels)
        {
            if (vehicleModels.Count() < page * perpage)
            {
                return new List<VehicleModel>();
            }
            return vehicleModels.Skip((page - 1) * perpage).Take(perpage).ToList();
        }

        public IEnumerable<VehicleMake> ReadVehicleMakes()
        {
            return _context.VehicleMakes.ToEnumerable();
        }

        public IEnumerable<VehicleModel> ReadVehicleModels()
        {
            return _context.VehicleModels.ToEnumerable();
        }

        public List<VehicleModel> SortVehcleModel(List<VehicleModel> vehicleModels, bool? descending)
        {
            if (descending == null)
            {
                return vehicleModels.OrderBy(t => t.Name).ToList();
            }

            if (!descending.Value)
            {
                return vehicleModels.OrderBy(t => t.Name).ToList();
            }

            return vehicleModels.OrderByDescending(t => t.Name).ToList();
        }

        public List<VehicleMake> SortVehicleMake(List<VehicleMake> vehicleMakes, bool? descending)
        {
            if (descending == null)
            {
                return vehicleMakes.OrderBy(t => t.Name).ToList();
            }

            if (!descending.Value)
            {
                return vehicleMakes.OrderBy(t => t.Name).ToList();
            }

            return vehicleMakes.OrderByDescending(t => t.Name).ToList();
        }

        public async Task<VehicleMake> UpdateVehicleMake(VehicleMake new_vehicleMake)
        {
            var update_vehicleMake = await DetailsVehicleMake(new_vehicleMake.Id);
            update_vehicleMake.Abrv = new_vehicleMake.Abrv;
            update_vehicleMake.Name = new_vehicleMake.Name;

            await _context.SaveChangesAsync();

            return update_vehicleMake;
        }

        public async Task<VehicleModel> UpdateVehicleModel(VehicleModel new_vehicleModel)
        {
            var update_vehicleModel = await DetailsVehicleModel(new_vehicleModel.Id);
            update_vehicleModel.Abrv = new_vehicleModel.Abrv;
            update_vehicleModel.Name = new_vehicleModel.Name;

            await _context.SaveChangesAsync();

            return update_vehicleModel;
        }
    }
}
