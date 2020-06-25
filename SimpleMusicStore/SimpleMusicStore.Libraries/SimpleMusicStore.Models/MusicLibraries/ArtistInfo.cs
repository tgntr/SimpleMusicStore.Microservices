using SimpleMusicStore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.Models.MusicLibraries
{
    public class ArtistInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ImageInfo[] Images { get; set; }
        public string Image
        {
            get
            {
                if (Images is null || !Images.Any())
                    //TODO fix magic strings
                    return DiscogsConstants.DEFAULT_IMAGE;
                else
                    return Images.First().Uri;
            }
        }
    }
}
