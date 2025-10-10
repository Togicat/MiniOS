namespace MiniOS.Core;

public class Shell
{
    //Comunicating Area with user
    //Parsing of commands -> seperates line of command from parametr
    //Search of commands -> self explenetory
    //Start of process -> start
    //Look on output 
    //Dict      KEY     VALUE   mame treba help coz bude key.. nebo cd key a value bude kam chceme jit
    Dictionary<string, string> commands = new Dictionary<string, string>();
     
    public void Run()
    {
        string command; //<- key 

        
        
        Console.WriteLine("Welcome to MiniOS! SHELL: ");
        Console.ReadKey();
        while (true)
        {
            Console.Write("> ");
            command = Console.ReadLine();
            string[] args = command.Split(' ');
            
            //Chci udelat ze kdyz to detekuje nejaky ten command tak to neco udela
            switch (args[0])
            {
                case  "help":
                    Console.WriteLine("KYS");
                    break;
                case "carter":
                    break;
                
            }
            

           

            
        }
    }

    //FILE MANAGEMENT -> cd, mv, rm, mkdir
    public void FileManagement()
    {
        
    }


    //NAVIGATION -> cd, pwd, ls
    
    
    
    //TEXT PROCESSING -> cat, grep, sort, head
    
    
}