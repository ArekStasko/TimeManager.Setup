using LanguageExt.Common;
using Newtonsoft.Json;
using TimeManager.SetupTool.Models;
using TimeManager.SetupTool.Controllers.Services;

namespace TimeManager.SetupTool.Controllers.Controllers
{
    public class CommandsController : ICommandsController
    {
        public Result<Commands> Execute()
        {
            try
            {
                var path = PathService.GetConfigFilePath();
                string file = File.ReadAllText($"{path}\\config\\commands.json");
                var commands = JsonConvert.DeserializeObject<Commands>(file);

                return new Result<Commands>(commands);
            }
            catch (Exception ex)
            {
                return new Result<Commands>(ex);
            }
        }
    }
}
