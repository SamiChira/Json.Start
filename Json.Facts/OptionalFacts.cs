using Xunit;

namespace Json.Facts
{
    public class OptionalFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyReturnsTrue()
        {
            var optional = new Optional(new Character('a'));

            Assert.True(optional.Match("").Succes() && optional.Match("").RemainingText() == "");
            Assert.True(optional.Match(null).Succes() && optional.Match(null).RemainingText() == null);
        }

        [Fact]
        public void WhenMatchIsCalledAndGivenMatchesEnteredTextReturnsTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));
            var sign = new Optional(new Character('-'));

            Assert.True(a.Match("abc").Succes() && a.Match("abc").RemainingText() == "bc");
            Assert.True(a.Match("aabc").Succes() && a.Match("aabc").RemainingText() == "abc");
            Assert.True(sign.Match("-123").Succes() && sign.Match("-123").RemainingText() == "123");
        }

        [Fact]
        public void WhenMatchIsCalledAndGivenPatternsDoesNotMatchTextReturnsTrueAndTextEntered()
        {
            var a = new Optional(new Character('a'));
            var sign = new Optional(new Character('-'));

            Assert.True(a.Match("bc").Succes() && a.Match("bc").RemainingText() == "bc");
            Assert.True(sign.Match("123").Succes() && sign.Match("123").RemainingText() == "123");
        }
    }
}
