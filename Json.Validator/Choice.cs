using System;

namespace Json
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public void Add(IPattern value)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length - 1] = value;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(text, false);

            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (match.Succes())
                {
                    return match;
                }
            }

            return new Match(text, false);
        }
    }
}
