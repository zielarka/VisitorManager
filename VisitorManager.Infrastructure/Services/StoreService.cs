using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitorManager.Core.Domain;
using VisitorManager.Core.Repository;
using VisitorManager.Infrastructure.Commands.Store;
using VisitorManager.Infrastructure.DTO;
using VisitorManager.Infrastructure.Extensions;
namespace VisitorManager.Infrastructure.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<StoreDto> GetAsync(Guid id)
        {
            var store = await _storeRepository.GetAsync(id);
            return _mapper.Map<StoreDto>(store);
        }
        public async Task<StoreDto> GetAsync(string name)
        { 
            var store = await _storeRepository.GetAsync(name);
            return _mapper.Map<StoreDto>(store);
        }

        public async Task<IEnumerable<StoreDto>> BrowserAsync(string name = null)
        {
            var stores = await _storeRepository.BrowserAsync(name);
            return _mapper.Map<IEnumerable<StoreDto>>(stores);
        }

        public async Task CreateAsync(Guid id, string name, string city, string street, string sid, string postalCode, string responsiblePerson, float latitude, float longitude)
        {
            var store = await _storeRepository.GetAsync(name);
            if (store != null)
            {
                throw new Exception($"Store named: '{name}' already exists");
            }
            @store = new Store(id, name, city, street, sid, postalCode, responsiblePerson, latitude, longitude);
            await _storeRepository.AddAsync(store);
        }

        public async Task UpdateAsync(Guid id, string name)
        {
            var store = await _storeRepository.GetOrFailAsync(id);
            store.SetName(name);
            await _storeRepository.UpdateAsync(store);
        }

        public async Task DeleteAsync(Guid id)
        {
            var store = await _storeRepository.GetOrFailAsync(id);
            await _storeRepository.DeleteAsync(store);
        }
    }
}
