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
            if (string.IsNullOrEmpty(text))
            {
                return new Match(text, false);
            }

            var remainingText = text;

            foreach (var pattern in patterns)
            {
                if (!pattern.Match(remainingText).Succes())
                {
                    return new Match(text, false);
                }

                remainingText = pattern.Match(remainingText).RemainingText();
            }

            return new Match(remainingText, true);
        }
    }
}
