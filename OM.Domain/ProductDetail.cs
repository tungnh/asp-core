using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Domain
{
    public class ProductDetail : BaseEntity<int>
    {
        public string ProductType { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null;
    }
}
