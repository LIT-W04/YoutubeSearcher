using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSearcher.API
{
    public class YoutubeVideo
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
