using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.Commands.Store;
using VisitorManager.Infrastructure.DTO;

namespace VisitorManager.Infrastructure.Services
{
    public interface IStoreService : IServiceMarker
    {
        Task<StoreDto> GetAsync(Guid id);
        Task<StoreDto> GetAsync(string name);
        Task<IEnumerable<StoreDto>> BrowserAsync(string name = null);
        Task CreateAsync(Guid id, string name, string city, string street, string sid, string postalCode, string responsiblePerson, float latitude, float longitude);
        Task UpdateAsync(Guid id, string name);
        Task DeleteAsync(Guid id);
    }
}
