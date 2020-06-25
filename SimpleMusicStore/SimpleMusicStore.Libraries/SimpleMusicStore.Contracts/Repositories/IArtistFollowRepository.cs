using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IArtistFollowRepository : IRepository
    {
        ValueTask<EntityEntry<ArtistFollow>> Add(int artistId, int userId);
        Task<bool> Exists(int artistId, int userId);
		Task Delete(int artistId, int userId);
	}
}
