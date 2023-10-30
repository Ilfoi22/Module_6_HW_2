namespace Catalog.Host.Models.Response;

public class ItemResponse<T>
{
    public T Id { get; set; } = default(T) !;
}