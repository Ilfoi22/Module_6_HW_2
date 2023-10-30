using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
        }

        public Task<int?> Add(int id, string type)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Add(id, type));
        }

        public Task<int?> Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository?.Delete(id));
        }

        public Task<bool> Update(int id, string type)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Update(id, type));
        }
    }
}
