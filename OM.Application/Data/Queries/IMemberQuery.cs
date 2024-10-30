using OM.Domain;

namespace OM.Application.Data.Queries
{
    public interface IMemberQuery
    {
        Task<List<Member>> FindAllAsync();
    }
}
