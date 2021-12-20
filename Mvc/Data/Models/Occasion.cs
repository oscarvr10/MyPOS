using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class Occasion
    {
        public Occasion()
        {
            ProductOccasions = new HashSet<ProductOccasion>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductOccasion> ProductOccasions { get; set; }
    }
}
