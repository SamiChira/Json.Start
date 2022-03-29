
using System;

namespace Ranking
{
    public class Team
    {
        private string name;
        private int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }


        public bool EqualsTeamName(string teamName)
        {
            return name.Equals(teamName);
        }
    }
}