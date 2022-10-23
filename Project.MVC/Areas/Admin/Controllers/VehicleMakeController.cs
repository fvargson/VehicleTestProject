using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Service.Helpers;
using Project.Service.Interfaces;
using Project.Service.Models;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _vehicle_make_service;
        public VehicleMakeController()
        {
            _vehicle_make_service = NinjectDI.Create<IVehicleMakeService>();
        }
        // GET: VehicleMake
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync(string filterStrings = "", int page = 1, int perPage = 10, Sorting sort = Sorting.Asc)
        {
            var filteringStrings = new List<string>();
            if (filterStrings.Trim() != "")
            {
                filteringStrings = filterStrings.Trim().Split(' ').ToList();
            }
            var result = await _vehicle_make_service.SortFilterPageMakeAsync(page, filteringStrings, perPage, sort);
            ViewData["PageNumber"] = page;
            ViewData["PageCount"] = (await _vehicle_make_service.CountVehicleMakeAsync() + perPage - 1) / perPage;
            ViewData["PerPage"] = perPage;
            ViewData["Filter"] = filterStrings;
            ViewData["ControllerName"] = "VehicleMake";

            return View("Index", result);
        }

        // GET: VehicleMake/Details/5
        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var result = await _vehicle_make_service.GetVehicleMakeAsync(id);
            var vehicleModels = await NinjectDI.Create<IVehicleModelService>().GetVehicleModelsAsync();
            var vehicleModelsResult = vehicleModels.Where(vm => vm.MakeId == id).ToList();

            ViewBag.VehicleModels = vehicleModelsResult;

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
            var result = await _vehicle_make_service.GetVehicleMakeAsync(id);

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
            var result = await _vehicle_make_service.GetVehicleMakeAsync(id);

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