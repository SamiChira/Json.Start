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
            foreach (var choice in patterns)
            {
                if (choice.GetType() == typeof(Range) && choice.Match(text))
                {
                    return true;
                }
                else if (choice.GetType() == typeof(Character) && choice.Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
