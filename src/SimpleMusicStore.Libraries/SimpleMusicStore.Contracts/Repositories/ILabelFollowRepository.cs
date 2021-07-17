using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface ILabelFollowRepository : IRepository
    {
        ValueTask<EntityEntry<LabelFollow>> Add(int labelId, int userId);
        Task<bool> Exists(int labelId, int userId);
		Task Delete(int labelId, int userId);
    }
}
