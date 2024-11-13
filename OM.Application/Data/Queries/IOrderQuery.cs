using OM.Domain;

namespace OM.Application.Data.Queries
{
    public interface IOrderQuery
    {
        Task<List<Order>> FindAllAsync();
    }
}
