using System.Collections.Generic;
using Xunit;


namespace Ranking.Facts
{
    public class RankingFacts
    {
        [Fact]
        public void WhenNewTeamIsAddedToRankShouldReturnUpdatedRanking()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);

            rank.AddTeam("steaua", 1);

            Assert.True(teams.Count == 1);
        }

        [Fact]
        public void WhenRankingHasNoTeamsAndTeamStatsByNameIsCalledReturnsNull()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);

            Assert.Null(rank.TeamStatsByName("cfr"));
        }

        [Fact]
        public void WhenRankingHasTeamsAndTeamStatsByNameIsCalledReturnsTeamStats()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);

            rank.AddTeam("cfr", 1);

            Assert.Equal("Team cfr : 1 points and is on the 1 place.", rank.TeamStatsByName("cfr"));
        }

        [Fact]
        public void WhenRankingHasTeamsAndTeamStatsByIndexIsCalledReturnsTeamStats()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);

            rank.AddTeam("cfr", 1);
            rank.AddTeam("steaua", 2);

            Assert.Equal("Team steaua : 2 points and is on the 1 place.", rank.TeamStatsByIndex(1));
        }

        [Fact]
        public void WhenRankingHasNoTeamsAndTeamStatsByIndexIsCalledReturnsNull()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);

            Assert.Null(rank.TeamStatsByIndex(1));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndTeamsHaveSamePointsWinnerShouldBeOnAHigherRankPosition()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);
            rank.AddTeam("cfr", 0);
            rank.AddTeam("steaua", 0);

            rank.Match("steaua", 1, "cfr", 0);

            Assert.Equal("Team steaua : 3 points and is on the 1 place.", rank.TeamStatsByName("steaua"));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndWinnerTeamHaveFewerPointsWinnerShouldBeAddedThreePoints()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);
            rank.AddTeam("cfr", 2);
            rank.AddTeam("steaua", 0);

            rank.Match("steaua", 1, "cfr", 0);

            Assert.Equal("Team steaua : 3 points and is on the 1 place.", rank.TeamStatsByName("steaua"));
            Assert.Equal("Team cfr : 2 points and is on the 2 place.", rank.TeamStatsByName("cfr"));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndWinnerTeamHaveMorePointsWinnerShouldBeAddeThreePoints()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);
            rank.AddTeam("cfr", 0);
            rank.AddTeam("steaua", 0);

            rank.Match("steaua", 0, "cfr", 1);

            Assert.Equal("Team steaua : 0 points and is on the 2 place.", rank.TeamStatsByName("steaua"));
            Assert.Equal("Team cfr : 3 points and is on the 1 place.", rank.TeamStatsByName("cfr"));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndRankingHasMoreThanTwoTeamsWinnerTeamShouldBeAddeThreePointsAndRankingShoulBeOrdered()
        {
            List<Team> teams = new List<Team>();
            Ranking rank = new Ranking(teams);
            rank.AddTeam("cfr", 0);
            rank.AddTeam("steaua", 2);
            rank.AddTeam("farul", 1);
            rank.AddTeam("u", 4);

            rank.Match("steaua", 0, "cfr", 1);

            Assert.Equal("Team u : 4 points and is on the 1 place.", rank.TeamStatsByName("u"));
            Assert.Equal("Team cfr : 3 points and is on the 2 place.", rank.TeamStatsByName("cfr"));
            Assert.Equal("Team farul : 1 points and is on the 4 place.", rank.TeamStatsByName("farul"));
        }
    }
}