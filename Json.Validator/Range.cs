using System;

namespace Json
{
    public class Range
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach (var item in text)
            {
                if (item < start || item > end)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
