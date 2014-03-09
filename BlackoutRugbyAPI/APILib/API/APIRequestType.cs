namespace APILib.API
{

    public static class APIRequestType
    {

        private static string Request
        {
            get { return "&r="; }
        }

        public static string Player
        {
            get { return Request + "p"; }
        }

        public static string Team
        {
            get { return Request + "t"; }
        }
        public static string Member
        {
            get { return Request + "m"; }
        }
        public static string Country
        {
            get { return Request + "c"; }
        }


        public static string Region
        {
            get { return Request + "r"; }
        }

        public static string Fixture
        {
            get { return Request + "f"; }
        }

        public static string Division
        {
            get { return Request + "d"; }
        }

        public static string League
        {
            get { return Request + "l"; }
        }

        public static string Standing
        {
            get { return Request + "s"; }
        }

        public static string ReporterSummary
        {
            get { return Request + "rs"; }
        }

        public static string MatchSummary
        {
            get { return Request + "ms"; }
        }
        public static string PlayerStatistics
        {
            get { return Request + "ps"; }
        }

        public static string TeamStatistics
        {
            get { return Request + "ts"; }
        }

        public static string FixtureStatistics
        {
            get { return Request + "fs"; }
        }

        public static string TrainingInstructions
        {
            get { return Request + "ti"; }
        }

        public static string TrainingReports
        {
            get { return Request + "tp"; }
        }

        public static string Ranking
        {
            get { return Request + "rk"; }
        }

        public static string RankingHistory
        {
            get { return Request + "rkh"; }
        }

        public static string TransferMarket
        {
            get { return Request + "tm"; }
        }



    }
}
