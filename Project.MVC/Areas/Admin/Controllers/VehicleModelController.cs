using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.MVC.Models;
using Project.Service.Classes;
using Project.Service.Interfaces;
using Project.Service.Models;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize("Admin")]
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicle_model_service;
        public VehicleModelController()
        {
            _vehicle_model_service = NinjectDI.Create<VehicleModelService>();
        }
        // GET: VehicleModel
        public ActionResult Index()
        {
            var result = _vehicle_model_service.GetVehicleModelsAsync();

            return View(result);
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}