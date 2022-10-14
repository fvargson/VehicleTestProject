using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ninject.Modules;
using Project.MVC.Controllers;
using Project.Service.Classes;
using Project.Service.Interfaces;
using Project.Service.Models;

namespace Project.MVC.Models
{
    public class NinjectService : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleModelService>().To<VehicleModelService>();
            Bind<IVehicleMakeService>().To<VehicleMakeService>();
            Bind<IMapper>().To<Mapper>();
        }
    }
}
