namespace MiniOS.Core;

public class Shell
{
    //Comunicating Area with user
    //Parsing of commands -> seperates line of command from parametr
    //Search of commands -> self explenetory
    //Start of process -> start
    //Look on output 
    
    Dictionary<string, string> commands = new Dictionary<string, string>();

    public void Run(string command)
    {
        Console.WriteLine("Welcome to MiniOS! SHELL: ");
        Console.ReadKey();
        while (true)
        {
            command = Console.ReadLine();
            
            
        }
    }

    //FILE MANAGEMENT -> cd, mv, rm, mkdir
    public void FileManagement()
    {
        
    }


    //NAVIGATION -> cd, pwd, ls
    
    
    
    //TEXT PROCESSING -> cat, grep, sort, head
    
    
}