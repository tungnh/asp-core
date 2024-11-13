using OM.Application.Models.Paging;
using OM.Application.Models;

namespace OM.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductInputModel> FindAsync(int? id);
        Task<PaginatedList<ProductInputModel>> FindAllAsync(ProductRequestModel requestModel, Pageable pageable);
    }
}
