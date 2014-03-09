using System.Xml;

namespace APILib.Mappings
{
    public static class XmlToApiModelHelper
    {
        public static string FirstOrDefault(XmlNode node)
        {
            return node != null ? node.InnerText : "";
        }
    }
}