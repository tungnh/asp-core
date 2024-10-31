using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services
{
    public interface IProductService
    {
        Task<List<Product>?> GetAllProductAsync();
        Task<List<Product>?> AddProductAsync(Product? product);
        Task<List<Product>> DeleteProductAsync(int? id);
        Task<Product?> GetProductByIdAsync(int? id);
        Task<List<Product>?> UpdateProductAsync(Product? Product);

    }
}
