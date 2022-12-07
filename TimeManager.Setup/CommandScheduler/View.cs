using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Setup.Services;

namespace TimeManager.Setup.CommandScheduler
{
    public class View
    {
        private Commands AvailableCommands { get; set; }

        public View()
        {
            AvailableCommands = InitializeCommands();
        }
        private Commands InitializeCommands()
        {
            var path = PathService.GetConfigFilePath();
            string file = File.ReadAllText($"{path}\\config\\commands.json");
            return JsonConvert.DeserializeObject<Commands>(file);
        }
        public Commands GetAvailableCommands() => AvailableCommands;

        public void PrintInfo(string msg) => Console.WriteLine(msg);
        public void PrintInputInfo(string msg) 
        {
            PrintInfo(msg);
            Console.Write("> ");
        }
        
        public void PrintAvailableCommands()
        {
            Console.WriteLine("Available commands :");
            for(var i = 0; i < AvailableCommands.AvailableCommands.Count(); i++) Console.WriteLine($"* {AvailableCommands.Alias} {AvailableCommands.AvailableCommands[i]}");            
        }       

    }
}
