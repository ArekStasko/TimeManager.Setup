using LanguageExt.Common;
using TimeManager.SetupTool.Models;

namespace TimeManager.SetupTool.Controllers.Controllers
{
    public interface IMqController
    {
        public Result<bool> Execute();
    }
}
