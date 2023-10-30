using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using System.Xml.Linq;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
        }

        public Task<int?> Add(int id, string type)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Add(id, type));
        }
        public Task<int?> Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository?.Delete(id));
        }

        public Task<bool> Update(int id, string type)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Update(id, type));
        }
    }
}
