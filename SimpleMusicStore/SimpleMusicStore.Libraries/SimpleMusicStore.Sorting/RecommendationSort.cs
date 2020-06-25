using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Contracts.Sorting;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMusicStore.Sorting
{
    public class RecommendationSort : SortType
    {
        private readonly IUserActivities _currentUser;

        public RecommendationSort(IUserActivities currentUser)
        {
            _currentUser = currentUser;
        }

        public IEnumerable<RecordDetails> Sort(IEnumerable<RecordDetails> records)
        {
            return records.OrderByDescending(r =>
            {
                if (UserHasAlreadyOrderedTheRecord(r))
                    return -1;
                else
                    return IsArtistFollowed(r) + IsLabelFollowed(r) + LabelAndArtistOrderCount(r);
            });
        }

        private int IsArtistFollowed(RecordDetails record)
        {
            if (_currentUser.FollowedArtists.Any(fa => fa.Id == record.Artist.Id))
                return 2;
            else
                return 0;
        }
        
        private int IsLabelFollowed(RecordDetails record)
        {
            if (_currentUser.FollowedLabels.Any(fa => fa.Id == record.Label.Id))
                return 2;
            else
                return 0;
        }

        private int LabelAndArtistOrderCount(RecordDetails record)
        {
            return _currentUser.Orders.Sum(o => o.Items
                        .Where(i => i.Artist.Id == record.Artist.Id || i.Label.Id == record.Label.Id)
                        .Sum(i => i.Quantity));
        }

        private bool UserHasAlreadyOrderedTheRecord(RecordDetails record)
        {
            return _currentUser.Orders.Any(o => o.Items.Any(i => i.Id == record.Id));
        }
    }
}
