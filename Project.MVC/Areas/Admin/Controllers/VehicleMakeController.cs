using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Service.Interfaces;
using Project.Service.Models;
using AutoMapper;
using Project.Service.DTO.VehicleMake;
using Project.Service.Helpers;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VehicleMakeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleMakeService _vehicle_make_service;
        public VehicleMakeController(IMapper mapper, IVehicleMakeService vehicleMakeService)
        {
            _mapper = mapper;
            _vehicle_make_service = vehicleMakeService;
        }
        // GET: VehicleMake
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync(int page = 1, int perPage = 10, Sorting sort = Sorting.Asc)
        {
            Sort sorting = new Sort() {
                Sorting = sort 
            };
            Paging paging = new Paging() { 
                PerPage = perPage, 
                CurrentPage = page, 
                Total = (await _vehicle_make_service.CountVehicleMakeAsync() + perPage - 1) / perPage 
            };
            
            var vehicleMakes = await _vehicle_make_service.SortFilterPageMakeAsync(paging, sorting);
            
            ViewData["Paging"] = paging;
            
            ViewData["ControllerName"] = "VehicleMake";

            var result = _mapper.Map<List<VehicleMake>, List<GetVehicleMakeDto>>(vehicleMakes);

            return View("Index", result);
        }

        // GET: VehicleMake/Details/5
        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var vehicleMakeModels = await _vehicle_make_service.GetVehicleMakeModelsAsync(id);

            var result = _mapper.Map<VehicleMake, GetVehicleMakeDetailsDto>(vehicleMakeModels);

            return View("Details", result);
        }

        // GET: VehicleMake/Create
        [ActionName("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync(VehicleMake vehicleMake)
        {
            try
            {
                var result = await _vehicle_make_service.CreateVehicleMakeAsync(vehicleMake);

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: VehicleMake/Edit/5
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(int id)
        {
            var vehicleMake = await _vehicle_make_service.GetVehicleMakeAsync(id);

            var result = _mapper.Map<VehicleMake, GetVehicleMakeDto>(vehicleMake);

            return View(result);
        }

        // POST: VehicleMake/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(VehicleMake vehicleMake)
        {
            try
            {
                var result = await _vehicle_make_service.UpdateVehicleMakeAsync(vehicleMake);

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: VehicleMake/Delete/5
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var vehicleMake = await _vehicle_make_service.GetVehicleMakeAsync(id);

            var result = _mapper.Map<VehicleMake, GetVehicleMakeDto>(vehicleMake);

            return View(result);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                var result = await _vehicle_make_service.RemoveVehicleMakeAsync(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }
    }
}