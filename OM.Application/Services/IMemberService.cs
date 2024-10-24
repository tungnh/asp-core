using OM.Application.Models.Member;
using OM.Application.Models.Paging;

namespace OM.Application.Services
{
    public interface IMemberService
    {
        Task<MemberInputModel> FindAsync(int? id);

        Task<PaginatedList<MemberInputModel>> FindAllAsync(string? searchString, Pageable pageable);

        Task<int> AddAsync(MemberInputModel model, string userId);

        Task<int> UpdateAsync(MemberInputModel model, string userId);

        Task<int> RemoveAsync(int id);
    }
}
