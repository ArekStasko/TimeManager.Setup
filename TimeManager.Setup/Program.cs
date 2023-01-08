using TimeManager.Setup.CommandScheduler;
using TimeManager.SetupTool.Controllers.Container;

var scheduler = new Scheduler();
while (true)
{
    scheduler.Schedule();
}
