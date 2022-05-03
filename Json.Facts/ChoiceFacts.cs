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

            Assert.False(digit.Match(null));
            Assert.False(digit.Match(""));
        }
    }
}
