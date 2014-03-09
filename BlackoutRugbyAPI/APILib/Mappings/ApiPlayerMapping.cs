using System.Collections.Generic;
using System.Linq;
using System.Xml;
using APILib.Models;

namespace APILib.Mappings
{
    public class ApiPlayerMapping
    {
        public List<ApiPlayer> MapAll(XmlDocument xDoc)
        {
            var modelList = new List<ApiPlayer>();
            var nodeList = xDoc.SelectNodes("/blackoutrugby_api_response/player");

            if (nodeList != null)
                modelList.AddRange(from XmlNode node in nodeList
                                   select new ApiPlayer
                                   {
                                       Id = XmlToApiModelHelper.FirstOrDefault(node["id"]),
                                       Name = XmlToApiModelHelper.FirstOrDefault(node["name"]),
                                       FirstName = XmlToApiModelHelper.FirstOrDefault(node["fname"]),
                                       LastName = XmlToApiModelHelper.FirstOrDefault(node["lname"]),
                                       Csr = XmlToApiModelHelper.FirstOrDefault(node["csr"]),
                                       Age = XmlToApiModelHelper.FirstOrDefault(node["age"]),
                                       Birthday = XmlToApiModelHelper.FirstOrDefault(node["birthday"]),
                                       Hand = XmlToApiModelHelper.FirstOrDefault(node["hand"]),
                                       Foot = XmlToApiModelHelper.FirstOrDefault(node["foot"]),
                                       Nationality = XmlToApiModelHelper.FirstOrDefault(node["nationality"]),
                                       Form = XmlToApiModelHelper.FirstOrDefault(node["form"]),
                                       Aggression = XmlToApiModelHelper.FirstOrDefault(node["aggression"]),
                                       Discipline = XmlToApiModelHelper.FirstOrDefault(node["discipline"]),
                                       Energy = XmlToApiModelHelper.FirstOrDefault(node["energy"]),
                                       Leadership = XmlToApiModelHelper.FirstOrDefault(node["leadership"]),
                                       Experience = XmlToApiModelHelper.FirstOrDefault(node["experience"]),
                                       Weight = XmlToApiModelHelper.FirstOrDefault(node["weight"]),
                                       Height = XmlToApiModelHelper.FirstOrDefault(node["height"]),
                                       DualNationality = XmlToApiModelHelper.FirstOrDefault(node["dualnationality"]),
                                       Scouted = XmlToApiModelHelper.FirstOrDefault(node["scouted"]),
                                       ScoutingStars = XmlToApiModelHelper.FirstOrDefault(node["scouting_stars_used"]),
                                       Youthid = XmlToApiModelHelper.FirstOrDefault(node["youthid"]),
                                       Injured = XmlToApiModelHelper.FirstOrDefault(node["injured"]),
                                       Joined = XmlToApiModelHelper.FirstOrDefault(node["joined"]),
                                       Forsale = XmlToApiModelHelper.FirstOrDefault(node["forsale"]),
                                       Listed = XmlToApiModelHelper.FirstOrDefault(node["listed"]),
                                       Deadline = XmlToApiModelHelper.FirstOrDefault(node["deadline"]),
                                       AskingPrice = XmlToApiModelHelper.FirstOrDefault(node["asking"]),
                                       Price = XmlToApiModelHelper.FirstOrDefault(node["price"]),
                                       BidTeamId = XmlToApiModelHelper.FirstOrDefault(node["bidteamid"]),
                                       NextBid = XmlToApiModelHelper.FirstOrDefault(node["nextbid"]),

                                       Stamina = XmlToApiModelHelper.FirstOrDefault(node["stamina"]),
                                       Handling = XmlToApiModelHelper.FirstOrDefault(node["handling"]),
                                       Attack = XmlToApiModelHelper.FirstOrDefault(node["attack"]),
                                       Defense = XmlToApiModelHelper.FirstOrDefault(node["defense"]),
                                       Technique = XmlToApiModelHelper.FirstOrDefault(node["technique"]),
                                       Strength = XmlToApiModelHelper.FirstOrDefault(node["strength"]),
                                       Jumping = XmlToApiModelHelper.FirstOrDefault(node["jumping"]),
                                       Speed = XmlToApiModelHelper.FirstOrDefault(node["speed"]),
                                       Agility = XmlToApiModelHelper.FirstOrDefault(node["agility"]),
                                       Kicking = XmlToApiModelHelper.FirstOrDefault(node["kicking"])

                                       


                                   });
            return modelList;
        }
    }
}