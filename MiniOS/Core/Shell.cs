namespace MiniOS.Core;

public class Shell
{
    //Comunicating Area with user
    //Parsing of commands -> seperates line of command from parametr
    //Search of commands -> self explenetory
    //Start of process -> start
    //Look on output 
    //Dict      KEY     VALUE   mame treba help coz bude key.. nebo cd key a value bude kam chceme jit
    private static InMemoryFS fsys = new InMemoryFS();
    private static string filename {get; set; }
    private static string contents { get; set; }
    
    static Dictionary<string, Action> commands = new Dictionary<string, Action>();

    //-----------------------------------------------------------------------------------------------------------------
    //FILE MANAGEMENT -> cp, mv, rm, mkdir | cp - copy dir | mv - move | rm - remove | mkdir - make dir|
    
    //NAVIGATION -> cd, pwd, ls | cd - change dir | pwd - prints ur full adress where u are ig | ls - list |
    
    //TEXT PROCESSING -> cat, grep, sort, head | cat - shows contents | grep - search | sort - sorts ig | head - size |
    //-----------------------------------------------------------------------------------------------------------------
    static Shell()
    {
        commands["create"] = () =>
        {
            fsys.CreateFile(filename, contents);
        };
        commands["write"] = () =>
        {
            fsys.WriteFile(filename, contents);
        };
        commands["read"] = () =>
        {
            fsys.ReadFile(filename);
        };
        commands["delete"] = () =>
        {
            fsys.DeleteFile(filename);
        };
        commands["list"] = () => //writes dictionary list
        {
            fsys.ListFiles();
        };
        commands["exist"] = () =>
        {
            fsys.Exist(filename);
        };
        commands["exit"] = () =>
        {
            fsys.SaveToDisk();
            Environment.Exit(0);
        };

    }

    
    
    public void Run()
    {
        string command;
        string _command; // <-key
        Console.WriteLine("Welcome to MiniOS! SHELL: ");
        Console.ReadKey();
        while (true)
        {
            Console.Write("> ");
            command = Console.ReadLine();
            string[] args = command.Split(' ', 3,  StringSplitOptions.RemoveEmptyEntries);
            
            //Command Structure
            _command = args[0];
            filename = args.Length > 1 ? args[1] : null;
            contents = args.Length > 2 ? args[2]  : null;
            

            if (commands.ContainsKey(_command)) // if commands contain input
            {
                commands[_command].Invoke(); //make the stuff that its same to
            }

            /*switch (args[0])
            {
                case "create":
                    
                    break;
            }*/


        }
    }
    
}