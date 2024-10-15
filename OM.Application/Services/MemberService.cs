using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OM.Application.Data.Repositories;

namespace OM.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this._memberRepository = memberRepository;
        }

        List<Domain.Member> IMemberService.GetAllMembers()
        {
            return this._memberRepository.FindAll().ToList();
        }
    }
}
