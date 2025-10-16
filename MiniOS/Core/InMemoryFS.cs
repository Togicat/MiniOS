using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = System.Text.Json.JsonSerializer;


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
    private readonly string memoryDir = "Memory";
    private readonly string memoryPath;
    private readonly string jsonPath;

    public InMemoryFS()
    {
        
        memoryPath = Path.Combine(AppContext.BaseDirectory, memoryDir);
        jsonPath = Path.Combine(memoryPath, "filesystem.json");

        Directory.CreateDirectory(memoryPath);
        LoadFromDisk();
    }
    
    //.--------------------------------------. 
    //WRITE_FILE
    //.--------------------------------------.
    public void WriteFile(string filename, string contents) //zapise do souboru
    {
        if (_files.ContainsKey(filename)) //pokud _files obsahuji ten filename
        {
            _files[filename] = contents;
            string filePath = Path.Combine(memoryPath, filename);
            File.WriteAllText(filePath, contents);
            Console.WriteLine("Updated");
        }
        else
        {
            CreateFile(filename, contents);
            Console.WriteLine("Created File");
        }
        SaveToDisk();
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
            return;
        }
        
        //_files.Add(filename, contents);
        //_files[$"Memory/{filename}"] = contents;
        
        _files[filename] = contents;
        string filePath = Path.Combine(memoryPath, filename);
        File.WriteAllText(filePath, contents);
        Console.WriteLine($"Created file: {filename}");
        SaveToDisk();
            
    }

    //.--------------------------------------.
    //DELETE_FILE                          
    //.--------------------------------------.
    public void DeleteFile(string filename) //odstrani ho DUH
    {
        //overit pokud existuje
        string testPath = Path.Combine(memoryPath, filename);

        if (File.Exists(testPath) && _files.ContainsKey(filename))
        {
            File.Delete(testPath);
            _files.Remove(filename);
            Console.WriteLine($"Deleted file: {filename}");
            SaveToDisk();
        }
        else
        {
            Console.WriteLine($"File {filename} does not exist");
        }

        /*if (_files.Remove(filename))
        {
            Console.WriteLine($"Deleted file: {filename}");
        }
        else
        {
            Console.WriteLine($"Failed to delete file: {filename}");
        }*/
    }

    //.--------------------------------------.
    //LIST_FILES
    //.--------------------------------------.
    public void ListFiles() //Napise to files
    {
        if (_files.Count == 0)
        {
            Console.WriteLine("Directory is empty");
            return;
        }
        
        Console.WriteLine("Files: ");
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
            LoadFromDisk();
            File.Delete(testPath);
            _files.Remove("Run.txt");
            return true;
        }
        else
            return false;
    }

    //.--------------------------------------.
    //SAVE _files TO DISK
    //.--------------------------------------.

    public void SaveToDisk()
    {
        string json = JsonConvert.SerializeObject(_files, Formatting.Indented);
        File.WriteAllText(jsonPath, json);
        
    }

    public void LoadFromDisk()
    {
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            _files = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? new();
            Console.Beep(1000, 10);
            //Console.WriteLine($"Loaded {_files.Count} files");
        }
        else
        {
            Console.WriteLine("Files not found");
            Console.Beep(200, 10);
            _files = new ();
            SaveToDisk();
        }
    }
}