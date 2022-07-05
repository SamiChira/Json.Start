using System;

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
                        new Text("true"),
                        new Text("false"),
                        new Text("null"));

            var whiteSpace = new Any(" \n\r\t");
            var element = new Sequence(whiteSpace, value, whiteSpace);
            var elements = new List(element, new Character(','));

            var array = new Choice(
                        new Sequence(new Character('['), whiteSpace, new Character(']')),
                        new Sequence(new Character('['), elements, new Character(']')));

            var member = new Sequence(whiteSpace, new String(), whiteSpace, new Character(':'), element);
            var members = new List(member, new Character(','));

            var obj = new Choice(
                      new Sequence(new Character('{'), whiteSpace, new Character('}')),
                      new Sequence(new Character('{'), members, new Character('}')));

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
