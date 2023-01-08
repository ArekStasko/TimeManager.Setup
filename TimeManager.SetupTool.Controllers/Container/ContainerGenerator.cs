using Autofac;
using System.Reflection;

namespace TimeManager.SetupTool.Controllers.Container
{
    public class ContainerGenerator
    {
        public static IContainer CreateControllersContainer()
        {
            var container = new ContainerBuilder();

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Namespace == "TimeManager.SetupTool.Controllers")
                .As(t => t.GetInterfaces().FirstOrDefault(t => t.Name == "I" + t.Name));

            return container.Build();
        }
    }
}
