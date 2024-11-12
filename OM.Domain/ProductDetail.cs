using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Domain
{
    public class ProductDetail:BaseEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }   
        public string Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null;
    }
}
