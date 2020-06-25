using SimpleMusicStore.Constants;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;

namespace SimpleMusicStore.Contracts.Sorting
{
    public interface Sorter
    {
        IEnumerable<RecordDetails> Sort(SortTypes sort, IEnumerable<RecordDetails> records);
    }
}
