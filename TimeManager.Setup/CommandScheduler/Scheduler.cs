using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Setup.ConfigBuilder;
using TimeManager.Setup.Services;

namespace TimeManager.Setup.CommandScheduler
{
    public class Scheduler
    {
        private string command { get; set; }
        private string alias { get; set; }

        private void RunMQBuilder()
        {
            try
            {
                var MQBuilder = new MQDefinitionsBuilder();
                Console.WriteLine("Building MQ definitons started");
                MQBuilder.Execute();
                Console.WriteLine("--- MQ DEFINITIONS BUILD SUCCEDED ---");
            }
            catch (Exception ex)
            {
                Console.WriteLine("--- ERROR ---");
                throw ex;
            }            
        }

        private void RunDocker()
        {
            try
            {
                Console.WriteLine("Running docker compose build");
                Process p = new Process()
                {
                    StartInfo =
                    {
                        FileName = "docker-compose",
                        WorkingDirectory =PathService.GetConfigFilePath(),
                        Arguments = "up --build"
                    }
                };

                p.Start();
                Console.WriteLine("--- DOCKER COMPOSE BUILD SUCCEDED");
            }
            catch (Exception ex)
            {
                Console.WriteLine("--- ERROR ---");
                throw ex;
            }
        }

        public void Schedule()
        {
            var inputService = new InputService();
            inputService.Execute();

            alias = inputService.GetAlias();
            command = inputService.GetCommand();

            if(alias == "timemanager")
            {
                switch (command)
                {
                    case "all":
                        RunMQBuilder();
                        RunDocker();
                        break;
                    case "run-docker":
                        RunDocker();
                        break;
                    case "build-queues":
                        RunMQBuilder();
                        break;
                }
            }
        }

    }
}
