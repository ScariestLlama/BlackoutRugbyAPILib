using System.Collections.Generic;
using System.Linq;
using System.Xml;
using APILib.Models;

namespace APILib.Mappings
{
    public class ApiAuctionMapping
    {
        public List<ApiAuction> MapAll(XmlDocument xDoc)
        {
            var modelList = new List<ApiAuction>();
            var nodeList = xDoc.SelectNodes("/blackoutrugby_api_response/auction");

            if (nodeList != null)
                modelList.AddRange(from XmlNode node in nodeList
                                   select new ApiAuction
                                   {
                                       PlayerId = XmlToApiModelHelper.FirstOrDefault(node["playerid"]),
                                       
                                   });
            return modelList;
        }
    }
}