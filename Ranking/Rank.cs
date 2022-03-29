﻿using System;
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
            BubbleSort(teams);
        }

        public int PositionOf(Team team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;

                }
            }

            return 0;
        }

        public Team AtIndex(int teamIndex)
        {
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
                    if (teams[i].hasMorePoints(teams[i - 1]))
                    {
                        Swap(teams[i - 1], teams[i]);
                        unnorderedRanking++;
                    }
                }
            }
            while (unnorderedRanking != 0);
        }

        public void Swap(Team firstTeam, Team secondTeam)
        {
            Team temp = firstTeam;
            firstTeam = secondTeam;
            secondTeam = temp;
        }
    }
}