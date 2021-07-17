using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.MusicLibraries;
using SimpleMusicStore.Models.View;
using System.Threading.Tasks;

namespace SimpleMusicStore.Contracts.Services
{
    public interface IRecordService
    {
        Task Add(NewRecord record);
        NewsFeed NewsFeed();
        Task<RecordView> Find(int id);
        Task AddStock(int recordId, int quantity);
    }
}
