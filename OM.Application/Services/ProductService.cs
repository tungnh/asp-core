using AutoMapper;
using OM.Application.Data.Queries;
using OM.Application.Data.Repositories;
using OM.Application.Models;
using OM.Application.Models.Product;
using OM.Application.Models.Paging;
using OM.Application.Models.Product;
using OM.Application.Services.Interfaces;
using OM.Application.Utils;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductQuery _productQuery;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IProductQuery productQuery, IMapper mapper)
        {
            _productRepository = productRepository;
            _productQuery = productQuery;
            _mapper = mapper;
        }

        public async Task<ProductInputModel> FindAsync(int? id)
        {
            var entity = await _productRepository.FindAsync(id);
            return _mapper.Map<ProductInputModel>(entity);
        }

        public async Task<PaginatedList<ProductInputModel>> FindAllAsync(ProductRequestModel requestModel, Pageable pageable)
        {
            var predicate = PredicateBuilder.True<Product>();
            if (!string.IsNullOrEmpty(requestModel.Name))
            {
                predicate = predicate.And(x => x.Name.Contains(requestModel.Name));
            }
          
            var page = await _productRepository.FindAllAsync(predicate, pageable);
            return _mapper.Map<PaginatedList<Product>, PaginatedList<ProductInputModel>>(page);
        }

        public async Task<int> AddAsync(ProductInputModel model, string userId)
        {
            var entity = _mapper.Map<Product>(model);
            return await _productRepository.AddAsync(entity, userId);
        }

        public async Task<int> UpdateAsync(ProductInputModel model, string userId)
        {
            var entity = await _productRepository.FindAsync(model.Id);
            if (entity != null)
            {
                _mapper.Map(model, entity);
                return await _productRepository.UpdateAsync(entity, userId);
            }

            return EntityStateResult.Error;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await _productRepository.FindAsync(id);
            if (entity != null)
            {
                return await _productRepository.RemoveAsync(entity);
            }

            return EntityStateResult.Error;
        }
    }
}
