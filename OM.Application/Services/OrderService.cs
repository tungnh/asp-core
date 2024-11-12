using AutoMapper;
using OM.Application.Data.Queries;
using OM.Application.Data.Repositories;
using OM.Application.Models;
using OM.Application.Models.Order;
using OM.Application.Models.Paging;
using OM.Application.Utils;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _memberRepository;
        private readonly IOrderQuery _memberQuery;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository memberRepository, IOrderQuery memberQuery, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _memberQuery = memberQuery;
            _mapper = mapper;
        }

        public async Task<OrderInputModel> FindAsync(int? id)
        {
            var entity = await _memberRepository.FindAsync(id);
            return _mapper.Map<OrderInputModel>(entity);
        }

        public async Task<PaginatedList<OrderInputModel>> FindAllAsync(OrderRequestModel requestModel, Pageable pageable)
        {
            var predicate = PredicateBuilder.True<Order>();
            //if (!string.IsNullOrEmpty(requestModel.ProductName))
            //{
            //    predicate = predicate.And(x => x.Name.Contains(requestModel.ProductName));
            //}
            //if (!string.IsNullOrEmpty(requestModel.Type))
            //{
            //    predicate = predicate.And(x => x.Type.Contains(requestModel.Type));
            //}
            var page = await _memberRepository.FindAllAsync(predicate, pageable);
            return _mapper.Map<PaginatedList<Order>, PaginatedList<OrderInputModel>>(page);
        }

        public async Task<int> AddAsync(OrderInputModel model, string userId)
        {
            var entity = _mapper.Map<Order>(model);
            return await _memberRepository.AddAsync(entity, userId);
        }

        public async Task<int> UpdateAsync(OrderInputModel model, string userId)
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
