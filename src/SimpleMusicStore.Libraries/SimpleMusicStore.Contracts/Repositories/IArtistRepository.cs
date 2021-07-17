using SimpleMusicStore.Models.MusicLibraries;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Repositories
{
    public interface IArtistRepository : IRepository
    {
        Task Add(ArtistInfo artist);
        Task<bool> Exists(int id);
        Task<ArtistView> Find(int id);
        IEnumerable<SearchResult> FindAll(string searchTerm);
    }
}
