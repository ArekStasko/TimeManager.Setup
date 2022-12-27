// See https://aka.ms/new-console-template for more information
using TimeManager.Setup.CommandScheduler;

var scheduler = new Scheduler();
while (true)
{
    scheduler.Schedule();
}
