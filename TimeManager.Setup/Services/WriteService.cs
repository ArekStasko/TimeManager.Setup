using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Setup
{
    public class WriteService : IWriteService
    {
        public void Print(string msg) => Console.WriteLine(msg);
        public void PrintInput(string msg)
        {
            Print(msg);
            Console.Write("> ");
        }

        public void PrintAvailableCommands()
        {
            Console.WriteLine("Available commands :");

            var result = ServiceContainer.Controllers.CommandsController.Execute();

            _ = result.Match<bool>(com =>
            {
                for (var i = 0; i < com.AvailableCommands.Count(); i++) Console.WriteLine($"* {com.Alias} {com.AvailableCommands[i]}");
                return true;
            }, exception =>
            {
                Console.WriteLine(exception);
                return false;
            });

        }

    }
}
