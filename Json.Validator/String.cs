namespace Json
{
    public class String : IPattern
    {
        readonly IPattern pattern;

        public String()
        {
            var quotes = new Character('"');
            var backslash = new Character('\\');
            var hex = new Choice(
                    new Range('0', '9'),
                    new Range('a', 'f'),
                    new Range('A', 'F'));
            var hexSeq = new Sequence(
                    new Character('u'),
                    new Sequence(
                        hex,
                        hex,
                        hex,
                        hex));
            var escapeCharacters = new Choice(
                new Any("btrnf/\"\\"),
                hexSeq);
            var character = new Choice(
                new Character(' '),
                new Range('#', '['),
                new Range(']', '\uFFFF'),
                new Sequence(
                backslash,
                escapeCharacters));
            var characters = new Many(character);

            this.pattern = new Sequence(quotes, characters, quotes);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
