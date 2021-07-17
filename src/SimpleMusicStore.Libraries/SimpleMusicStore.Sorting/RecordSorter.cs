using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Contracts.Sorting;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;

namespace SimpleMusicStore.Sorting
{
    public class RecordSorter : Sorter
    {
        private readonly IUserActivities _currentUser;

        public RecordSorter(IUserActivities currentUser)
        {
            _currentUser = currentUser;
        }

        public IEnumerable<RecordDetails> Sort(SortTypes sort, IEnumerable<RecordDetails> records)
        {
            if (sort == SortTypes.Recommendation && _currentUser.IsAuthenticated)
                return new RecommendationSort(_currentUser).Sort(records);
            else if (sort == SortTypes.DateAdded)
                return new DateAddedSort().Sort(records);
            else if (sort == SortTypes.ReleaseDate)
                return new ReleaseDateSort().Sort(records);
            else if (sort == SortTypes.PriceAscending)
                return new PriceAscendingSort().Sort(records);
            else if (sort == SortTypes.PriceDescending)
                return new PriceDescendingSort().Sort(records);
            else
                return new PopularitySort().Sort(records);
        }
    }
}
