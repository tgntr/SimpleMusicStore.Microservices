using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class SearchResult
    {
        public SearchResult() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ContentType { get; set; }
    }
}
