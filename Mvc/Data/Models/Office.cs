using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class Office
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int IdAddress { get; set; }

        public virtual Address IdAddressNavigation { get; set; } = null!;
    }
}
