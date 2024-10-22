using OM.Application.Data.Repositories;
using OM.Domain;

namespace OM.Infrastructure.Data.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
