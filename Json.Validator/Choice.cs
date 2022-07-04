namespace Json
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text).Succes())
                {
                    return new Match(pattern.Match(text).RemainingText(), true);
                }
            }

            return new Match(text, false);
        }
    }
}
