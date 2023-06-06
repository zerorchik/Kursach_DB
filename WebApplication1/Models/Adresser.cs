using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Adresser
    {
        public Adresser()
        {
            Helpers = new HashSet<Helper>();
        }

        public long Adid { get; set; }
        public string Name { get; set; }
        public string Sign { get; set; }

        public virtual ICollection<Helper> Helpers { get; set; }
    }
}
