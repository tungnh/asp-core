using OM.Application.Models;
using OM.Application.Models.Member;
using OM.Application.Models.Paging;
using OM.Application.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<int> AddAsync(ProductDetailInputModel model, string productId);

        Task<int> UpdateAsync(ProductDetailInputModel model, string productId);

        Task<int> RemoveAsync(int id);
    }
}
