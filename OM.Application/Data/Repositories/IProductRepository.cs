using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Application.Data.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        public  Task<Product?> GetProductByIdAsync(int id);
    }
}
