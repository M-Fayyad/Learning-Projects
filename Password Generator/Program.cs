using System.Text;

namespace Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please select option: ");
                Console.WriteLine("[1] Generate random number [2] Generate random string");
                string selectedOption = Console.ReadLine();
                if (selectedOption == "1")
                {
                    Console.Write("Enter minimum value: ");
                    int minimumValue = int.Parse(Console.ReadLine());

                    Console.Write("Enter maximum value: ");
                    int maximumValue = int.Parse(Console.ReadLine());
                    GenerateRandomNumber(minimumValue, maximumValue);
                }
                else if (selectedOption == "2")
                {
                    Console.Write("Enter password length: ");
                    var passLength = int.Parse(Console.ReadLine());
                    GenerateRandomString(passLength);
                }

                Console.WriteLine("___________________________________________________________________ \n");
            }
        }
        public static void GenerateRandomNumber(int mini, int max)
        {
            Console.WriteLine($"Random Number: {new Random().Next(mini, max)}");
        }

        private const string buffer = "ABCDEFGHIGKLMNOPQRSTYVWXYZabcdefghigklmnopqrstyvwxyz12356789~!@#$%^&*";
        private static void GenerateRandomString(int passlenth)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < passlenth; i++)
            {
                sb.Append(buffer[new Random().Next(0, buffer.Length - 1)]);
            }
            Console.WriteLine($"\nRandom Password: {sb}");
        }

    }
}