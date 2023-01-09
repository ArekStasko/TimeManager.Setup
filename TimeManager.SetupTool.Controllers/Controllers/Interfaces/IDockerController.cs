
using LanguageExt.Common;

namespace TimeManager.SetupTool.Controllers.Controllers
{
    public interface IDockerController
    {
        public Result<bool> Execute();
    }
}
