using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Domain
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public ProductDetail? Detail { get; set; }
    }
}
