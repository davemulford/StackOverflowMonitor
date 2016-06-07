using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StackOverflowMonitor.Models
{
    [XmlRoot("feed", Namespace="http://www.w3.org/2005/Atom")]
    public class Feed
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("subtitle")]
        public string SubTitle { get; set; }

        [XmlElement("id")]
        public string Url { get; set; }

        [XmlElement("entry")]
        public List<Entry> Entries { get; set; }

        public static Feed GetFeedFromXml(string xml)
        {
            var serializer = new XmlSerializer(typeof(Feed));
            Feed feed = (Feed)serializer.Deserialize(new StringReader(xml));

            return feed;
        }

        public static async Task<string> DoFeedRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                string xml = await content.ReadAsStringAsync();
                return xml;
            }
        }
    }
}
