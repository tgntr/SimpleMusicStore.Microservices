using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Validators
{
    public interface IServiceValidator
    {
        Task ItemIsInStock(int itemId, IDictionary<int, int> items);
        Task ItemsAreInStock(IDictionary<int, int> items);
        void ItemIsInCart(int itemId, IDictionary<int, int> items);
        Task RecordIsNotInStore(int recordId);
        Task LabelExists(int labelId);
        Task LabelIsNotFollowed(int labelId);
        Task ArtistIsNotFollowed(int artistId);
        Task ArtistExists(int artistId);
        Task RecordExists(int recordId);
        Task RecordIsNotInWishlist(int recordId);
        void CartIsNotEmpty(IDictionary<int, int> items);
        Task AddressIsValid(int id);
        void AccessibleByCurrentUser(int userId);
		Task IsCommentAuthor(int commentId);

	}
}
