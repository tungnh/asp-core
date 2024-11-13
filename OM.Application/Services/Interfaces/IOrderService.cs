using OM.Application.Models.Member;
using OM.Application.Models;
using OM.Application.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderInputModel> FindAsync(int? id);

        Task<PaginatedList<OrderInputModel>> FindAllAsync(OrderRequestModel requestModel, Pageable pageable);

        Task<int> AddAsync(OrderInputModel model, string userId);

        Task<int> UpdateAsync(OrderInputModel model, string userId);

        Task<int> RemoveAsync(int id);
    }
}
