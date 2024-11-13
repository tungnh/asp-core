using OM.Application.Models;

namespace OM.Application.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<int> AddAsync(ProductDetailInputModel model, string productId);

        Task<int> UpdateAsync(ProductDetailInputModel model, string productId);

        Task<int> RemoveAsync(int id);
    }
}
