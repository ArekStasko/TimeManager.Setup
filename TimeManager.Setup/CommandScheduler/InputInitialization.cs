using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Setup.CommandScheduler
{
    public class InputInitialization
    {
        private string UserChoice { get; set; }
        private ViewOptions viewOptions { get; set; } = new ViewOptions();
        public void Execute()
        {
            Console.WriteLine("Hello in TimeManager setup");
            viewOptions.PrintAvailableCommands();
            UserChoice = Console.ReadLine();
        }
    }
}
