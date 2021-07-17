using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentView> FindAll(int recordId, int page);
        Task Add(NewComment comment);
        Task Edit(EditComment comment);
        Task Delete(int commentId);
    }
}
