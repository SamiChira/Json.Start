using System;

namespace Json
{
    public class Range : IPattern
    {
        readonly char start;
        readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && start <= text[0] && text[0] <= end ?
                    new Match(text[1 ..], true) :
                    new Match(text, false);
        }
    }
}
