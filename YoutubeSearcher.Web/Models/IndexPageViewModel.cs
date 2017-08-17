using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSearcher.API;

namespace YoutubeSearcher.Web.Models
{
    public class IndexPageViewModel
    {
        public string Search { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public IEnumerable<YoutubeVideo> Videos { get; set; }
    }
}