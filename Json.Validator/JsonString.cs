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

            return QuotesChecks(input) &&
                ContainsUnnescapedControlCharacter(input);
        }

        static bool QuotesChecks(string input)
        {
            return input.StartsWith('"') && input.EndsWith('"') &&
                   IsEmptyDoubleQuoted(input);
        }

        static bool IsEmptyDoubleQuoted(string input)
        {
            return QuotesChecks(input);
        }

        static bool ContainsUnnescapedControlCharacter(string input)
        {
            return false;
        }
    }
}
