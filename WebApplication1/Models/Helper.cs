using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Helper
    {
        public int Hid { get; set; }
        public string Name { get; set; }
        public string Sign { get; set; }
        public long? BossId { get; set; }

        public virtual Adresser Boss { get; set; }
    }
}
