using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Repositories
{
    public class LabelFollowRepository : DbRepository<LabelFollow>, ILabelFollowRepository
    {
        public LabelFollowRepository(SimpleMusicStoreDbContext db)
            : base(db)
        {
        }

        public ValueTask<EntityEntry<LabelFollow>> Add(int labelId, int userId)
        {
            return _set.AddAsync(new LabelFollow(labelId, userId));
        }

		public async Task Delete(int labelId, int userId)
        {
            var labelFollow = await _set.FindAsync(labelId, userId);
            ValidateThatLabelFollowExists(labelFollow);
            _set.Remove(labelFollow);
        }

        private void ValidateThatLabelFollowExists(LabelFollow labelFollow)
        {
            if (labelFollow == null)
                throw new ArgumentException(ErrorMessages.LABEL_NOT_FOLLOWED);
        }

        public Task<bool> Exists(int labelId, int userId)
        {
            return _set.AnyAsync(f => f.LabelId == labelId && f.UserId == userId);
        }
    }
}
