using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductOccasions = new HashSet<ProductOccasion>();
        }

        public int Id { get; set; }
        public int IdProvider { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; } = null!;
        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual ICollection<ProductOccasion> ProductOccasions { get; set; }
    }
}
