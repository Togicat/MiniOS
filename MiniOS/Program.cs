using MiniOS.Core;
namespace MiniOS;

public class Program
{

    public static void Main()
    {
        //INITIALIZE OF COMPONENTS
        Kernel kernel = new Kernel();
        Shell shell = new Shell();
        InMemoryFS fs = new InMemoryFS();
        
        //BOOT
        kernel.Boot();
        //SHELL
        shell.Run();

        string memDir = "Memory/";
        fs.DeleteFile(memDir);
        
    }
}