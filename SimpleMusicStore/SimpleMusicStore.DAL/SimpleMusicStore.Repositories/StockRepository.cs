using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.Entities;
using System.Threading.Tasks;

namespace SimpleMusicStore.Repositories
{
    public class StockRepository : DbRepository<Stock>, IStockRepository
    {
        public StockRepository(SimpleMusicStoreDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public ValueTask<EntityEntry<Stock>> Add(int recordId, int quantity)
        {
            return _set.AddAsync(new Stock(recordId, quantity));
        }
    }
}
