using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Program
    {
        public class BackgroundOperation
        {
            public async Task WriteToFileAsync(string message)
            {
                Console.WriteLine("Writing to file in background...");
                await Task.Delay(3000);
                await File.WriteAllTextAsync("tmp.txt", message);
            }
        }
        static void Main(string[] args)
        {
            string input = GetInputFromMenu(); // Get user input
            string message = GetMessageToWrite(input); // Pass input and get respective message string
           
            BackgroundOperation bgOps = new BackgroundOperation();
            bgOps.WriteToFileAsync(message); // Pass message to be written on file

            Console.WriteLine("Enter something till file writes"); // To showcase non blocking UI, user can still access console
            string? userInput = Console.ReadLine();
            Console.WriteLine($"You entered: {userInput}");

        }

        // Method shows a 3 option menu where user can give input
        public static string GetInputFromMenu()
        {
            string? input;
            do
            {
                Console.WriteLine("1. Write \"Hello World\"");
                Console.WriteLine("2. Write Current Date");
                Console.WriteLine("3. Write OS Version");
                input = Console.ReadLine();
            } while (input != "1" && input != "2" && input != "3");
            return input;
        }

        // Method returns string message to be written in file based on user input
        public static string GetMessageToWrite(string input)
        {
            string message = "";
            if (input == "1")
            {
                message = "Hello World";
            }
            else if (input == "2")
            {
                message = DateTime.Now.ToString("d"); // Current date
            }
            else if (input == "3")
            {
                message = Environment.OSVersion.VersionString; // Get OS version
            }
            return message;
        }
    }
}
