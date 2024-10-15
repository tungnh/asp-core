using OM.Domain;

namespace OM.Application.Data.Queries
{
    public interface IMemberQuery
    {
        List<Member> GetAllMembers();
    }
}
