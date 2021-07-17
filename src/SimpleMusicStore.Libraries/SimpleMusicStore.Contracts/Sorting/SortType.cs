using SimpleMusicStore.Models.View;
using System.Collections.Generic;

namespace SimpleMusicStore.Contracts.Sorting
{
    public interface SortType
    {
        IEnumerable<RecordDetails> Sort(IEnumerable<RecordDetails> records);
    }
}
