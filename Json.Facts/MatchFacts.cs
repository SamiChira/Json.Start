using Xunit;

namespace Json.Facts
{
    public class MatchFacts
    {
        [Fact]
        public void WhenMatchSuccesHasValueShouldReturnGivenValue()
        {
            var match = new Match("abc", true);

            Assert.True(match.Succes());
        }
    }
}
