using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace MPE.Boyum.Models.Data
{
    [XmlRoot("WebOrder")]
    public  class XmlWebOrder
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        public string Customer { get; set; }

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement("Date")]
        public string XmlDate
        {
            set { Date = DateTime.ParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture); }
            get { return Date.ToString("yyyyMMdd"); }
        }

        [XmlArray("Items"),XmlArrayItem("Item")]
        public List<XmlWebOrderItem> Items { get; set; }
    }
}
