using SimpleMusicStore.Models.MusicLibraries;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface ILabelRepository : IRepository
    {
        Task Add(LabelInfo label);
        Task<bool> Exists(int id);
        Task<LabelView> Find(int id);
        IEnumerable<SearchResult> FindAll(string searchTerm);
    }
}
