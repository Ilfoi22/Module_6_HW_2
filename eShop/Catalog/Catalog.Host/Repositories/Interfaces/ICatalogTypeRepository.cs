namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<int?> Add(int id, string type);
        Task<int?> Delete(int id);
        Task<bool> Update(int id, string type);
    }
}
