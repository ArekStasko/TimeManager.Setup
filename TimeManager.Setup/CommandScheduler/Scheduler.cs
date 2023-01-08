

namespace TimeManager.Setup.CommandScheduler
{
    public class Scheduler
    {
        private string command { get; set; }
        private string alias { get; set; }

        private void RunMQBuilder()
        {
                Console.WriteLine("Building MQ definitons started");
                
                var MQBuilder = ServiceContainer.Controllers.MqController;
                MQBuilder.Execute();

                Console.WriteLine("--- MQ DEFINITIONS BUILD SUCCEDED ---");
        }

        private void RunDocker()
        {
                Console.WriteLine("Running docker compose build");

                var dockerController = ServiceContainer.Controllers.DockerController;
                dockerController.Execute();

                Console.WriteLine("--- DOCKER COMPOSE BUILD SUCCEDED");
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
