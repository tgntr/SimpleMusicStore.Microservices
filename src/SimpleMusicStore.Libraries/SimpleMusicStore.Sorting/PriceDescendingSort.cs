using SimpleMusicStore.Contracts.Sorting;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMusicStore.Sorting
{
    public class PriceDescendingSort : SortType
    {
        public IEnumerable<RecordDetails> Sort(IEnumerable<RecordDetails> records)
        {
            return records.OrderByDescending(r => r.Price);
        }
    }
}
