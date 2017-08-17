using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoutubeSearcher.API;
using YoutubeSearcher.Web.Models;
using System.IO;

namespace YoutubeSearcher.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string search, DateTime? from, DateTime? to, string nextPageToken)
        {
            var searcher = new VideoSearcher(ConfigurationManager.AppSettings["YoutubeKey"]);
            var searchResults = searcher.Search(search, from, to, nextPageToken);
            return Json(searchResults, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void TrackLinkClick(string url)
        {
            System.IO.File.AppendAllText(Server.MapPath("~/LinkTracking") + "/tracks.txt", url + "\r\n");
        }
    }
}