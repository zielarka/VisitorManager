using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;

namespace VisitorManager.Core.Repository
{
    public interface IDeviceRepository :IRepositoryMarker
    {
        Task<Device> GetAsync(Guid id);
        Task<Device> GetAsync(string serialNumber);
        Task<Device> GetAsyncStoreId(Guid Storeid);
        Task<IEnumerable<Device>> BrowserAsync(string name = "");
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
        Task DeleteAsync(Device device);
    }
}
