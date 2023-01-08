
using LanguageExt.Common;

namespace TimeManager.SetupTool.Controllers
{
    public interface IDockerController
    {
        public Result<bool> Execute();
    }
}
