using Ninject;
using System.Reflection;

namespace Project.Service.Helpers
{
    public static class NinjectDI
    {
        static StandardKernel _kernel;

        static public void Initialize()
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
        }

        static public T Create<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
