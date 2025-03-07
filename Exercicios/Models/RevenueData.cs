using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Exercises.Models
{
    [XmlRoot("rows")]
    public class RevenueDataXmlList
    {
        [XmlElement("row")]
        public List<RevenueDataXml> Rows { get; set; }
    }

    public class RevenueDataXml
    {
        [XmlElement("dia")]
        public int Day { get; set; }

        [XmlElement("valor")]
        public decimal Value { get; set; }
    }


    public class RevenueDataJson
    {
        public int dia { get; set; }
        public decimal valor { get; set; }
    }

    public class RevenueData
    {
        public int Day { get; set; }

        public decimal Value { get; set; }
    }
}
