using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IdAddress { get; set; }

        public virtual Address? IdAddressNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
