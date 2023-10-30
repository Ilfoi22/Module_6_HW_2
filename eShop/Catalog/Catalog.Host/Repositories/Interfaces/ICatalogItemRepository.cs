using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogItem> GetByIdAsync(int id);
    Task<CatalogItem> GetByBrandAsync(string brandName);
    Task<CatalogItem> GetByTypeAsync(string type);
    Task<CatalogBrand> BrandsAsync(string brandName);
    Task<CatalogType> TypesAsync(string type);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<int?> Delete(int itemId);
    Task<bool> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
}