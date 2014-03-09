using System;
using System.Configuration;

namespace APILib.API
{
    public class AppConfig
    {
        public AppConfig(string developerKey, string developerID, string developerIV, string baseAPIUrl, string myMemberId, string myMemberKey, int timeDelay)
        {
            DeveloperKey = developerKey;
            DeveloperID = developerID;
            DeveloperIV = developerIV;
            BaseAPIUrl = baseAPIUrl;
            MyMemberID = myMemberId;
            MyMemberKey = myMemberKey;
            TimeDelay = timeDelay;
        }

        public string DeveloperKey { get; private set; }

        public string DeveloperID { get; private set; }

        public string DeveloperIV { get; private set; }

        public string BaseAPIUrl { get; private set; }

        public string MyMemberID { get; private set; }

        public string MyMemberKey { get; private set; }
        public int TimeDelay { get; private set; }

        public string MyAccessKey
        {
            get { return string.Format("&m={0}&mk={1}",MyMemberID, MyMemberKey); }
        }

        
    }
}
