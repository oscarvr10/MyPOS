using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseIdParentNavigation = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IdParent { get; set; }

        public virtual Category? IdParentNavigation { get; set; }
        public virtual ICollection<Category> InverseIdParentNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
