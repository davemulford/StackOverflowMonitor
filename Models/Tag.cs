using System;
using System.Linq;
using System.Xml.Serialization;

namespace StackOverflowMonitor.Models
{
    public class Tag
    {
        [XmlAttribute("term")]
        public string Term { get; set; }
    }
}
