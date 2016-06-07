using System;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

using StackOverflowMonitor.Extensions;

namespace StackOverflowMonitor.Models
{
    public class Entry
    {
        [XmlElement("id")]
        public string Url { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("summary")]
        public string Summary { get; set; }

        [XmlElement("author")]
        public Author Author { get; set; }

        public string AuthorName
        {
            get
            {
                return (this.Author != null)
                    ? this.Author.Name
                    : string.Empty;
            }
        }

        [XmlElement("published")]
        public DateTime Published { get; set; }

        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("category")]
        public List<Tag> Tags { get; set; }

        public List<string> TagStrings
        {
            get
            {
                return (this.Tags != null)
                    ? this.Tags.Select(t => t.Term).ToList()
                    : new List<string>();
            }
        }

        public string TimeString
        {
            get
            {
                if (this.Published > this.Updated)
                {
                    return $@"asked {this.Published.ToReadableString()}";
                }
                else
                {
                    return $@"updated {this.Published.ToReadableString()}";
                }
            }
        }
    }
}
