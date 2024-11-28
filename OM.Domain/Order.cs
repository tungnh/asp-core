using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Domain
{
    public class Order:BaseEntity
    {
        public int Id { get; set; } 
        public string Amount {  get; set; }
        public string UnitPrice {  get; set; }
        public string Total { get; set; }
        public int ProductId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
