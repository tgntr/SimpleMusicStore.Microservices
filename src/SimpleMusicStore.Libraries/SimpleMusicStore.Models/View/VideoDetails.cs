using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class VideoDetails
    {
        public string Uri { get; set; }
        public string YoutubeId => Uri.Split("=").Last();
    }
}
