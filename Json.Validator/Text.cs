using System;

namespace Json
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
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
