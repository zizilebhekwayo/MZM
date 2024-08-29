using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MZM.Models
{
    public class YouTubeService
    {
        private readonly string _apiKey;

        public YouTubeService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<List<YouTubeVideo>> GetChannelVideosAsync(string channelId)
        {
            var videos = new List<YouTubeVideo>();

            using (var httpClient = new HttpClient())
            {
                var url = $"https://www.googleapis.com/youtube/v3/search?key={_apiKey}&channelId={channelId}&part=snippet,id&order=date&maxResults=10";
                var response = await httpClient.GetStringAsync(url);
                var json = JObject.Parse(response);

                foreach (var item in json["items"])
                {
                    var video = new YouTubeVideo
                    {
                        Title = (string)item["snippet"]["title"],
                        VideoId = (string)item["id"]["videoId"],
                        Description = (string)item["snippet"]["description"],
                        ThumbnailUrl = (string)item["snippet"]["thumbnails"]["high"]["url"],

                    };
                    videos.Add(video);
                }
            }

            return videos;
        }
    }
}