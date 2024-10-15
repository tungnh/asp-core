using Microsoft.EntityFrameworkCore;
using OM.Application.Data.Queries;
using OM.Domain;

namespace OM.Infrastructure.Data.Queries
{
    public class MemberQuery : IMemberQuery
    {
        protected readonly ApplicationDbContext _context;

        public MemberQuery(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Member> GetAllMembers()
        {
            var results = _context.Members.AsNoTracking().ToList();
            return results;
        }
    }
}
