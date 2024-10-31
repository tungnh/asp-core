using OM.Application.Data.Repositories;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services
{
    public class ProductDetailServices: IProductDetailServices
    {
        private readonly IProductDetailRepository _productDetailRepository;

        private readonly IProductDetailRepository _productDetailQuery;

        public ProductDetailServices(IProductDetailRepository productDetailRepository, 
            IProductDetailRepository productDetailQuery)
        {
            _productDetailRepository = productDetailRepository;
            _productDetailQuery = productDetailQuery;
        }

        public async Task<List<ProductDetail>> AddOrUpdateProductDetailAsync(ProductDetail productDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDetail>> DeleteProductDetailAsync(int idProductDetail, ProductDetail productDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDetail>> GetAllProductDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductDetailByIdAsync(int idProductDetail)
        {
            throw new NotImplementedException();
        }
      
    }
}
