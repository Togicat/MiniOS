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

    static Shell()
    {
        commands["create"] = () =>
        {
            Console.WriteLine("Creating file");
            
            fsys.CreateFile(filename, contents);
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
            string[] args = command.Split(' ');
            //Command Structure
            _command = args[0];
            filename = args[1];
            contents = args[2];
            

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

    //FILE MANAGEMENT -> cp, mv, rm, mkdir | cp - copy dir | mv - move | rm - remove | mkdir - make dir|
    public void FileManagement()
    {
        
    }


    //NAVIGATION -> cd, pwd, ls | cd - change dir | pwd - prints ur full adress where u are ig | ls - list |
    public void Navigation()
    {
        
    }


    //TEXT PROCESSING -> cat, grep, sort, head | cat - shows contents | grep - search | sort - sorts ig | head - size |
    public void TextProcessing()
    {
        
    }

}