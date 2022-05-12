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
            for (int i = 0; i < patterns.Length; i++)
            {
                if (patterns[i].Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
