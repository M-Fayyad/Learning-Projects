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
                    foreach (var entry in Directory.GetFileSystemEntries(path))
                    {
                        //[GetFileName] is a {static method} of the [Path] {class}. 
                        //It is used to extract the file or directory name from a given path.
                        //It takes a full path as input and returns the name of the file or directory without the rest of the path.
                        string directoryName = Path.GetFileName(entry);
                        Console.WriteLine($"\t[Dir] {directoryName}");
                    }
                    //foreach (var entry in Directory.GetFiles(path))
                    //{
                    //    string fileName = Path.GetFileName(entry);
                    //    Console.WriteLine($"\t[File] {Path.GetFileName(fileName)}");
                    //}

                }
                else if(command == "info")
                {

                }
                else if (command == "mkdir")
                {

                }
                else if (command == "remove")
                {
                    
                }
                else if (command == "read")
                {

                }
                else if (command == "exit")
                {
                    break;
                }
            }


        
        }
    }
}