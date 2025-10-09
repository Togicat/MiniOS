using MiniOS.Core;
namespace MiniOS;

public class Program
{

    public static void Main()
    {
        //INITIALIZE OF COMPONENTS
        Kernel kernel = new Kernel();
        Shell shell = new Shell();
        
        //BOOT
        kernel.Boot();
        
        
    }
}