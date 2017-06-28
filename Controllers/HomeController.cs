using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StackOverflowMonitor.Models;
using StackOverflowMonitor.ViewModels;

namespace StackOverflowMonitor.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            string url = @"https://stackoverflow.com/feeds/tag?tagnames=.net+linux&sort=newest";
            var feedTask = Feed.DoFeedRequest(url);
            feedTask.Wait();

            string xml = feedTask.Result;
            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(xml);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            
            var feed = Feed.GetFeedFromXml(xml);

            var viewmodel = new HomeViewModel();
            viewmodel.Feed = feed;

            return View("Index", viewmodel);
        }
    }
}
