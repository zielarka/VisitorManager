using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Persistence.Migrations;

namespace VisitorManager.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext_Sqlite _context;

        public DeviceRepository(DataContext_Sqlite context)
        {
            _context = context;
        }
        public async Task<Device> GetAsync(Guid id)
            => await Task.FromResult(_context.Device.SingleOrDefault(x => x.Id == id));

        public async Task<Device> GetAsync(string serialNumber)
            => await Task.FromResult(_context.Device.SingleOrDefault(x => x.SerialNumber == serialNumber));

        public async Task<Device> GetAsyncStoreId(Guid Storeid)
            => await Task.FromResult(_context.Device.SingleOrDefault(x => x.StoreId == Storeid));

        public async Task<IEnumerable<Device>> BrowserAsync(string name = "")
        {
            var device = _context.Device.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                device = device.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(device);
        }

        public async Task AddAsync(Device device)
        {
            await _context.Device.AddAsync(device);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Device device)
        {
            _context.Device.Update(device);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Device device)
        {
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }


    }
}
