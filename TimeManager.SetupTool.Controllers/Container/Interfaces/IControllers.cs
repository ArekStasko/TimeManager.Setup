using TimeManager.SetupTool.Controllers.Controllers;

namespace TimeManager.SetupTool.Controllers.Container
{
    public interface IControllers
    {
        public IMqController MqController { get; }
        public IDockerController DockerController { get; }
        public ICommandsController CommandsController { get; }
        public ITestsController TestsController { get; }
    }
}
