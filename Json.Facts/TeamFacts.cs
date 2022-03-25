using Xunit;

namespace SoccerRanking.Facts
{
    public class TeamFacts
    {
        [Fact]
        public void TeamStatsReturnCorrectValueWhenOneIsEntered()
        {
            Team steaua = new Team("steaua", 1);

            Assert.True(steaua.TeamStats() == "steaua : 1");
        }

        [Fact]
        public void WhenTeamStatsUpdateIsCalledShouldChangePointsValueIfValueIsGreaterThanZero()
        {
            Team steaua = new Team("steaua", 0);
            int awardedPoints = 3;

            steaua.TeamStatsUpdate(awardedPoints);

            Assert.True(steaua.TeamStats() == "steaua : 3");
        }

        [Fact]
        public void WhenEqualsTeamNameIsCalledShouldReturnTrueIfTeamEnteredHasTheSameNameAsTheSearchedName()
        {
            Team steaua = new Team("steaua", 0);

            Assert.True(steaua.EqualsTeamName("steaua"));
        }

        [Fact]
        public void WhenEqualsTeamNameIsCalledShouldReturnFalseIfTeamEnteredHasNotTheSameNameAsTheSearchedName()
        {
            Team steaua = new Team("steaua", 0);

            Assert.False(steaua.EqualsTeamName("cfr"));
        }
    }
}