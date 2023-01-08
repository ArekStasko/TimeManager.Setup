using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.SetupTool.Services
{
    public static class FileService
    {
        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {

                }
            }
        }

        public static void WriteData(string path, string data)
        {
            File.WriteAllText(path, string.Empty);
            File.WriteAllText(path, data);
        }
    }
}
