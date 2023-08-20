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
                    string capsLetters = "ABCDEFGHIGKLMNOPQRSTYVWXYZ";
                    string smallLetters = "abcdefghigklmnopqrstyvwxyz";
                    string numbers = "12356789";
                    string symbols = "~!@#$%^&*";
                    StringBuilder buffer = new StringBuilder();

                    Console.Write("Enter password length: ");
                    var passLength = int.Parse(Console.ReadLine());


                    Console.Write("[1] Include capital letters? (y/n): ");
                    var capsAnswer = Console.ReadLine();
                    if (capsAnswer == "y")
                        buffer.Append(capsLetters);

                    Console.Write("[2] Include small letters? (y/n): ");
                    var smallAnswer = Console.ReadLine();
                    if (smallAnswer == "y")
                        buffer.Append(smallLetters);

                    Console.Write("[3] Include numbers? (y/n): ");
                    var numbAnswer = Console.ReadLine();
                    if (numbAnswer == "y")
                        buffer.Append(numbers);

                    Console.Write("[4] Include symbols? (y/n): ");
                    var symbAnswer = Console.ReadLine();
                    if (symbAnswer == "y")
                        buffer.Append(symbols);

                    

                    GenerateRandomString(passLength,buffer);
                }

                Console.WriteLine("___________________________________________________________________ \n");
            }
        }
        public static void GenerateRandomNumber(int mini, int max)
        {
            Console.WriteLine($"Random Number: {new Random().Next(mini, max)}");
        }

        
        private static void GenerateRandomString(int passlenth, StringBuilder buffer)
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