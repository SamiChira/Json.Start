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

            string digits = GetDigits(text, '0', '9');
            string letters = GetLetters(text.ToLower(), 'a', 'z');
            byte matchesCounter = 0;

            for (int i = 0; i < patterns.Length; i++)
            {
                if (patterns[i].Match(text) || (patterns[i].Match(digits) || patterns[i].Match(letters)))
                {
                    matchesCounter++;
                }
            }

            return digits.Length > 0 && letters.Length > 0 ? matchesCounter > 1 : matchesCounter > 0;
        }

        string GetLetters(string text, char start, char end) => GetDigits(text, start, end);

        string GetDigits(string text, char start, char end)
        {
            string digits = "";

            foreach (var item in text)
            {
                if (item >= start && item <= end)
                {
                    digits += item;
                }
            }

            return digits;
        }
    }
}
