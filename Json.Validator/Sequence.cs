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
            IMatch remainingMatch = new Match(text, false);

            foreach (var pattern in patterns)
            {
                remainingMatch = pattern.Match(remainingMatch.RemainingText());

                if (!remainingMatch.Succes())
                {
                    return new Match(text, false);
                }
            }

            return remainingMatch;
        }
    }
}
