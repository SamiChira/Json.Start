using System;

namespace Json
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var value = new Value();
            var text = System.IO.File.ReadAllText(args[0]);
            Console.WriteLine(string.IsNullOrEmpty(value.Match(text).RemainingText()) ? "Valid JSON format!" : "Invalid JSON format!");
        }
    }
}