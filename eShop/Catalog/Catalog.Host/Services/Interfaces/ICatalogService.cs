using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<CatalogItemDto> GetCatalogItemByIdAsync(int id);
    Task<CatalogItemDto> GetCatalogItemByBrandAsync(string brandName);
    Task<CatalogItemDto> GetCatalogItemByTypeAsync(string type);
    Task<CatalogBrandDto> CatalogBrandBrandsAsync(string brandName);
    Task<CatalogTypeDto> CatalogTypeTypesAsync(string type);
}