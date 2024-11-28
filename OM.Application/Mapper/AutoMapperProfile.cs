using AutoMapper;
using OM.Application.Models;
using OM.Application.Models.Member;
using OM.Application.Models.Paging;
using OM.Domain;

namespace OM.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // PaginatedList
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListConverter<,>));
            // Members
            CreateMap<Member, MemberInputModel>();
            CreateMap<MemberInputModel, Member>();
            // Orders
            CreateMap<Order, OrderInputModel>();
            CreateMap<OrderInputModel, Order>();
        }

        private class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDestination>>
        {
            public PaginatedList<TDestination> Convert(
                PaginatedList<TSource> source,
                PaginatedList<TDestination> destination,
                ResolutionContext context)
            {
                return new PaginatedList<TDestination>(context.Mapper.Map<List<TSource>, List<TDestination>>(source))
                {
                    PageIndex = source.PageIndex,
                    TotalElements = source.TotalElements,
                    TotalPages = source.TotalPages
                };
            }
        }
    }
}
