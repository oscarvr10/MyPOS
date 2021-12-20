using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class ProductOccasion
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdOccasion { get; set; }

        public virtual Occasion IdOccasionNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
