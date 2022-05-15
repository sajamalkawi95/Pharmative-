using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteProductCart
    {
        public decimal ProductCartId { get; set; }
        public decimal? ProductIdfk { get; set; }
        public decimal? OrderIdfk { get; set; }

        public virtual PharmaviteOrder OrderIdfkNavigation { get; set; }
        public virtual PharmaviteProduct ProductIdfkNavigation { get; set; }
    }
}
