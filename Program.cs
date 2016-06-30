using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using StackOverflowMonitor.Models;

namespace StackOverflowMonitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

            /*
            string url = @"http://stackoverflow.com/feeds/tag?tagnames=.net+linux&sort=newest";
            var feedTask = Feed.DoFeedRequest(url);
            feedTask.Wait();

            string xml = feedTask.Result;
            var feed = Feed.GetFeedFromXml(xml);;

            Console.WriteLine($"{feed.Title} --> {feed.SubTitle}");

            if (feed.Entries != null)
            {
                foreach (var entry in feed.Entries)
                {
                    Console.WriteLine($"{entry.Title} -- {entry.AuthorName} ({entry.TagStrings.Aggregate((sb,t) => string.Concat(sb, ",", t))})");
                }
            }
            */
        }
    }
}
