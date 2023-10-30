namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<int?> Add(int id, string brand);
        Task<int?> Delete(int id);
        Task<bool> Update(int id, string brand);
    }
}
