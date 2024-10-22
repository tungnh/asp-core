using OM.Application.Models.Member;

namespace OM.Application.Services
{
    public interface IMemberService
    {
        Task<MemberInputModel> FindAsync(int? id);

        Task<List<MemberInputModel>> FindAllAsync();

        Task<int> AddAsync(MemberInputModel model);

        Task<int> UpdateAsync(MemberInputModel model);

        Task<int> RemoveAsync(int id);
    }
}
