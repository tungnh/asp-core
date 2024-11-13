using OM.Domain;

namespace OM.Application.Data.Queries
{
    public interface IProductQuery
    {
        Task<List<Product>> FindAllAsync();
    }
}
