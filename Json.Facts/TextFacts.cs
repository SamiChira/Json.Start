using Xunit;

namespace Json.Facts
{
    public class TextFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullOrEmptyReturnsFalse()
        {
            var text = new Text("test");

            Assert.False(text.Match("").Succes());
            Assert.False(text.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredMatchesTheGivenPrefixReturnsTrueAndRemainingText()
        {
            var @true = new Text("true");
            var @false = new Text("false");

            Assert.True(@true.Match("true").Succes() && @true.Match("true").RemainingText() == "");
            Assert.True(@true.Match("trueX").Succes() && @true.Match("trueX").RemainingText() == "X");
            Assert.True(@false.Match("false").Succes() && @false.Match("false").RemainingText() == "");
            Assert.True(@false.Match("falseX").Succes() && @false.Match("falseX").RemainingText() == "X");
        }
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredDoesNotMatchTheGivenPrefixReturnsFalseAndTextEntered()
        {
            var @true = new Text("true");
            var @false = new Text("false");

            Assert.False(@true.Match("false").Succes() && @true.Match("false").RemainingText() == "false");
            Assert.False(@false.Match("true").Succes() && @false.Match("true").RemainingText() == "true");
        }
        [Fact]
        public void WhenMatchIsCalledAndPrefixIsAnEmptyStringReturnsMatchAndRemainingText()
        {
            var empty = new Text("");

            Assert.True(empty.Match("true").Succes() && empty.Match("true").RemainingText() == "true");
            Assert.False(empty.Match(null).Succes() && empty.Match(null).RemainingText() == "");
        }
    }
}
