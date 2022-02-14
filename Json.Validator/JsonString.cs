using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Quoted(input) &&
                   AlwaysStartsWithQuotes(input) &&
                   AlwaysEndsWithQuotes(input);
        }

        static bool Quoted(string input)
        {
            return input.StartsWith('"') && input.EndsWith('"');
        }

        static bool AlwaysStartsWithQuotes(string input)
        {
            const int numberTwo = 2;
            int quotesCounter = 0;
            foreach (var item in input)
            {
                if (item == '"')
                {
                    quotesCounter++;
                }
            }

            return quotesCounter % numberTwo == 0 && Quoted(input);
        }

        static bool AlwaysEndsWithQuotes(string input)
        {
            return AlwaysStartsWithQuotes(input);
        }
    }
}
