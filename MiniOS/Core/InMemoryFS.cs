using System.IO;

namespace MiniOS.Core;

public class InMemoryFS
{
    //FS - File System
    //Data save space, saves files/folders, makes methods for handeling with them and helps shell with manipulation
    //1. Saving Data -> string filename, string contents
    //2. Reading Data -> returns contents of file, if the file doesnt exist it gives error
    //3. Writing Data -> writes data to file
    //4. Deleting Data -> self explemenatory
    //5. List of files -> writes smth like ls
    //6. Control of Existence 
    //Dictionary ma    KEY     VALUE.. takze treba  toho filename to je ze je filename a ten ma value jako text
    public Dictionary<string, string> _files = new Dictionary<string, string>();
    
    private static string memoryDir = "Memory";
    private static string memoryPath = Path.Combine(AppContext.BaseDirectory, memoryDir);
    
    
    //.--------------------------------------. 
    //WRITE_FILE
    //.--------------------------------------.
    public void WriteFile(string filename, string contents) //zapise do souboru
    {
        if (_files.ContainsKey(filename) ) //pokud _files obsahuji ten filename
        {
            _files[filename] = contents;
        }
        else
        {
            CreateFile(filename, contents);
        }

        
    }
    
    //.--------------------------------------.
    //READ_FILE
    //.--------------------------------------.
    public string ReadFile(string filename) //nacte soubor a vycte ho
    {

        if (!Exist(filename))
        {
            Console.WriteLine($"File {filename} does not exist");
            return null;
        }
        return _files[filename];

        /*return _files.TryGetValue(filename, out var contents)
            ? contents
            : "[FS] File not found";*/
    }
    
    //.--------------------------------------.               
    //CREATE_FILE 
    //.--------------------------------------.
    public void CreateFile(string filename, string contents) //vytvori soubor
    {
        if (Exist(filename))
        {
            Console.WriteLine("Already exists");
        }
        else
        {
            _files.Add(filename, contents);
            _files[$"Memory/{filename}"] = contents;
            
            string filePath = Path.Combine(memoryPath, filename);
            File.WriteAllText(filePath, contents);
            Console.WriteLine($"Created file: {filename}");
            
        }
        
    }
    
    //.--------------------------------------.
    //DELETE_FILE                          
    //.--------------------------------------.
    public void DeleteFile(string filename) //odstrani ho DUH
    {
        if (_files.Remove(filename))
        {
            Console.WriteLine($"Deleted file: {filename}");
        }
        else
        {
            Console.WriteLine($"Failed to delete file: {filename}");
        }
    }
    
    //.--------------------------------------.
    //LIST_FILES
    //.--------------------------------------.
    public void ListFiles() //Napise to files
    {
        Console.WriteLine("Listing files...");
        foreach (var f in _files.Keys)
        {
            Console.WriteLine($" {f}");
        }
    }
    
    //.--------------------------------------.
    //EXIST_FILE
    //.--------------------------------------.
    public bool Exist(string filename) //overi jestli existuje
    {

        return _files.ContainsKey(filename);


    }
    
    //.--------------------------------------.
    //BOOT_FSLOADER
    //.--------------------------------------.
    public bool FSLOAD()
    {
        Directory.CreateDirectory(memoryPath);
        
        
        string testPath = Path.Combine(memoryPath, "Run.txt");
        _files.Add("Run.txt", "Run");
        File.WriteAllText(testPath, string.Empty);
        
        
        if (_files.ContainsKey("Run.txt") && File.Exists(testPath))
        {
            File.Delete(testPath);
            _files.Remove("Run.txt");
            return true;
        }
        else
            return false;
        
        

    }

}