

namespace TimeManager.Setup.CommandScheduler
{
    public class Scheduler
    {
        private string command { get; set; }
        private string alias { get; set; }
        private IWriteService writeService { get => ServiceContainer.WriteService; }

        private void RunMQBuilder()
        {
                writeService.Print("Building MQ definitons started");
                
                var MQBuilder = ServiceContainer.Controllers.MqController;
                MQBuilder.Execute();

               writeService.Print("--- MQ DEFINITIONS BUILD SUCCEDED ---");
        }

        private void RunDocker()
        {
                writeService.Print("Running docker compose build");

                var dockerController = ServiceContainer.Controllers.DockerController;
                dockerController.Execute();

                writeService.Print("--- DOCKER COMPOSE BUILD SUCCEDED");
        }

        private void RunTests()
        {
            writeService.Print("STARTING TIMEMANAGER TESTS");
            
            var testsController = ServiceContainer.Controllers.TestsController;
            testsController.Execute();

            writeService.Print("TIMEMANAGER TESTS DONE");
        }

        public void Schedule()
        {
            var inputService = ServiceContainer.InputService;
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
                    case "test":
                        RunTests();
                        break;
                }
            }
        }

    }
}
