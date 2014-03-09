using System;
using System.Collections.Generic;
using System.Linq;

namespace APILib.API
{
    public static class APIAdditionalRequestData
    {
        public static string Player(string id)
        {
            return "&playerid=" + id;
        }

        public static string Players(IEnumerable<string> ids)
        {
            return "&playerids=" + CommaSeparatedValues(ids);
        }

        public static string Team(string id)
        {
            return "&teamid=" + id;
        }

        public static string Teams(List<string> ids)
        {
            return "&teamids=" + CommaSeparatedValues(ids);
        }

        public static string Region(string id)
        {
            return "&regionid=" + id;
        }

        public static string Regions(List<string> ids)
        {
            return "&regionids=" + CommaSeparatedValues(ids);
        }

        public static string League(string id)
        {
            return "&leagueid=" + id;
        }

        public static string Leagues(List<string> ids)
        {
            return "&leagueids=" + CommaSeparatedValues(ids);
        }

        public static string Country(string iso)
        {
            return "&country_iso=" + iso;
        }

        public static string Nationality(string iso)
        {
            return "&nationality=" + iso;
        }

        

        public static string Member(string id)
        {
            return "&memberid=" + id;
        }

        public static string Members(List<string> ids)
        {
            return "&memberids=" + CommaSeparatedValues(ids);
        }

        public static string Fixture(string id)
        {
            return "&fixtureid=" + id;
        }

        public static string Fixtures(List<string> ids)
        {
            return "&fixtureids=" + CommaSeparatedValues(ids);
        }
        public static string FixturesPast(string id)
        {
            return "&past=" + id;
        }

        public static string FixturesFuture(string id)
        {
            return "&future=" + id;
        }

        public static string Division(string id)
        {
            return "&divisionid=" + id;
        }

        public static string Divisions(List<string> ids)
        {
            return "&divisionids=" + CommaSeparatedValues(ids);
        }


        public static string GetYouth()
        {
            return "&youth=1";
        }

        public static string GetNational()
        {
            return "&nat=1";
        }

        public static string GetU20()
        {
            return "&u20=1";
        }


        public static string RankingStart(string start)
        {
            return "&start=" + start;
        }

        public static string RankingLimit(string limit)
        {
            return "&limit=" + limit;
        }



        private static string CommaSeparatedValues(IEnumerable<string> values)
        {
            string CSvalue = values.Aggregate(String.Empty, (current, value) => current + (value + ","));

            if (CSvalue.LastIndexOf(',') != -1)
            {
                CSvalue.Remove(CSvalue.LastIndexOf(','));
            }

            return CSvalue;
        }
    }
}
