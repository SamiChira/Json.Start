using Xunit;

namespace Json.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullShouldReturnFalse()
        {
            var range = new Range('a', 'z');

            Assert.False(range.Match(null));
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsInGivenRangeShouldReturnTrue()
        {
            var range = new Range('a', 'f');

            Assert.True(range.Match("abc"));
            Assert.True(range.Match("fab"));
            Assert.True(range.Match("bcd"));
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsCharacterOutsideGivenLimitsReturnsFalse()
        {
            var range = new Range('a', 'f');

            Assert.False(range.Match("1ab"));
            Assert.False(range.Match("gba"));
        }
    }
}
