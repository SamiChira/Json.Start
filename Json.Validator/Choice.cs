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

            byte counter = 0;

            for (int i = 0; i < patterns.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (patterns[i].Match(text[j].ToString()))
                    {
                        counter++;
                    }
                }
            }

            return counter == text.Length;
        }
    }
}
