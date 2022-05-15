using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteAbouteU
    {
        public decimal AbouteId { get; set; }
        public string Aboute1 { get; set; }
        public string Aboute2 { get; set; }
        public decimal? WebsiteIdfk { get; set; }

        public virtual PharmaviteWebsite WebsiteIdfkNavigation { get; set; }
    }
}
