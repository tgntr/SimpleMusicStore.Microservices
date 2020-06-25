using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IStockRepository : IRepository
    {
        ValueTask<EntityEntry<Stock>> Add(int recordId, int quantity);
    }
}
