using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Security.Cryptography;
using System.Text;

namespace APILib.API
{
    public class BlackoutAPI
    {
        private readonly AppConfig _config;

        private string _memberKey;

        public string MemberKey
        {
            set { _memberKey = value; }
        }

        public int BrSeason { get; private set; }
        public int BrRound { get; private set; }
        public int BrDay { get; private set; }

        public BlackoutAPI(AppConfig config)
        {
            _config = config;
            MemberKey = config.MyAccessKey;
        }

        public XmlDocument GetPlayer(string id)
        {
            return RequestData(APIRequestType.Player + APIAdditionalRequestData.Player(id));
        }

        public XmlDocument GetPlayers(IEnumerable<string> ids)
        {
            return RequestData(APIRequestType.Player + APIAdditionalRequestData.Players(ids));
        }

        public XmlDocument GetPlayersFromTeam(string id)
        {
            return RequestData(APIRequestType.Player + APIAdditionalRequestData.Team(id));
        }

        public XmlDocument GetPlayersFromYouthTeam(string id)
        {
            return RequestData(APIRequestType.Player + APIAdditionalRequestData.Team(id) + APIAdditionalRequestData.GetYouth());
        }

        public XmlDocument GetMemberData(string id)
        {
            return RequestData(APIRequestType.Member + APIAdditionalRequestData.Member(id));
        }

        public XmlDocument GetMemberData()
        {
            string id = String.Empty;

            try
            {
                id = _memberKey.Split('&')[0].Split('=')[1];
            }
            catch
            {
            }

            return GetMemberData(id);
        }

        public XmlDocument GetTeam(string id)
        {
            return RequestData(APIRequestType.Team + APIAdditionalRequestData.Team(id));
        }

        public XmlDocument GetTeamsFromRegion(string id)
        {
            return RequestData(APIRequestType.Team + APIAdditionalRequestData.Region(id));
        }

        private XmlDocument GetTeamsByWorldRankingChunk(string start, string limit)
        {
            return RequestData(APIRequestType.Ranking + APIAdditionalRequestData.RankingStart(start) + APIAdditionalRequestData.RankingLimit(limit));
        }

        

        public XmlDocument GetTeamsByWorldRanking(string limit)
        {
            return GetTeamsByWorldRankingChunk("0", limit);
        }

        public XmlDocument GetAllTeamsByWorldRanking()
        {
            const double maxLimit = 7500;
            const double chunkSize = 100;
            int totalChunks = (int)Math.Ceiling(maxLimit / chunkSize);
            var xDoc = new XmlDocument();
            var dec = xDoc.CreateXmlDeclaration("1.0", null, null);
            xDoc.AppendChild(dec);// Create the root element
            var root = xDoc.CreateElement("blackoutrugby_api_response");
            xDoc.AppendChild(root);

            //xDoc.SelectNodes("/blackoutrugby_api_response");
            //xDoc.AppendChild()

            for (int i = 0; i < totalChunks; i++)
            {
                var nodeList =
                    GetTeamsByWorldRankingChunk((i*chunkSize).ToString(), chunkSize.ToString()).SelectNodes(
                        "/blackoutrugby_api_response/team");
                if(nodeList != null)
                    foreach (XmlNode node in nodeList)
                    {
                        var importNode = xDoc.ImportNode(node, true);
                        root.AppendChild(importNode);
                    }
                
            }

            return xDoc;
        }

        //Debug Only
        public XmlDocument GetAllTeamsByWorldRanking(int numTeams)
        {
            double maxLimit = numTeams;
            double chunkSize = 100;

            if(numTeams < chunkSize)
            {
                chunkSize = numTeams;
            }

            int totalChunks = (int)Math.Ceiling(maxLimit / chunkSize);
            var xDoc = new XmlDocument();
            var dec = xDoc.CreateXmlDeclaration("1.0", null, null);
            xDoc.AppendChild(dec);// Create the root element
            var root = xDoc.CreateElement("blackoutrugby_api_response");
            xDoc.AppendChild(root);

            //xDoc.SelectNodes("/blackoutrugby_api_response");
            //xDoc.AppendChild()

            for (int i = 0; i < totalChunks; i++)
            {
                var nodeList =
                    GetTeamsByWorldRankingChunk((i * chunkSize).ToString(), chunkSize.ToString()).SelectNodes(
                        "/blackoutrugby_api_response/team");
                if (nodeList != null)
                    foreach (XmlNode node in nodeList)
                    {
                        var importNode = xDoc.ImportNode(node, true);
                        root.AppendChild(importNode);
                    }

            }

            return xDoc;
        }

        public XmlDocument GetRegionsFromCountry(string iso)
        {
            return RequestData(APIRequestType.Region + APIAdditionalRequestData.Country(iso));
        }

        public XmlDocument GetCountry(string iso)
        {
            return RequestData(APIRequestType.Country + APIAdditionalRequestData.Country(iso));
        }

        public XmlDocument GetAllCountries()
        {
            return GetCountry("all");
        }

        public XmlDocument GetPlayersFromTransferMarket(IEnumerable<string> args)
        {
            return RequestData(APIRequestType.TransferMarket + args.Aggregate("", (current, arg) => current + arg));
        }

        private XmlDocument RequestData(string request_string)
        {
            if (request_string == null) throw new ArgumentNullException("request_string");
            XmlDocument xDoc = new XmlDocument();


            // Create an unencrypted request as an array of bytes
            byte[] request = Encoding.UTF8.GetBytes(_memberKey + request_string);

            // Set the dev ID
            string devID = _config.DeveloperID;

            // Set the key and IV as arrays of bytes
            byte[] key = Encoding.UTF8.GetBytes(_config.DeveloperKey);
            byte[] iv = Encoding.UTF8.GetBytes(_config.DeveloperIV);




            // Create an instance of the AES Encryptor
            var aes = new AesCryptoServiceProvider();

            // Set the key and IV
            aes.Key = key;
            aes.IV = iv;

            // Set the mode of the AES Encryptor
            aes.Mode = CipherMode.CBC;

            // Set the padding mode of the AES Encryptor
            aes.Padding = PaddingMode.Zeros;

            // Get the transformer from the AES Encryptor
            var cTransform = aes.CreateEncryptor();

            // Use the transformer to encrypt our request
            var result =
              cTransform.TransformFinalBlock(request, 0, request.Length);

            // Release resources held by AES Encryptor
            aes.Clear();

            // Encode to base64
            var encryptedRequest =
              Convert.ToBase64String(result, 0, result.Length);

            // Send request to API
            var baseURL = _config.BaseAPIUrl;
            var requestString = "?d=" + devID + "&er=" + encryptedRequest;

            //To Stop system being blocked (limit of 100 calls a minute)
            Thread.Sleep(_config.TimeDelay);
            xDoc.Load(baseURL + requestString);

            try
            {
                //General Data we may need about the request
                var brResponseEl = xDoc.GetElementsByTagName("blackoutrugby_api_response")[0];
                BrSeason = Convert.ToInt32(brResponseEl.Attributes["season"].Value);
                BrRound = Convert.ToInt32(brResponseEl.Attributes["round"].Value);
                BrDay = Convert.ToInt32(brResponseEl.Attributes["day"].Value);
                //BrSeason = xDoc.a
            }
            catch
            {

            }

            // NOTE: getWebResponse() is a fictitious method
            // You will need to write your own code for web requests

            return xDoc;
        }


    }
}
