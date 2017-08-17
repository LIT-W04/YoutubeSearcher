using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSearcher.API
{
    public class YoutubeResults
    {
        public string NextPageToken { get; set; }
        public IEnumerable<YoutubeVideo> Videos { get; set; }
    }
}
