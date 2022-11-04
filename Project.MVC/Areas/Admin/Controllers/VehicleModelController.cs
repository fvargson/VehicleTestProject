using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Interfaces;
using Project.Service.Models;
using AutoMapper;
using Project.Service.DTO.VehicleModel;
using Project.Service.Helpers;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VehicleModelController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleModelService _vehicle_model_service;
        private readonly IVehicleMakeService _vehicle_make_service;
        public VehicleModelController(IMapper mapper, IVehicleModelService vehicleModelService, IVehicleMakeService vehicle_make_service)
        {
            _mapper = mapper;
            _vehicle_model_service = vehicleModelService;
            _vehicle_make_service = vehicle_make_service;
        }
        // GET: VehicleModel
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync(int makeFilter = 0, int page = 1, int perPage = 10, Sorting sort = Sorting.Asc)
        {
            Filtering filtering = new Filtering()
            {
                FilterId = makeFilter
            };
            Sort sorting = new Sort()
            {
                Sorting = sort
            };
            Paging paging = new Paging()
            {
                PerPage = perPage,
                CurrentPage = page,
                Total = ((await _vehicle_model_service.CountVehicleModelByMakeAsync(makeFilter)) + perPage - 1) / perPage
            };

            var vehicleModels = await _vehicle_model_service.SortFilterPageModelAsync(filtering, paging, sorting);

            ViewData["Paging"] = paging;

            ViewData["MakeFilter"] = filtering;

            ViewData["ControllerName"] = "VehicleModel";

            ViewBag.VehicleMakes = await _vehicle_make_service.GetVehicleMakesAsync();

            var result = _mapper.Map<List<VehicleModel>, List<GetVehicleModelMakeDto>>(vehicleModels);

            return View("Index", result);
        }

        // GET: VehicleModel/Details/5
        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var vehicleModel = await _vehicle_model_service.GetVehicleModelAsync(id);

            var result = _mapper.Map<VehicleModel, GetVehicleModelMakeDto>(vehicleModel);
            
            return View("Details", result);
        }

        // GET: VehicleModel/Create
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync(int? MakeId)
        {
            if (MakeId != null)
            {
                ViewBag.MakeId = MakeId.Value;
            }
            ViewBag.VehicleMakes = await _vehicle_make_service.GetVehicleMakesAsync();

            return View();
        }

        // POST: VehicleModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync(VehicleModel vehicleModel)
        {
            try
            {
                var result = await _vehicle_model_service.CreateVehicleModelAsync(vehicleModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: VehicleModel/Edit/5
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(int id)
        {
            var vehicleModel = await _vehicle_model_service.GetVehicleModelAsync(id);

            ViewBag.VehicleMakes = await _vehicle_make_service.GetVehicleMakesAsync();

            var result = _mapper.Map<VehicleModel, VehicleModelDto>(vehicleModel);

            return View(result);
        }

        // POST: VehicleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(VehicleModel vehicleModel)
        {
            try
            {
                var result = await _vehicle_model_service.UpdateVehicleModelAsync(vehicleModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: VehicleModel/Delete/5
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var vehicleModel = await _vehicle_model_service.GetVehicleModelAsync(id);

            var result = _mapper.Map<VehicleModel, GetVehicleModelMakeDto>(vehicleModel);

            return View(result);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                var result = await _vehicle_model_service.RemoveVehicleModelAsync(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }
    }
}