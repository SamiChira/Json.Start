using Xunit;

namespace Json.Facts
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyReturnsNull()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.False(a.Match(null).Succes());
            Assert.False(a.Match("").Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndPatternMatchesGivenTextReturnsTrueAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.True(a.Match("123").Succes() && a.Match("123").RemainingText().Equals(""));
            Assert.True(a.Match("1a").Succes() && a.Match("1a").RemainingText().Equals("a"));
        }

        [Fact]
        public void WhenmatchIsCalledAndGivenPatternDoesNotMatchTextEnteredReturnsFalseAndTextEntered()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.False(a.Match("bc").Succes() && a.Match("bc").RemainingText().Equals("bc"));
        }
    }
}
