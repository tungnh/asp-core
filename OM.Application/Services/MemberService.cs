using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OM.Application.Data.Queries;
using OM.Application.Data.Repositories;
using OM.Domain;

namespace OM.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        private readonly IMemberQuery _memberQuery;

        public MemberService(IMemberRepository memberRepository, IMemberQuery memberQuery)
        {
            this._memberRepository = memberRepository;
            this._memberQuery = memberQuery;
        }

        public List<Member> GetAllMembers()
        {
            return this._memberQuery.GetAllMembers();
        }
    }
}
