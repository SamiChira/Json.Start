using System;

namespace Json
{
    public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(text, true);
            if (string.IsNullOrEmpty(text))
            {
                return match;
            }

            while (pattern.Match(match.RemainingText()).Succes())
            {
                match = pattern.Match(match.RemainingText());
            }

            return match;
        }
    }
}
