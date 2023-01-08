using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.SetupTool.Services
{
    public static class PathService
    {
        public static string GetConfigFilePath()
        {
            string? path = Environment.CurrentDirectory;
            var directoryName = new DirectoryInfo(path).Name;

            while (directoryName != "TimeManager.SetupTool" || path == null)
            {
                path = Directory.GetParent(path).ToString();
                directoryName = new DirectoryInfo(path).Name;
            }

            return path;
        }
    }
}
