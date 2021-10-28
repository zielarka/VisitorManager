using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;

namespace VisitorManager.Core.Repository
{
    public interface IStoreRepository :IRepositoryMarker
    {
        Task<Store> GetAsync(Guid id);
        Task<Store> GetAsync(string name);
        Task<IEnumerable<Store>> BrowserAsync(string name = "");
        Task AddAsync(Store @store);
        Task UpdateAsync(Store @store);
        Task DeleteAsync(Store @store);
    }
}
