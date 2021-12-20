using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class ZipCode
    {
        public ZipCode()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public int IdMunicipality { get; set; }
        public int ZipCodeNumber { get; set; }
        public string Settlement { get; set; } = null!;

        public virtual Municipality IdMunicipalityNavigation { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
