using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using Project.Service.Classes;
using Project.Service.Data;
using Project.Service.Interfaces;

namespace Project.Service.Helpers
{
    public class NinjectService : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleModelService>().To<VehicleModelService>();
            Bind<IVehicleMakeService>().To<VehicleMakeService>();
            Bind<ApplicationDbContext>().To<ApplicationDbContext>();
        }
    }
}
