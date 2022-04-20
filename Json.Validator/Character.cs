using System;

namespace Json
{
    public class Character
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return text[0] == pattern;
        }

        public bool Match(char start, char end) => start <= pattern && pattern <= end;

        public bool MatchUnicode(string text)
        {
            const int unicodeValidLength = 6;
            const int unicodeHexValidLength = 4;

            if (string.IsNullOrEmpty(text) || text.Length < unicodeValidLength)
            {
                return false;
            }

            if (text[0] != '\\' || text[1] != 'u')
            {
                return false;
            }

            for (int i = 0; i < unicodeHexValidLength; i++)
            {
                Character character = new Character(text[i]);
                if (text[text.IndexOf('u') ..].Length < unicodeHexValidLength
                    && !character.Match('a', 'f')
                    && !character.Match('A', 'F')
                    && !character.Match('0', '9'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
