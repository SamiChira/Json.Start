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
            BubbleSort(teams);
        }

        public string TeamStatsByName(string teamName)
        {
            if (teams.Length == 0)
            {
                return null;
            }

            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].EqualsTeamName(teamName))
                {
                    return string.Format("Team {0} points and is on the {1} place.", teams[i].TeamStats(), (i + 1));
                }
            }

            return "";
        }

        public string TeamStatsByIndex(int teamIndex)
        {
            if (teams.Length == 0)
            {
                return null;
            }

            return string.Format("Team {0} points and is on the {1} place.", teams[teamIndex - 1].TeamStats(), teamIndex);
        }

        private void TeamStatsUpdateByName(string teamName, int awardedPoints)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].EqualsTeamName(teamName))
                {
                    teams[i].TeamStatsUpdate(awardedPoints);
                }
            }
        }

        public void Match(string firstTeamName, int firstTeamFinalScore, string secondTeamName, int secondTeamFinalScore)
        {
            const int pointsForWin = 3;
            if (firstTeamFinalScore == secondTeamFinalScore)
            {
                TeamStatsUpdateByName(firstTeamName, 1);
                TeamStatsUpdateByName(secondTeamName, 1);
            }
            else if (firstTeamFinalScore > secondTeamFinalScore)
            {
                TeamStatsUpdateByName(firstTeamName, pointsForWin);
            }
            else
            {
                TeamStatsUpdateByName(secondTeamName, pointsForWin);
            }

            BubbleSort(teams);
        }

        private void BubbleSort(Team[] teams)
        {
            int unnorderedRanking;
            do
            {
                unnorderedRanking = 0;
                for (int i = 1; i < teams.Length; i++)
                {
                    if (Convert.ToInt32(teams[i].TeamStats()[teams[i].TeamStats().LastIndexOf(' ')..]) > Convert.ToInt32(teams[i - 1].TeamStats()[teams[i - 1].TeamStats().LastIndexOf(' ')..]))
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

