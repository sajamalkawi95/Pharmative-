using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class FinReport
    {
        public decimal RId { get; set; }
        public decimal? OrderIdfk { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductOrderQty { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Deleverddate { get; set; }
        public decimal? ProductIdfk { get; set; }

        public virtual PharmaviteOrder OrderIdfkNavigation { get; set; }
        public virtual PharmaviteProduct ProductIdfkNavigation { get; set; }
    }
}
