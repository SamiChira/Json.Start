using System.Collections.Generic;
using Xunit;


namespace Ranking.Facts
{
    public class RankingFacts
    {
        [Fact]
        public void WhenNewTeamIsAddedToRankAndRankIsEmptyShouldReturnUpdatedRanking()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team steaua = new Team("steaua", 1);

            rank.Add(steaua);

            Assert.True(rank.PositionOf(steaua) == 1);
        }

        [Fact]
        public void WhenNewTeamIsAddedToRankAndRanksAlreadyHasATeamShouldReturnUpdatedRanking()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team steaua = new Team("steaua", 1);
            Team cfr = new Team("cfr", 1);

            rank.Add(steaua);
            rank.Add(cfr);

            Assert.True(rank.PositionOf(steaua) == 1);
            Assert.True(rank.PositionOf(cfr) == 2);
        }

        [Fact]
        public void WhenRankingHasNoTeamsAndTeamStatsByNameIsCalledReturnsZero()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team cfr = new Team("cfr", 1);

            Assert.Equal(0, rank.PositionOf(cfr));
        }

        [Fact]
        public void WhenRankingHasTeamsAndPositionOfIsCalledReturnsTeamPosition()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team cfr = new("cfr", 1);

            rank.Add(cfr);

            Assert.Equal(1, rank.PositionOf(cfr));
        }

        [Fact]
        public void WhenRankingHasTeamsAndTeamAtIndexIsCalledReturnsTeamAtIndex()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team cfr = new Team("cfr", 1);
            Team steaua = new Team("steaua", 2);

            rank.Add(cfr);
            rank.Add(steaua);

            Assert.Equal(steaua, rank.AtIndex(1));
        }

        [Fact]
        public void WhenRankingHasNoTeamsAndAtIndexIsCalledReturnsNull()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);

            Assert.Null(rank.AtIndex(1));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndTeamsHaveSamePointsWinnerShouldBeOnAHigherRankPosition()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team cfr = new("cfr", 0);
            Team steaua = new("steaua", 0);

            rank.Add(cfr);
            rank.Add(steaua);
            rank.Update(steaua, 1, cfr, 0);

            Assert.Equal(1, rank.PositionOf(steaua));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndWinnerTeamHaveFewerPointsWinnerShouldBeAddedThreePoints()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team cfr = new("cfr", 2);
            Team steaua = new("steaua", 0);

            rank.Add(cfr);
            rank.Add(steaua);
            rank.Update(steaua, 1, cfr, 0);

            Assert.Equal(1, rank.PositionOf(steaua));
            Assert.Equal(2, rank.PositionOf(cfr));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndWinnerTeamHaveMorePointsWinnerShouldBeAddeThreePoints()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team cfr = new("cfr", 0);
            Team steaua = new("steaua", 0);

            rank.Add(cfr);
            rank.Add(steaua);
            rank.Update(steaua, 0, cfr, 1);

            Assert.Equal(2, rank.PositionOf(steaua));
            Assert.Equal(1, rank.PositionOf(cfr));
        }

        [Fact]
        public void WhenANewMatchTakesPlaceAndRankingHasMoreThanTwoTeamsWinnerTeamShouldBeAddeThreePointsAndRankingShoulBeOrdered()
        {
            Team[] teams = new Team[] { };
            Ranking rank = new Ranking(teams);
            Team cfr = new("cfr", 0);
            Team steaua = new("steaua", 2);
            Team farul = new("farul", 1);
            Team u = new("u", 4);

            rank.Add(cfr);
            rank.Add(steaua);
            rank.Add(farul);
            rank.Add(u);
            rank.Update(steaua, 0, cfr, 1);

            Assert.Equal(1, rank.PositionOf(u));
            Assert.Equal(2, rank.PositionOf(cfr));
            Assert.Equal(4, rank.PositionOf(farul));
        }
    }
}