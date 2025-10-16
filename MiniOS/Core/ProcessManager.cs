using System.Diagnostics;

namespace MiniOS.Core;

public class ProcessManager
{
    //Manager of processes
    //Creates process -> PID, Name, Status(running, waiting, terminated)
    //list of processes -> lists active processes
    //Ending of processes -> kills PID
    //Cleaning of processes -> Scheduler ends processes after end of and process
    
    static Dictionary<string, bool> _processes = new();
    
    //KILL

    public static void KillProcess(string processName)
    {
        
        
        if (!_processes.ContainsKey(processName)) //if the dictionary doesnt contain that process
        {
           Console.WriteLine($"Process {processName} is not running");  //process does not exist
        }
        else
        {
            Console.WriteLine($"Killing {processName}.."); //killing the process
            _processes[processName] = false; //setting bool of process to false
            _processes.Remove(processName); //removing the processname
        }

    }
    
    //START
    public static void StartProcess(string processName)
    {
        
        
    }
    
    //LIST
    public static void ListAllProcesses()
    {
        
        Console.WriteLine("Processes: ");
        if (_processes.Count == 0)
        {
            Console.WriteLine("No processes are running");
            return;
        }

        foreach (var process in _processes)
        {
            Console.WriteLine($"{ProcessStatus(process.Key)}: {process.Value}");
        }


    }

    public static string ProcessStatus(string processName)
    {
        
        if(_processes.ContainsKey (processName))
        {
            if (_processes[processName] == false)
                return $"{processName} is Paused..";
            
            if (_processes[processName] == true)
                return $"{processName} is Running..";
        }
        
        if (!_processes.ContainsKey(processName))
        {
            return $"{processName} is not running";
        }

        return null;
    }


    


}