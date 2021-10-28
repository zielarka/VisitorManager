using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Infrastructure.DTO;

namespace VisitorManager.Infrastructure.Services
{
    public interface IDeviceService :IServiceMarker
    {
        Task<IEnumerable<DeviceDto>> BrowserAsync(string name = null);
        Task<DeviceDto> GetAsync(string serialNumber);
        Task CreateAsync(Guid id, string serialNumber, string name, Guid? storeId);
        Task UpdateAsync(Guid id, Guid storeId);
        Task DeleteAsync(Guid id);
    }
}
