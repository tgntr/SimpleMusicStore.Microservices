using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Models.View
{
    public class LabelView
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public IEnumerable<RecordDetails> Records { get; set; }
        public bool IsFollowed { get; set; }
    }
}
