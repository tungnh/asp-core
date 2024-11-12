using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Domain
{
    public class Product :BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public ProductDetail? ProductDetail { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
