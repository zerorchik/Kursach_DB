using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Letter
    {
        public int Lid { get; set; }
        public DateTime Date { get; set; }
        public bool IsAns { get; set; }
        public DateTime? DateAns { get; set; }
        public long ThemaId { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public long HelperId { get; set; }
    }
}
