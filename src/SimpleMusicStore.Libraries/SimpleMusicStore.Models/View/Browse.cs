using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class Browse
    {
        public IEnumerable<string> AvailableGenres { get; set; }
        public IEnumerable<string> AvailableFormats { get; set; }
        public IEnumerable<string> AvailableSortTypes { get; set; }
    }
}
