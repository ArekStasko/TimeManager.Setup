using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.SetupTool.Controllers.Controllers
{
    public interface ITestsController
    {
        public Result<bool> Execute();
    }
}
