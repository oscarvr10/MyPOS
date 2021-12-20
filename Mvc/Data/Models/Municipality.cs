using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class Municipality
    {
        public Municipality()
        {
            ZipCodes = new HashSet<ZipCode>();
        }

        public int Id { get; set; }
        public int IdState { get; set; }
        public int Cve { get; set; }
        public string Name { get; set; } = null!;

        public virtual State IdStateNavigation { get; set; } = null!;
        public virtual ICollection<ZipCode> ZipCodes { get; set; }
    }
}
