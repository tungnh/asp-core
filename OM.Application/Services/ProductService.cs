using OM.Application.Data;
using OM.Application.Data.Repositories;
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

        public ProductService(IProductRepository productRepository, IProductQuery productQuery)
        {
            _productRepository = productRepository;
            _productQuery = productQuery;
        }

        public Task<List<Product>?> AddProductAsync(Product? product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> DeleteProductAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>?> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>?> UpdateProductAsync(Product? Product)
        {
            throw new NotImplementedException();
        }
    }
}
