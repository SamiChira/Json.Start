using Xunit;

namespace Json.Facts
{
    public class MatchFacts
    {
        [Fact]
        public void WhenMatchSuccessHasValueShouldReturnGivenValue()
        {
            var matchTrue = new Match("abc", true);
            var matchFalse = new Match("abc", false);

            Assert.True(matchTrue.Succes());
            Assert.False(matchFalse.Succes());

        }

        [Fact]
        public void WhenMatchRemainingTextIsCalledReturnGivenValue()
        {
            var match = new Match("abc", true);

            Assert.True(match.RemainingText() == "abc");
        }
    }
}
