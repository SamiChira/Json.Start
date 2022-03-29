using Xunit;

namespace Ranking.Facts
{
    public class TeamFacts
    {
        [Fact]
        public void WhenWinIsCalledShouldAddThreePointsToTeamPoints()
        {
            Team cfr = new Team("cfr", 0);
            Team steaua = new Team("steaua", 0);

            cfr.Win();

            Assert.True(cfr.hasMorePoints(steaua));
        }

        [Fact]
        public void WhenDrawIsCalledAndTeamThatCallsDrawMethodHasOnePointLessThanOtherTeamShouldAddOnePointToTeamPoints()
        {
            Team cfr = new Team("cfr", 0);
            Team steaua = new Team("steaua", 1);

            cfr.Draw();

            Assert.False(cfr.hasMorePoints(steaua));
        }

        [Fact]
        public void WhenDrawIsCalledAndTeamsHaveSamePointsShouldAddOnePointToTeamWhoCallsMethod()
        {
            Team cfr = new Team("cfr", 1);
            Team steaua = new Team("steaua", 1);

            cfr.Draw();

            Assert.True(cfr.hasMorePoints(steaua));
        }



        [Fact]
        public void WhenHasMorePointsIsCalledShouldReturnFalseIfTeamEnteredHasLessOrTheSamePointsAsTheTeamToCompareWith()
        {
            Team steaua = new Team("steaua", 0);
            Team cfr = new Team("cfr", 0);

            Assert.False(steaua.hasMorePoints(cfr));
        }

        [Fact]
        public void WhenHasMorePointsIsCalledAndTeamEnteredHasMorePointsThanTheTeamToCompareWithShouldReturnTrue()
        {
            Team steaua = new Team("steaua", 1);
            Team cfr = new Team("cfr", 0);

            Assert.True(steaua.hasMorePoints(cfr));
        }
    }
}