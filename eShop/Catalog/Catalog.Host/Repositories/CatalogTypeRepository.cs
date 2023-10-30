using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ICatalogTypeRepository> _logger;

        public CatalogTypeRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<ICatalogTypeRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(int id, string type)
        {
            var item = await _dbContext.AddAsync(new CatalogType
            {
                Id = id,
                Type = type
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<int?> Delete(int id)
        {
            var existingItem = await GetByIdAsync(id);

            if (existingItem == null)
            {
                return null;
            }

            _dbContext.CatalogTypes.Remove(existingItem);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(int id, string type)
        {
            var existingItem = await GetByIdAsync(id);

            if (existingItem == null)
            {
                return false;
            }

            existingItem.Id = id;
            existingItem.Type = type;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CatalogType> GetByIdAsync(int id)
        {
            return await _dbContext.CatalogTypes
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
