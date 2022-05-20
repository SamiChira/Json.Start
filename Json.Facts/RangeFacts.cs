using Xunit;

namespace Json.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsNullShouldReturnFalse()
        {
            var range = new Range('a', 'z');

            Assert.False(range.Match(null).Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredIsInGivenRangeShouldReturnTrue()
        {
            var range = new Range('a', 'f');

            Assert.True(range.Match("abc").Succes());
            Assert.True(range.Match("fab").Succes());
            Assert.True(range.Match("bcd").Succes());
        }

        [Fact]
        public void WhenMatchIsCalledAndTextEnteredContainsCharacterOutsideGivenLimitsReturnsFalse()
        {
            var range = new Range('a', 'f');

            Assert.False(range.Match("1ab").Succes());
            Assert.False(range.Match("gba").Succes());
        }
    }
}
