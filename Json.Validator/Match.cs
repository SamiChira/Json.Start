namespace Json
{
    public class Match : IMatch
    {
        readonly string remainingText;
        readonly bool succes;

        public Match(string remainingText, bool succes)
        {
            this.remainingText = remainingText;
            this.succes = succes;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public bool Succes()
        {
            return succes;
        }
    }
}
