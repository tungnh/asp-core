using OM.Application.Data.Repositories;
using OM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Infrastructure.Data.Repositories
{
    public class OrderRepository: Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context):base(context) 
        { 
        
        }
    }
}
