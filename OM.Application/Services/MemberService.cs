using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OM.Application.Data.Queries;
using OM.Application.Data.Repositories;
using OM.Application.Models.Member;
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

        public async Task<List<MemberInputModel>> FindAllAsync()
        {
            var entities = await _memberRepository.FindAllAsync();
            return _mapper.Map<List<MemberInputModel>>(entities);
        }

        public async Task<int> AddAsync(MemberInputModel model)
        {
            var entity = _mapper.Map<Member>(model);
            return await _memberRepository.AddAsync(entity);
        }

        public async Task<int> UpdateAsync(MemberInputModel model)
        {
            var entity = await _memberRepository.FindAsync(model.Id);
            if (entity != null)
            {
                _mapper.Map(model, entity);
                return await _memberRepository.UpdateAsync(entity);
            }

            return StatusCode.Error;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await _memberRepository.FindAsync(id);
            if (entity != null)
            {
                return await _memberRepository.RemoveAsync(entity);
            }

            return StatusCode.Error;
        }
    }
}
