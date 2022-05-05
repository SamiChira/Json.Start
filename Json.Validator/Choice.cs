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

            bool[] match = new bool[patterns.Length];
            for (int i = 0; i < patterns.Length; i++)
            {
                foreach (var item in text)
                {
                    match[i] = patterns[i].Match(item.ToString()) || match[i];
                }
            }

            return match[0] || match[1];
        }
    }
}
