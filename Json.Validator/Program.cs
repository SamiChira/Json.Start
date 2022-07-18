using System;

namespace Json
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var value = new Value();
            var text = System.IO.File.ReadAllText(args[0]);
            Console.WriteLine(value.Match(text).Succes() ? "Valid JSON format!" : "Invalid JSON format!");
        }
    }
}