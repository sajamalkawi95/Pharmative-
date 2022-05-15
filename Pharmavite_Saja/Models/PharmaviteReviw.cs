using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteReviw
    {
        public decimal ReviwId { get; set; }
        public decimal? Reviw { get; set; }
        public decimal? WebsiteIdfk { get; set; }

        public virtual PharmaviteWebsite WebsiteIdfkNavigation { get; set; }
    }
}
