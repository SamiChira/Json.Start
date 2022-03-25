using System;

namespace SoccerRanking
{
    public class Team
    {
        private readonly string name;
        private int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string TeamStats()
        {
            return name + " : " + points.ToString();
        }

        public void TeamStatsUpdate(int awardedPoints)
        {
            points += awardedPoints;
        }

        public bool EqualsTeamName(string teamName)
        {
            return name.Equals(teamName);
        }
    }
}
