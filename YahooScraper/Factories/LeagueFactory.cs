﻿using FantasyRepo.SQL;
using System;
using System.Text.RegularExpressions;
using YahooFantasyService;

namespace YahooScraper.Factories
{
    public static class LeagueFactory
    {
        private static readonly Regex LeagueNameRegex = new Regex("^.*/(?<name>.*)$", RegexOptions.Compiled);

        public static League FromYahooDto(YahooLeague yLeague)
        {
            if (yLeague.Settings is null)
            {
                throw new ArgumentException("League initialization requires Settings to not be null.");
            }

            var persistenUrl = yLeague.Settings.PersistentUrl;
            var m = LeagueNameRegex.Match(persistenUrl);
            var leagueName = m.Groups["name"].Value;
            return new League(leagueName);
        }
    }
}