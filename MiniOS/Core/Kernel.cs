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
        try
        {
            
            Console.WriteLine("[OS] Booting up...");
            Thread.Sleep(100);
            Console.Beep(1000, 500);
            Console.WriteLine("[OS] Loading Important Stuff...");
            Console.Beep(500, 500);
            Thread.Sleep(1000);
            Console.WriteLine("[OS] File System Loading...");
            Console.Beep(1000, 500);
            Thread.Sleep(2000);
            //Console.Clear();
            Menu();
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR WHILE BOOTING: {e.Message}");
            throw;
        }
        
    }

    public void Shutdown()
    {
        Console.WriteLine("[sys] Shutting down..");
        IsRunning = false;
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
        Console.Beep(200, 100);
        Console.WriteLine(@"|                         _____   ____       |");
        Thread.Sleep(500);
        Console.WriteLine(@"| /'\_/`\  __          __/\  __`\/\  _`\     |");
        Thread.Sleep(500);
        Console.Beep(200, 100);
        Console.WriteLine(@"|/\      \/\_\    ___ /\_\ \ \/\ \ \,\L\_\   |");
        Thread.Sleep(500);
        Console.WriteLine(@"|\ \ \__\ \/\ \ /' _ `\/\ \ \ \ \ \/_\__ \   |");
        Thread.Sleep(500);
        Console.Beep(200, 100);
        Console.WriteLine(@"| \ \ \_/\ \ \ \/\ \/\ \ \ \ \ \_\ \/\ \L\ \ |");
        Thread.Sleep(500);
        Console.WriteLine(@"|  \ \_\\ \_\ \_\ \_\ \_\ \_\ \_____\ `\____\|");
        Thread.Sleep(500);
        Console.Beep(200, 100);
        Console.WriteLine(@"|   \/_/ \/_/\/_/\/_/\/_/\/_/\/_____/\/_____/|");
        Thread.Sleep(500);
        Console.WriteLine(@"+============================================+");
        Console.Beep(200, 100);
        Console.ResetColor();
        
        Console.Beep(500, 80);
        Console.Beep(1000, 80);
        Console.Beep(600, 100);
        Console.Beep(1300, 100);
        Console.Beep(1000, 500);
        Console.Beep(800, 600);

    }
}