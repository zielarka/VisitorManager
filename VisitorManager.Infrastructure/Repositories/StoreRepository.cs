using Microsoft.EntityFrameworkCore;
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
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext_Sqlite _context;

        public StoreRepository(DataContext_Sqlite context)
        {
            _context = context;
        }

        public async Task<Store> GetAsync(Guid id)
            => await Task.FromResult(_context.Store.SingleOrDefault(x => x.Id == id));

        public async Task<Store> GetAsync(string name)
            => await Task.FromResult(_context.Store.SingleOrDefault(x => x.Name == name));

        public async Task<IEnumerable<Store>> BrowserAsync(string name = "")
        {
            var stores = _context.Store.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                stores = stores.Where(x => x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }

            return await Task.FromResult(stores);
        }
        public async Task AddAsync(Store store)
        {
            await _context.Store.AddAsync(store);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Store store)
        {
            _context.Store.Update(store);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Store store)
        {
            _context.Store.Remove(store);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
