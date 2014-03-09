using System.Collections.Generic;
using System.Linq;
using System.Xml;
using APILib.Models;

namespace APILib.Mappings
{
    public class ApiRegionMapping
    {
        

        public List<ApiRegion> MapAll(XmlDocument xDoc)
        {
            var modelList = new List<ApiRegion>();
            var nodeList = xDoc.SelectNodes("/blackoutrugby_api_response/region");

            if (nodeList != null)
                modelList.AddRange(from XmlNode node in nodeList
                                   select new ApiRegion
                                   {
                                       Id = XmlToApiModelHelper.FirstOrDefault(node["id"]),
                                       Name = XmlToApiModelHelper.FirstOrDefault(node["name"]),
                                       CountryIso = XmlToApiModelHelper.FirstOrDefault(node["country_iso"])
                                       
                                   });
            return modelList;
        }
    }
}