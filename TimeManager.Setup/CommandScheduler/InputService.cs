using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Setup.CommandScheduler
{
    public class InputService
    {
        private string[] UserChoice { get; set; }
        private View view { get; set; } = new View();



        private string[] GetUserInput()
        {
            var commands = view.GetAvailableCommands();

            Console.Write("> ");

            string[] input = Console.ReadLine().Split(" ");

            while (input.Length < 2 || input.Length > 2)
            {
                view.PrintInputInfo("Wrong Command");

                Console.Write("> ");
                input = Console.ReadLine().Split(" ");
            }

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
            view.PrintInfo("Hello in TimeManager setup");
            view.PrintAvailableCommands();
            UserChoice = GetUserInput();
        }

        public string GetAlias() => UserChoice[0];
        public string GetCommand() => UserChoice[1];

    }
}
