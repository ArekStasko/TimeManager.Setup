using LanguageExt.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.SetupTool.Models;
using TimeManager.SetupTool.Services;

namespace TimeManager.SetupTool.Controllers
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
