namespace Json
{
    public class Value : IPattern
    {
        readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(
                         new String(),
                         new Number(),
                         new Txt("true"),
                         new Txt("false"),
                         new Txt("null"));

            var whiteSpace = new Many(new Any(" \n\r\t"));

            var element = new Sequence(whiteSpace, value, whiteSpace);
            var elements = new Sequence(whiteSpace, new List(element, new Character(',')), whiteSpace);

            var array = new Sequence(new Character('['), elements, new Character(']'));

            var member = new Sequence(whiteSpace, new String(), whiteSpace, new Character(':'), element);
            var members = new Sequence(whiteSpace, new List(member, new Character(',')), whiteSpace);

            var obj = new Sequence(new Character('{'), members, new Character('}'));

            value.Add(array);
            value.Add(obj);

            this.pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
