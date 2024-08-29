using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MZM.Models
{
    public class YouTubeVideo
    {
        public string Title { get; set; }
        public string VideoId { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}