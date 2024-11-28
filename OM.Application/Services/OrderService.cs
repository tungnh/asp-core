using AutoMapper;
using OM.Application.Data.Queries;
using OM.Application.Data.Repositories;
using OM.Application.Models;
using OM.Application.Models.Paging;
using OM.Application.Services.Interfaces;
using OM.Application.Utils;
using OM.Domain;

namespace OM.Application.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderInputModel> FindAsync(int? id)
        {
            var entity = await _orderRepository.FindAsync(id);
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
            var page = await _orderRepository.FindAllAsync(predicate, pageable);
            return _mapper.Map<PaginatedList<Order>, PaginatedList<OrderInputModel>>(page);
        }

        public async Task<int> AddAsync(OrderInputModel model, string userId)
        {
            try
            {
                var entity = _mapper.Map<Order>(model);
                return await _orderRepository.AddAsync(entity, userId);
            }
            catch
            {

                throw new Exception();
            }
           
        }

        public async Task<int> UpdateAsync(OrderInputModel model, string userId)
        {
            var entity = await _orderRepository.FindAsync(model.Id);
            if (entity != null)
            {
                _mapper.Map(model, entity);
                return await _orderRepository.UpdateAsync(entity, userId);
            }

            return EntityStateResult.Error;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await _orderRepository.FindAsync(id);
            if (entity != null)
            {
                return await _orderRepository.RemoveAsync(entity);
            }

            return EntityStateResult.Error;
        }

        public async Task<List<Order>> GetAllAsync()  
        {
            try
            {
                return await _orderRepository.FindAllAsync();
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
