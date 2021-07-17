using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IOrderRepository : IRepository
    {
        ValueTask<EntityEntry<Order>> Add(NewOrder order);
        Task<OrderView> Find(int id);
    }
}
