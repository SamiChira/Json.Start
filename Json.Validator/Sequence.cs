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
            var remainingMatch = new Match(text, false);
            var initialMatch = new Match(text, false);

            if (string.IsNullOrEmpty(text))
            {
                return initialMatch;
            }

            foreach (var item in patterns)
            {
                remainingMatch = (Match)item.Match(remainingMatch.RemainingText());

                if (!remainingMatch.Succes())
                {
                    return initialMatch;
                }
            }

            return remainingMatch;
        }
    }
}
