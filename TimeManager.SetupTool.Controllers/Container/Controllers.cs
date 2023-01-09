using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.SetupTool.Controllers.Controllers;

namespace TimeManager.SetupTool.Controllers.Container
{
    public class Controllers : IControllers
    {
        public Controllers() => _container = ContainerGenerator.CreateControllersContainer();

        private IContainer _container { get; }
        public IMqController MqController { get => _container.Resolve<IMqController>(); }
        public IDockerController DockerController { get => _container.Resolve<IDockerController>(); }
        public ICommandsController CommandsController { get => _container.Resolve<ICommandsController>(); }
        public ITestsController TestsController { get => _container.Resolve<ITestsController>(); }
    }
}
