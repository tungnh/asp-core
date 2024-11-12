using OM.Application.Models.Paging;
using OM.Application.Models.Product;
using OM.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductInputModel> FindAsync(int? id);
        Task<PaginatedList<ProductInputModel>> FindAllAsync(ProductRequestModel requestModel, Pageable pageable);
    }
}
