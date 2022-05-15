using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmativeUserContact
    {
        public decimal UserContactId { get; set; }
        public decimal? UserIdfk { get; set; }
        public string ContactMsg { get; set; }

        public virtual PharmaviteUser UserIdfkNavigation { get; set; }
    }
}
