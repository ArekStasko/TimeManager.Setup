using LanguageExt.Common;
using TimeManager.SetupTool.Models;

namespace TimeManager.SetupTool.Controllers.Controllers
{
    public interface ICommandsController
    {
        public Result<Commands> Execute();
    }
}
