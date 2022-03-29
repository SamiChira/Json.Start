using System;
using System.Collections.Generic;

namespace Ranking
{
    public class Ranking
    {
        private Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        public void Add(Team team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = team;
        }

        public int positionOf(Team team)
        {
            bubbleSort(teams);
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;

                }
            }

            return 0;
        }

        public Team atIndex(int teamIndex)
        {
            bubbleSort(teams);
            if (teamIndex > teams.Length - 1 || teamIndex < 0)
            {
                return null;
            }

            return teams[teamIndex - 1];
        }

        public void Update(Team homeTeam, int homeTeamScore, Team awayTeam, int awayTeamScore)
        {
            if (homeTeamScore == awayTeamScore)
            {
                homeTeam.Draw();
                awayTeam.Draw();
            }
            else if (homeTeamScore > awayTeamScore)
            {
                homeTeam.Win();
            }
            else
            {
                awayTeam.Win();
            }

            bubbleSort(teams);
        }

        private void bubbleSort(Team[] teams)
        {
            int unnorderedRanking;
            do
            {
                unnorderedRanking = 0;
                for (int i = 1; i <= teams.Length - 1; i++)
                {
                    if (teams[i].hasMorePoints(teams[i - 1]))
                    {
                        Team temp = teams[i];
                        teams[i] = teams[i - 1];
                        teams[i - 1] = temp;
                        unnorderedRanking++;
                    }
                }
            }
            while (unnorderedRanking != 0);
        }
    }
}