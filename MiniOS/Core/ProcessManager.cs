using System.Diagnostics;

namespace MiniOS.Core;

public class ProcessManager
{
    //Manager of processes
    //Creates process -> PID, Name, Status(running, waiting, terminated)
    //list of processes -> lists active processes
    //Ending of processes -> kills PID
    //Cleaning of processes -> Scheduler ends processes after end of and process

    public Dictionary<string, Process> processes = new();

    static ProcessManager()
    {
        processes[""] = () =>
        {
            
        };

    }

}