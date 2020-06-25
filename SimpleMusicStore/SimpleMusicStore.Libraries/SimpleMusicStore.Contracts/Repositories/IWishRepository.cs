using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IWishRepository : IRepository
    {
        ValueTask<EntityEntry<Wish>> Add(int recordId, int userId);
        Task<bool> Exists(int recordId, int userId);
		Task Delete(int recordId, int userId);
	}
}
