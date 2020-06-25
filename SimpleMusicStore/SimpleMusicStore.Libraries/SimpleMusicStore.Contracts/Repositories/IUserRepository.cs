using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using SimpleMusicStore.Models;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<bool> Exists(string email);
        ValueTask<EntityEntry<User>> Add(UserClaims user);
        Task<UserDetails> Find(int id);
        Task<UserClaims> Find(string email);
        IEnumerable<SubscriberDetails> Subscribers();
    }
}
