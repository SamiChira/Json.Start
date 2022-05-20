using Xunit;


namespace Json.Facts
{
    public class ChoiceFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextToAnalyzeIsNullOrEmptyShouldReturnFalse()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('0', '9')
                );

            Assert.False(digit.Match(null).Succes());
            Assert.False(digit.Match("").Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAntTextEnteredMatchesGivenPatternsReturnsTrue()
        {
            Choice digit = new Choice(
                new Character('0'),
                new  Range('1' , '9'));

            Assert.True(digit.Match("012").Succes());
            Assert.True(digit.Match("12").Succes());
            Assert.True(digit.Match("92").Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredDoesNotMatchGivenPattersReturnsFalse()
        {
            Choice digit = new Choice(
                new Character('0'),
                new Range('1', '9'));

            Assert.False(digit.Match("a9").Succes());
            Assert.False(digit.Match("").Succes());
            Assert.False(digit.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchISCalledAndTextEnteredMatchesGivenPatternInlcudingChoiceReturnsTrue()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice( digit, new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')));

            Assert.True(hex.Match("012").Succes());
            Assert.True(hex.Match("12").Succes());
            Assert.True(hex.Match("92").Succes());
            Assert.True(hex.Match("a9").Succes());
            Assert.True(hex.Match("f8").Succes());
            Assert.True(hex.Match("A9").Succes());
            Assert.True(hex.Match("F8").Succes());
        }

        [Fact]
        public void WhenMatchISCalledAndTextEnteredMatchesGivenPatternInlcudingChoiceReturnsFalse()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')));

            Assert.False(hex.Match("g8").Succes());
            Assert.False(hex.Match("G8").Succes());
            Assert.False(hex.Match("").Succes());
            Assert.False(hex.Match(null).Succes());
        }
    }
}
