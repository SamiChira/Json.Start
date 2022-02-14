using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return Quoted(input);
        }

        static bool Quoted(string input)
        {
            return input.StartsWith('"') && input.EndsWith('"');
        }
    }
}
