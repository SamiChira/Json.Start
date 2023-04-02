using System;

namespace Json
{
    public class Txt : IPattern
    {
        readonly string prefix;

        public Txt(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text.StartsWith(prefix)
                ? new Match(text[prefix.Length..], true)
                : new Match(text, false);
        }
    }
}
