using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IAddressRepository : IRepository
    {
        IEnumerable<AddressDetails> FindAll(int userId);
        ValueTask<EntityEntry<Address>> Add(NewAddress address);
        Task Edit(AddressEdit address);
        Task Remove(int addressId);
        Task<bool> Exists(int id, int userId);
    }
}
