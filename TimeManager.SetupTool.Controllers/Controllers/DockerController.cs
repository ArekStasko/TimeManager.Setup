using TimeManager.SetupTool.Services;
using LanguageExt.Common;
using System.Diagnostics;

namespace TimeManager.SetupTool.Controllers
{
    public class DockerController : IDockerController
    {
        public Result<bool> Execute()
        {
            try
            {
                Process p = new Process()
                {
                    StartInfo =
                    {
                        FileName = "docker-compose",
                        WorkingDirectory = PathService.GetConfigFilePath(),
                        Arguments = "up --build"
                    }
                };

                p.Start();

                return new Result<bool>(true);
            }
            catch(Exception ex)
            {
                return new Result<bool>(ex);
            }
        }
    }
}
