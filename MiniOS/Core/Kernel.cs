using System.Net.Mime;
using System.Threading;
namespace MiniOS.Core;

public class Kernel
{
    //Brain of the os 
    //Management of Modules
    //Global Status
    //Shutdown
    
    
    public InMemoryFS FileSystem { get; private set; } = new();
    public ProcessManager Processes { get; private set; } = new();
    public bool IsRunning { get; private set; } = true;
    
    public void Boot()
    {
        Random rnd = new Random();
        FileSystem = new InMemoryFS();
        
        Console.WriteLine("[OS] Booting up...");
        Thread.Sleep(100);
        //Console.Beep(1000, 500);
        
        PMLOADER();
        //Console.Beep(500, 500);
        
        FSLOADER();
        //Console.Beep(1000, 500);

        if (IsRunning == false)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[OS] BOOT FAILED!!");
            Console.ResetColor();
            Environment.Exit(0);
        }
        else
        {
            Console.Clear();
            Menu();
        }

        
    }

    public void Shutdown()
    {
        Console.WriteLine("[sys] Shutting down..");
        IsRunning = false;
    }

    public void PMLOADER()
    {
        Random rnd = new Random();
        Thread.Sleep(rnd.Next(300, 1000));
        Console.WriteLine("[OS] Loading Important Stuff...");
        
        
    }

    public void FSLOADER()
    {
        Random rnd = new Random();
        
        Console.WriteLine("[OS] File System Loading...");
        Thread.Sleep(rnd.Next(200,2000));
        if (!FileSystem.FSLOAD() == true)
        {
            Console.WriteLine("[OS] File System Failed...");
            IsRunning = false;
        }
        else
        {
            Console.WriteLine("[OS] File System Loaded.");
        }
        Thread.Sleep(rnd.Next(200,1000));
    }

    void Menu()
    {
        // +============================================+
        // |                         _____   ____       |
        // | /'\_/`\  __          __/\  __`\/\  _`\     |
        // |/\      \/\_\    ___ /\_\ \ \/\ \ \,\L\_\   |
        // |\ \ \__\ \/\ \ /' _ `\/\ \ \ \ \ \/_\__ \   |
        // | \ \ \_/\ \ \ \/\ \/\ \ \ \ \ \_\ \/\ \L\ \ |
        // |  \ \_\\ \_\ \_\ \_\ \_\ \_\ \_____\ `\____\|
        // |   \/_/ \/_/\/_/\/_/\/_/\/_/\/_____/\/_____/|
        // +============================================+
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"+============================================+");
        Thread.Sleep(500);
        //Console.Beep(200, 100);
        Console.WriteLine(@"|                         _____   ____       |");
        Thread.Sleep(500);
        Console.WriteLine(@"| /'\_/`\  __          __/\  __`\/\  _`\     |");
        Thread.Sleep(500);
        //Console.Beep(200, 100);
        Console.WriteLine(@"|/\      \/\_\    ___ /\_\ \ \/\ \ \,\L\_\   |");
        Thread.Sleep(500);
        Console.WriteLine(@"|\ \ \__\ \/\ \ /' _ `\/\ \ \ \ \ \/_\__ \   |");
        Thread.Sleep(500);
        //Console.Beep(200, 100);
        Console.WriteLine(@"| \ \ \_/\ \ \ \/\ \/\ \ \ \ \ \_\ \/\ \L\ \ |");
        Thread.Sleep(500);
        Console.WriteLine(@"|  \ \_\\ \_\ \_\ \_\ \_\ \_\ \_____\ `\____\|");
        Thread.Sleep(500);
        //Console.Beep(200, 100);
        Console.WriteLine(@"|   \/_/ \/_/\/_/\/_/\/_/\/_/\/_____/\/_____/|");
        Thread.Sleep(500);
        Console.WriteLine(@"+============================================+");
        //Console.Beep(200, 100);
        Console.ResetColor();
        
        //Console.Beep(500, 80);
        //Console.Beep(1000, 80);
        //Console.Beep(600, 100);
        //Console.Beep(1300, 100);
        //Console.Beep(1000, 500);
        //Console.Beep(800, 600);

    }

    public bool ProcessRun()
    {
        return true;
    }

}