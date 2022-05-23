using System;

namespace Json
{
    public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(text, false);

            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (!match.Succes())
                {
                    return new Match(text, false);
                }
            }

            return match;
        }
    }
}
