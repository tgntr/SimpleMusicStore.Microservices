using System;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IRepository
    {
        Task SaveChanges();
    }
}
