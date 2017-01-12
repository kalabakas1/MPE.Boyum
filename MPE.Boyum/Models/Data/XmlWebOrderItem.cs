using System.Xml.Serialization;

namespace MPE.Boyum.Models.Data
{
    [XmlRoot("Item")]
    public class XmlWebOrderItem 
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
