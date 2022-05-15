using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteCard
    {
        public decimal CreditCardid { get; set; }
        public decimal? UserIdfk { get; set; }
        public decimal? Cardnumber { get; set; }
        public DateTime? ExpDate { get; set; }
        public decimal? Ccb { get; set; }
        public decimal? Balanc { get; set; }

        public virtual PharmaviteUser UserIdfkNavigation { get; set; }
    }
}
