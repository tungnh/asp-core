using OM.Domain;

namespace OM.Application.Data.Queries
{
    public interface IProductDetailQuery
    {
        Task<List<ProductDetail>> FindAllAsync();

    }
}
