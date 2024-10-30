using Microsoft.EntityFrameworkCore;
using OM.Application.Data.Queries;
using OM.Domain;

namespace OM.Infrastructure.Data.Queries
{
    public class MemberQuery : IMemberQuery
    {
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the MemberQuery class with the given ApplicationDbContext.
        /// </summary>
        /// <param name="context">The ApplicationDbContext to be used by the MemberQuery instance.</param>
        public MemberQuery(ApplicationDbContext context)
        {
            _context = context;
        }
   
        /// <summary>
        /// Retrieves a list of all members asynchronously.
        /// </summary>
        /// <returns>A list of Member objects.</returns>
        public async Task<List<Member>> FindAllAsync()
        {
            return await _context.Members.AsNoTracking().ToListAsync();
        }
    }
}
