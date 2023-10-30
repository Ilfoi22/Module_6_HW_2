using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(int id, string brand)
        {
            var item = await _dbContext.AddAsync(new CatalogBrand
            {
                Id = id,
                Brand = brand
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<int?> Delete(int itemId)
        {
            var existingItem = await GetByIdAsync(itemId);

            if (existingItem == null)
            {
                return null;
            }

            _dbContext.CatalogBrands.Remove(existingItem);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(int id, string brand)
        {
            var existingItem = await GetByIdAsync(id);

            if (existingItem == null)
            {
                return false;
            }

            existingItem.Id = id;
            existingItem.Brand = brand;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CatalogBrand> GetByIdAsync(int id)
        {
            return await _dbContext.CatalogBrands
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
