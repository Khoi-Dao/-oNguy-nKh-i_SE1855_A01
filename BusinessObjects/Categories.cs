using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        // Navigation property for related products
        public virtual ICollection<Products> Product { get; set; }
    }
}
