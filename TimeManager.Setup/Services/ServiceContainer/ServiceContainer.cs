using TimeManager.SetupTool.Controllers.Container;
using TimeManager.SetupTool.Models;

namespace TimeManager.Setup
{
    public static class ServiceContainer
    {
        public static IControllers Controllers { get => new Controllers(); }
        public static IWriteService WriteService { get => new WriteService(); }
        public static IInputService InputService { get => new InputService(); }
    }
}
