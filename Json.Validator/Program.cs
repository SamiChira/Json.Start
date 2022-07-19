using System;

namespace Json
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0 || !System.IO.File.Exists(args[0]))
            {
                return;

                // Please enter a valid path or check that a path is entered and refers to a valid text file! \nE.g: C:\\fileName.txt
            }

            var text = System.IO.File.ReadAllText(args[0]);
            IMatch jsonValidator = new Value().Match(text);
            Console.WriteLine(jsonValidator.Succes() && string.IsNullOrEmpty(jsonValidator.RemainingText()) ? "Valid JSON format!" : "Invalid JSON format!");

            Console.ReadLine();
        }
    }
}