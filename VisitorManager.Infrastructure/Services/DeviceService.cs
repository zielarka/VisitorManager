using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Infrastructure.DTO;
using VisitorManager.Infrastructure.Extensions;

namespace VisitorManager.Infrastructure.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceService(IStoreRepository storeRepository,IDeviceRepository devicepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _deviceRepository = devicepository;
            _mapper = mapper;
        }

        public async Task<DeviceDto> GetAsync(string serialNumber)
        {
            var device = await _deviceRepository.GetAsync(serialNumber);
            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<IEnumerable<DeviceDto>> BrowserAsync(string name = null)
        {
            var devices = await _deviceRepository.BrowserAsync(name);
            return _mapper.Map<IEnumerable<DeviceDto>>(devices);
        }

        public async Task CreateAsync(Guid id, string serialNumber, string name, Guid? storeId)
        {
            var device = await _deviceRepository.GetAsync(serialNumber);
            if (device != null)
            {
                throw new Exception($"Device serial number: '{serialNumber}' already exists");
            }
            device = new Device(id, serialNumber, name, storeId);
            await _deviceRepository.AddAsync(device);
        }
        public async Task UpdateAsync(Guid id, Guid storeId)
        {
            var store = await _deviceRepository.GetAsyncStoreId(storeId);
            if (store != null)
            {
                throw new Exception($"Store named: '{store.Name}' already used");
            }
            var device = await _deviceRepository.GetOrFailAsync(id);
            device.SetStoreId(storeId);
            
            await _deviceRepository.UpdateAsync(device);
        }

        public async Task DeleteAsync(Guid id)
        {
            var store = await _deviceRepository.GetOrFailAsync(id);
            await _deviceRepository.DeleteAsync(store);
        }
    }
}
