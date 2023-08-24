using System.Runtime;

namespace File_System_Command_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine().Trim();

                var stringsInInput = input.Split(' ');

                //var command = input.Substring(0,input.IndexOf(' '));
                //var path = input.Substring(input.IndexOf(" ") + 1);

                var command = stringsInInput[0];
                var path = string.Join(" ", stringsInInput[1..]);

                if (command == "list")
                {
                    foreach (var entry in Directory.GetDirectories(path))
                    {
                        //[GetFileName] is a {static method} of the [Path] {class}. 
                        //It is used to extract the file or directory name from a given path.
                        //It takes a full path as input and returns the name of the file or directory without the rest of the path.
                        string directoryName = Path.GetFileName(entry);
                        Console.WriteLine($"\t[Dir] {directoryName}");
                    }
                    foreach (var entry in Directory.GetFiles(path))
                    {
                        string fileName = Path.GetFileName(entry);
                        Console.WriteLine($"\t[File] {Path.GetFileName(fileName)}");
                    }

                }
                else if (command == "info")
                {
                    if (Directory.Exists(path))
                    {
                        var dirInfo = new DirectoryInfo(path);
                        Console.WriteLine($"Type: Directory");
                        Console.WriteLine($"Name: {dirInfo.Name}");
                        Console.WriteLine($"Created At: {dirInfo.CreationTime}");
                        Console.WriteLine($"Last modified At: {dirInfo.LastWriteTime}");
                    }
                    else if (File.Exists(path))
                    {
                        var fileInfo = new FileInfo(path);
                        Console.WriteLine($"Type: {(fileInfo.Extension)[1..]} file");
                        Console.WriteLine($"Created At: {fileInfo.CreationTime}");
                        Console.WriteLine($"Last modified At: {fileInfo.LastWriteTime}");
                        Console.WriteLine($"Size in bytes: {fileInfo.Length}");

                    }
                    else
                    {
                        Console.WriteLine("directory or file not exist");
                    }
                }
                else if (command == "mkdir")
                {
                    Directory.CreateDirectory(path);
                }
                else if (command == "remove")
                {
                    if (Directory.Exists(path))
                        Directory.Delete(path);
                    else if (File.Exists(path))
                        File.Delete(path);
                }
                else if (command == "read")
                {
                    if (File.Exists(path))
                    {
                        var content = File.ReadAllText(path);
                        Console.WriteLine(content);
                    }
                }
                else if (command == "exit")
                {
                    break;
                }
            }



        }
    }
}