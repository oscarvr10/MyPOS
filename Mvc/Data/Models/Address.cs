﻿using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class Address
    {
        public Address()
        {
            Offices = new HashSet<Office>();
            Providers = new HashSet<Provider>();
        }

        public int Id { get; set; }
        public int IdSettlement { get; set; }
        public string Street { get; set; } = null!;
        public string IntNumber { get; set; } = null!;

        public virtual ZipCode IdSettlementNavigation { get; set; } = null!;
        public virtual ICollection<Office> Offices { get; set; }
        public virtual ICollection<Provider> Providers { get; set; }
    }
}
