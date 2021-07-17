using SimpleMusicStore.Constants;
using System.Linq;

namespace SimpleMusicStore.Models.MusicLibraries
{
    public class LabelInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageInfo[] Images { get; set; }
        public string Image
        {
            get
            {
                if (Images is null || !Images.Any())
                    return DiscogsConstants.DEFAULT_IMAGE;
                else
                    return Images.First().Uri;
            }
        }
    }
}
