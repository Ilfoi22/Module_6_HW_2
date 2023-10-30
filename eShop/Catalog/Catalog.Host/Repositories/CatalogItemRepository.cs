using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
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

        _dbContext.CatalogItems.Remove(existingItem);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var existingItem = await GetByIdAsync(id);

        if (existingItem == null)
            return false;

        existingItem.Name = name;
        existingItem.Description = description;
        existingItem.Price = price;
        existingItem.AvailableStock = availableStock;
        existingItem.CatalogBrandId = catalogBrandId;
        existingItem.CatalogTypeId = catalogTypeId;
        existingItem.PictureFileName = pictureFileName;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<CatalogItem> GetByIdAsync(int id)
    {
        return await _dbContext.CatalogItems
            .Where(i => i.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<CatalogItem> GetByBrandAsync(string brandName)
    {
        return await _dbContext.CatalogItems
            .Where(i => i.Name == brandName)
            .FirstOrDefaultAsync();
    }

    public async Task<CatalogItem> GetByTypeAsync(string type)
    {
        return await _dbContext.CatalogItems
            .Where(i => i.CatalogType.Type == type)
            .FirstOrDefaultAsync();
    }

    public async Task<CatalogBrand> BrandsAsync(string brandName)
    {
        return await _dbContext.CatalogBrands
            .Where(b => b.Brand == brandName)
            .FirstOrDefaultAsync();
    }
    
    public async Task<CatalogType> TypesAsync(string type)
    {
        return await _dbContext.CatalogTypes
            .Where(t => t.Type == type)
            .FirstOrDefaultAsync();
    }
}