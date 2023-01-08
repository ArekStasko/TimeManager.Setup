using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Setup
{
    public class InputService : IInputService
    {
        private string[] UserChoice { get; set; }

        private string[] GetUserInput()
        {
            var writeService = ServiceContainer.WriteService;
            writeService.Print("> ");

            string[] input = Console.ReadLine().Split(" ");

            while (input.Length < 2 || input.Length > 2)
            {
                writeService.PrintInput("Wrong Command");

                input = Console.ReadLine().Split(" ");
            }

            var result = ServiceContainer.Controllers.CommandsController.Execute();
            var commands =

            _ = result.Match<bool>(cmd =>
            {
                
            }, exception =>
            {

            });

            while (!commands.AvailableCommands.Contains(input[1]) || commands.Alias != input[0])
            {
                view.PrintInputInfo("Wrong Command");

                Console.Write("> ");
                input = Console.ReadLine().Split(" ");
            }

            return input;
        }

        public void Execute()
        {
            var writeService = ServiceContainer.WriteService;
            writeService.Print("Hello in TimeManager setup");
            writeService.PrintAvailableCommands();

            UserChoice = GetUserInput();
        }

        public string GetAlias() => UserChoice[0];
        public string GetCommand() => UserChoice[1];
    }
}
