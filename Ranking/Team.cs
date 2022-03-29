
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

        public void Win()
        {
            const int pointsForWin = 3;
            points += pointsForWin;
        }

        public void Draw()
        {
            points += 1;
        }

        public bool HasMorePoints(Team TeamToCheck)
        {
            return points > TeamToCheck.points;
        }
    }
}