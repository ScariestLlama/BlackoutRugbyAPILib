using System.Collections.Generic;
using System.Linq;
using System.Xml;
using APILib.Models;

namespace APILib.Mappings
{
    public class ApiTeamMapping
    {
        public List<ApiTeam> MapAll(XmlDocument xDoc)
        {
            var modelList = new List<ApiTeam>();
            var nodeList = xDoc.SelectNodes("/blackoutrugby_api_response/team");

            if (nodeList != null)
                modelList.AddRange(from XmlNode node in nodeList
                                   select new ApiTeam
                                   {
                                       Id = XmlToApiModelHelper.FirstOrDefault(node["id"]),
                                       Name = XmlToApiModelHelper.FirstOrDefault(node["name"]),
                                       CountryIso = XmlToApiModelHelper.FirstOrDefault(node["country_iso"]),
                                       RegionId = XmlToApiModelHelper.FirstOrDefault(node["region"]),
                                       StadiumName = XmlToApiModelHelper.FirstOrDefault(node["stadium"]),
                                       IsBot = XmlToApiModelHelper.FirstOrDefault(node["bot"]),
                                       Nickname1 = XmlToApiModelHelper.FirstOrDefault(node["nickname_1"]),
                                       Nickname2 = XmlToApiModelHelper.FirstOrDefault(node["nickname_2"]),
                                       Nickname3 = XmlToApiModelHelper.FirstOrDefault(node["nickname_3"]),
                                       RankingPoints = XmlToApiModelHelper.FirstOrDefault(node["ranking_points"]),
                                       RegionalRank = XmlToApiModelHelper.FirstOrDefault(node["regional_rank"]),
                                       NationalRank = XmlToApiModelHelper.FirstOrDefault(node["national_rank"]),
                                       WorldRank = XmlToApiModelHelper.FirstOrDefault(node["world_rank"]),
                                       PrevRankingPoints = XmlToApiModelHelper.FirstOrDefault(node["prev_ranking_points"]),
                                       PrevRegionalRank = XmlToApiModelHelper.FirstOrDefault(node["prev_regional_rank"]),
                                       PrevNationalRank = XmlToApiModelHelper.FirstOrDefault(node["prev_national_rank"]),
                                       PrevWorldRank = XmlToApiModelHelper.FirstOrDefault(node["prev_world_rank"]),
                                       Plural = XmlToApiModelHelper.FirstOrDefault(node["plural"]),
                                       PluralNickname1 = XmlToApiModelHelper.FirstOrDefault(node["plural_nickname_1"]),
                                       PluralNickname2 = XmlToApiModelHelper.FirstOrDefault(node["plural_nickname_2"]),
                                       PluralNickname3 = XmlToApiModelHelper.FirstOrDefault(node["plural_nickname_3"]),
                                       MinimumSalary = XmlToApiModelHelper.FirstOrDefault(node["minimum_salary"]),
                                       LeagueId = XmlToApiModelHelper.FirstOrDefault(node["leagueid"]),
                                       Manager = XmlToApiModelHelper.FirstOrDefault(node["manager"])
                                       
                                       
                                   });
            return modelList;
        }
        
    }
}