namespace Json
{
    public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(text, true);

            while (match.Succes())
            {
                match = pattern.Match(match.RemainingText());
            }

            return new Match(match.RemainingText(), true);
        }
    }
}
