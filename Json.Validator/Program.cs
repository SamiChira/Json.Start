using System;

namespace Json
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && System.IO.File.Exists(args[0]))
            {
                var value = new Value();
                var text = System.IO.File.ReadAllText(args[0]);
                Console.WriteLine(string.IsNullOrEmpty(value.Match(text).RemainingText()) ? "Valid JSON format!" : "Invalid JSON format!");
            }
            else
            {
                Console.WriteLine("Please enter a valid path or check that a path is entered and refers to a valid text file! \nE.g: C:\\fileName.txt");
            }
        }
    }
}