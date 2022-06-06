using Xunit;
namespace Json.Facts
{
    public class ListFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyReturnsTrue()
        {
            var list = new List(new Range('0', '9'), new Character(','));

            Assert.True(list.Match("").Succes() && list.Match("").RemainingText() == "");
            Assert.True(list.Match(null).Succes() && list.Match(null).RemainingText() == null);
        }

        [Fact]
        public void WhenMatchIsCalledAndPatternsEnteredDoesNotMatchTextEnteredReturnsTrueAndTextEntered()
        {
            var list = new List(new Range('0', '9'), new Character(','));

            Assert.True(list.Match("abc").Succes() && list.Match("abc").RemainingText() == "abc");
        }

        [Fact]
        public void WhenMatchIsCalledAndPatternsEnteredMatchGivenTextReturnsTrueAndRemainigText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);


            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Succes() && list.Match("").RemainingText() == "");
            Assert.True(list.Match("1 \n;").Succes() && list.Match("1 \n;").RemainingText() == " \n;");
        }
    }
}
