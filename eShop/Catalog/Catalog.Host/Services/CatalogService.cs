using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }
    
    /*
        Get By Id 
    */

    public async Task<CatalogItemDto> GetCatalogItemByIdAsync(int id)
    {
        var catalogItem = await _catalogItemRepository.GetByIdAsync(id);

        if (catalogItem != null)
        {
            return _mapper.Map<CatalogItemDto>(catalogItem);
        }

        return null;
    }

    /*
        Get By Brand 
    */

    public async Task<CatalogItemDto> GetCatalogItemByBrandAsync(string brandName)
    {
        var catalogItem = await _catalogItemRepository.GetByBrandAsync(brandName);

        if (catalogItem != null)
        {
            return _mapper.Map<CatalogItemDto>(catalogItem);
        }

        return null;
    }

    /*
        Get By Type 
    */

    public async Task<CatalogItemDto> GetCatalogItemByTypeAsync(string type)
    {
        var catalogItem = await _catalogItemRepository.GetByTypeAsync(type);

        if (catalogItem != null)
        {
            return _mapper.Map<CatalogItemDto>(catalogItem);
        }

        return null;
    }

    /*
        Get Brands 
    */

    public async Task<CatalogBrandDto> CatalogBrandBrandsAsync(string brandName)
    {
        var catalogItem = await _catalogItemRepository.BrandsAsync(brandName);

        if (catalogItem != null)
        {
            return _mapper.Map<CatalogBrandDto>(catalogItem);
        }

        return null;
    }

    /*
        Get Types 
    */

    public async Task<CatalogTypeDto> CatalogTypeTypesAsync(string type)
    {
        var catalogItem = await _catalogItemRepository.TypesAsync(type);

        if (catalogItem != null)
        {
            return _mapper.Map<CatalogTypeDto>(catalogItem);
        }

        return null;
    }
}