using AutoMapper;
using OM.Application.Models.Member;
using OM.Domain;

namespace OM.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            // Members
            CreateMap<Member, MemberInputModel>();
            CreateMap<MemberInputModel, Member>();
        }
    }
}
