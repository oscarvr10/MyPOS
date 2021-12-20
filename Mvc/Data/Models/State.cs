using System;
using System.Collections.Generic;

namespace Mvc.Data.Models
{
    public partial class State
    {
        public State()
        {
            Municipalities = new HashSet<Municipality>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Municipality> Municipalities { get; set; }
    }
}
