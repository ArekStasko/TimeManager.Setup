using LanguageExt.Common;
using System.Diagnostics;
using TimeManager.SetupTool.Controllers.Services;

namespace TimeManager.SetupTool.Controllers.Controllers
{
    public class TestsController : ITestsController
    {
        private List<Process> TestsToRun;
        public Result<bool> Execute()
        {
            try
            {
                string basePath = PathService.GetProjectsPath();
                string testCommand = "test --no-build";
                string alias = "dotnet";

                TestsToRun = new List<Process>()
                {
                    new Process()
                    {
                        StartInfo =
                        {
                            FileName = alias,
                            WorkingDirectory = $"{basePath}\\TimeManager.Data",
                            Arguments = testCommand
                        }
                    },
                    new Process()
                    {
                        StartInfo =
                        {
                            FileName = alias,
                            WorkingDirectory = $"{basePath}\\TimeManager.IdP",
                            Arguments = testCommand
                        }
                    },
                    new Process()
                    {
                        StartInfo =
                        {
                            FileName = alias,
                            WorkingDirectory = $"{basePath}\\TimeManager.Data",
                            Arguments = testCommand
                        }
                    }
            };

                foreach(var test in TestsToRun)
                {
                    test.Start();
                    test.WaitForExit();
                }

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }
    }
}
