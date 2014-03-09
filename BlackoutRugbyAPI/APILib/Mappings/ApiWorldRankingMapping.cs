using System.Collections.Generic;
using System.Linq;
using System.Xml;
using APILib.Models;

namespace APILib.Mappings
{
    public class ApiWorldRankingMapping
    {
        public List<ApiWorldRanking> MapAll(XmlDocument xDoc)
        {
            var modelList = new List<ApiWorldRanking>();
            var nodeList = xDoc.SelectNodes("/blackoutrugby_api_response/team");

            if (nodeList != null)
                modelList.AddRange(from XmlNode node in nodeList
                                   select new ApiWorldRanking
                                   {
                                       TeamId = XmlToApiModelHelper.FirstOrDefault(node["id"]),
                                       CountryIso = XmlToApiModelHelper.FirstOrDefault(node["country_iso"]),
                                       Name = XmlToApiModelHelper.FirstOrDefault(node["name"]),
                                       Ranking = XmlToApiModelHelper.FirstOrDefault(node["ranking"]),
                                       Points = XmlToApiModelHelper.FirstOrDefault(node["points"])
                                   });
            return modelList;
        }
    }
}