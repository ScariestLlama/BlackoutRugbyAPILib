using System.Collections.Generic;
using System.Linq;
using System.Xml;
using APILib.Models;

namespace APILib.Mappings
{
    public class ApiCountryMapping
    {
        

        public List<ApiCountry> MapAll(XmlDocument xDoc)
        {
            var modelList = new List<ApiCountry>();
            var nodeList = xDoc.SelectNodes("/blackoutrugby_api_response/country");

            if (nodeList != null)
                modelList.AddRange(from XmlNode node in nodeList
                                   select new ApiCountry
                                              {
                                                  CountryIso = XmlToApiModelHelper.FirstOrDefault(node["country_iso"]), 
                                                  Name = XmlToApiModelHelper.FirstOrDefault(node["name"]), 
                                                  TimeOffset = XmlToApiModelHelper.FirstOrDefault(node["time_offset"]), 
                                                  TimeZone = XmlToApiModelHelper.FirstOrDefault(node["timezone"])
                                              });
            return modelList;
        }
    }
}