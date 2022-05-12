namespace Json
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            bool patternsMatches = false;

            for (int i = 0; i < patterns.Length; i++)
            {
                if (patterns[i].Match(text))
                {
                    patternsMatches = patterns[i].Match(text) || patternsMatches;
                }
            }

            return patternsMatches;
        }
    }
}
