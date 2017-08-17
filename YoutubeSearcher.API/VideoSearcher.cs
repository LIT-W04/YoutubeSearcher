using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace YoutubeSearcher.API
{
    public class VideoSearcher
    {
        private string _apiKey;

        public VideoSearcher(string apiKey)
        {
            _apiKey = apiKey;
        }

        public YoutubeResults Search(string search, DateTime? from, DateTime? to, string nextPageToken)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey,
                ApplicationName = "MyYoutubeSearcher"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = search;
            searchListRequest.MaxResults = 50;
            searchListRequest.SafeSearch = SearchResource.ListRequest.SafeSearchEnum.Strict;
            searchListRequest.PublishedAfter = from;
            searchListRequest.PublishedBefore = to;
            searchListRequest.PageToken = nextPageToken;


            var searchListResponse = searchListRequest.Execute();
            var videos = new List<YoutubeVideo>();
            foreach (var response in searchListResponse.Items)
            {
                var video = new YoutubeVideo();
                video.Title = response.Snippet.Title;
                video.Url = $"https://www.youtube.com/watch?v={response.Id.VideoId}";
                video.Thumbnail = response.Snippet.Thumbnails.Medium.Url;
                video.PublishedDate = response.Snippet.PublishedAt.Value;
                videos.Add(video);
            }

            var result = new YoutubeResults();
            result.Videos = videos;
            result.NextPageToken = searchListResponse.NextPageToken;
            return result;
        }
    }
}
