using OM.Application.Data.Repositories;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services
{
    public interface IProductDetailService
    {
        /// <summary>
        /// Get all   <see cref="List{ProductDetail}"/> detail
        /// </summary>
        /// <returns></returns>
        Task<List<ProductDetail>> GetAllProductDetailAsync();

        /// <summary>
        /// Add or update product detail 
        /// </summary>
        /// <param name="EntityProduct">Entity Product Detail</param>
        /// <returns></returns>
        Task<List<ProductDetail>> AddOrUpdateProductDetailAsync(ProductDetail EntityProductDetail);

        /// <summary>
        /// Delete product <see cref="int"/> Id, <see cref="Product"/> EntityProductDetail
        /// </summary>
        /// <param name="id">Id product detail</param>
        /// <param name="EntityProduct">Product Entity delete </param>
        /// <returns></returns>
        Task<List<ProductDetail>> DeleteProductDetailAsync(int id, ProductDetail EntityProductDetail);

        /// <summary>
        /// Get product detail by id <see cref="int"/> id 
        /// </summary>
        /// <param name="id">Id product detail</param>
        /// <returns></returns>
        Task<Product> GetProductDetailByIdAsync(int id);
    }
}
