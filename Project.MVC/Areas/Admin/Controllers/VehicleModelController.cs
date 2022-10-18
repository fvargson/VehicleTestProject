using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Interfaces;
using Project.Service.Helpers;
using Project.Service.Models;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicle_model_service;
        public VehicleModelController()
        {
            _vehicle_model_service = NinjectDI.Create<IVehicleModelService>();
        }
        // GET: VehicleModel
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var result = await _vehicle_model_service.GetVehicleModelsAsync();

            return View("Index", result);
        }

        // GET: VehicleModel/Details/5
        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var result = await _vehicle_model_service.GetVehicleModelAsync(id);
            var make = await NinjectDI.Create<IVehicleMakeService>().GetVehicleMakeAsync(result.MakeId);
            ViewBag.Make = make.Name;

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
            ViewBag.VehicleMakes = await NinjectDI.Create<IVehicleMakeService>().GetVehicleMakesAsync();

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
            var result = await _vehicle_model_service.GetVehicleModelAsync(id);
            ViewBag.VehicleMakes = await NinjectDI.Create<IVehicleMakeService>().GetVehicleMakesAsync();

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
            var result = await _vehicle_model_service.GetVehicleModelAsync(id);

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