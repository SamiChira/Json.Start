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

        public void AddTeam(Team team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = team;
        }

        public int PositionOf(Team team)
        {
            BubbleSort(teams);
            int teamPosition = 0;
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    teamPosition = i + 1;
                }
            }

            return teamPosition;
        }
        public Team AtIndex(int teamIndex)
        {
            BubbleSort(teams);
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

            BubbleSort(teams);
        }

        private void BubbleSort(Team[] teams)
        {
            int unnorderedRanking;
            do
            {
                unnorderedRanking = 0;
                for (int i = 1; i <= teams.Length - 1; i++)
                {
                    if (teams[i].HasMorePoints(teams[i - 1]))
                    {
                        Swap(teams, i, i - 1);
                        unnorderedRanking++;
                    }
                }
            }
            while (unnorderedRanking != 0);
        }

        private void Swap(Team[] teams, int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);

            Team temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
        }

        private (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }
    }
}

