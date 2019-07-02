using MySquad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySquad.Services
{
    public interface IDataStore<T,TID>
    {
        Task<bool> AddMarineAsync(T Marine);
        Task<bool> UpdateMarineAsync(T Marine);
        Task<bool> DeleteMarineAsync(TID id);
        Task<T> GetMarineAsync(TID id);
        Task<IEnumerable<T>> GetMarinesAsync(bool forceRefresh = false);

        // this doesn't belong here, just added for simplicity 
        Task<List<FireTeam>> GetFireTeamsAsync(bool forceRefresh = false);
    }
}
