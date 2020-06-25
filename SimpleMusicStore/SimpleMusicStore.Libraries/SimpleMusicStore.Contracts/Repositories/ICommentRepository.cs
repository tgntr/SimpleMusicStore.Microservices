using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Entities;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface ICommentRepository : IRepository
    {
        ValueTask<EntityEntry<Comment>> Add(NewComment comment);
        Task Delete(int commentId);
        Task Edit(EditComment comment);
        IEnumerable<CommentView> FindAll(int recordId, int page);
		Task<bool> IsAuthor(int commentId, int userId);

	}
}
