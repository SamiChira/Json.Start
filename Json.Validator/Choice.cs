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
            bool match = false;
            foreach (var pattern in patterns)
            {
                match = pattern.Match(text) || match;
            }

            return match;
        }
    }
}
