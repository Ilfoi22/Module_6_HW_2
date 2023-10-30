namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int?> Add(int id, string brand);
        Task<int?> Delete(int id);
        Task<bool> Update(int id, string brand);
    }
}
