namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<int?> Add(int id, string type);
        Task<int?> Delete(int id);
        Task<bool> Update(int id, string type);
    }
}
