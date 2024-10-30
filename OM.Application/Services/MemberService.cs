using AutoMapper;
using OM.Application.Data.Queries;
using OM.Application.Data.Repositories;
using OM.Application.Models.Member;
using OM.Application.Models.Paging;
using OM.Application.Services.Interfaces;
using OM.Application.Utils;
using OM.Domain;

namespace OM.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMemberQuery _memberQuery;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMemberQuery memberQuery, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _memberQuery = memberQuery;
            _mapper = mapper;
        }

        public async Task<MemberInputModel> FindAsync(int? id)
        {
            var entity = await _memberRepository.FindAsync(id);
            return _mapper.Map<MemberInputModel>(entity);
        }

        public async Task<PaginatedList<MemberInputModel>> FindAllAsync(MemberRequestModel requestModel, Pageable pageable)
        {
            var predicate = PredicateBuilder.True<Member>();
            if (!string.IsNullOrEmpty(requestModel.Name))
            {
                predicate = predicate.And(x => x.Name.Contains(requestModel.Name));
            }
            if (!string.IsNullOrEmpty(requestModel.Type))
            {
                predicate = predicate.And(x => x.Type.Contains(requestModel.Type));
            }
            var page = await _memberRepository.FindAllAsync(predicate, pageable);
            return _mapper.Map<PaginatedList<Member>, PaginatedList<MemberInputModel>>(page);
        }

        public async Task<int> AddAsync(MemberInputModel model, string userId)
        {
            var entity = _mapper.Map<Member>(model);
            return await _memberRepository.AddAsync(entity, userId);
        }

        public async Task<int> UpdateAsync(MemberInputModel model, string userId)
        {
            var entity = await _memberRepository.FindAsync(model.Id);
            if (entity != null)
            {
                _mapper.Map(model, entity);
                return await _memberRepository.UpdateAsync(entity, userId);
            }

            return EntityStateResult.Error;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await _memberRepository.FindAsync(id);
            if (entity != null)
            {
                return await _memberRepository.RemoveAsync(entity);
            }

            return EntityStateResult.Error;
        }
    }
}
