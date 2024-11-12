using AutoMapper;
using OM.Application.Data.Queries;
using OM.Application.Data.Repositories;
using OM.Application.Models;
using OM.Application.Models.ProductDetail;
using OM.Application.Models.Paging;
using OM.Application.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OM.Domain;

namespace OM.Application.Services
{
    public class ProductDetailService
    {
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IProductDetailQuery _productDetailQuery;
        private readonly IMapper _mapper;

        public ProductDetailService(IProductDetailRepository productDetailRepository, IProductDetailQuery productDetailQuery, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _productDetailQuery = productDetailQuery;
            _mapper = mapper;
        }

        public async Task<ProductDetailInputModel> FindAsync(int? id)
        {
            var entity = await _productDetailRepository.FindAsync(id);
            return _mapper.Map<ProductDetailInputModel>(entity);
        }

        public async Task<PaginatedList<ProductDetailInputModel>> FindAllAsync(ProductDetailRequestModel requestModel, Pageable pageable)
        {
            var predicate = PredicateBuilder.True<ProductDetail>();
            
            var page = await _productDetailRepository.FindAllAsync(predicate, pageable);
            return _mapper.Map<PaginatedList<ProductDetail>, PaginatedList<ProductDetailInputModel>>(page);
        }

        public async Task<int> AddAsync(ProductDetailInputModel model, string userId)
        {
            var entity = _mapper.Map<ProductDetail>(model);
            return await _productDetailRepository.AddAsync(entity, userId);
        }

        public async Task<int> UpdateAsync(ProductDetailInputModel model, string userId)
        {
            var entity = await _productDetailRepository.FindAsync(model.Id);
            if (entity != null)
            {
                _mapper.Map(model, entity);
                return await _productDetailRepository.UpdateAsync(entity, userId);
            }

            return EntityStateResult.Error;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await _productDetailRepository.FindAsync(id);
            if (entity != null)
            {
                return await _productDetailRepository.RemoveAsync(entity);
            }

            return EntityStateResult.Error;
        }
    }
}
