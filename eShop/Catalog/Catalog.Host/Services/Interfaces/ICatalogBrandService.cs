﻿using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int?> Add(int id, string brand);
        Task<CatalogBrand?> DeleteAsync(int id);
        Task<CatalogBrand?> UpdateAsync(int id, string brand);
    }
}
