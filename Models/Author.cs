using System;
using System.Linq;
using System.Xml.Serialization;

namespace StackOverflowMonitor.Models
{
    public class Author
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
