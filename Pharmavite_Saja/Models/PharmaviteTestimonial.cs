using System;
using System.Collections.Generic;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class PharmaviteTestimonial
    {
        public decimal TestimonialId { get; set; }
        public string Img { get; set; }
        public string ReviwMsg { get; set; }
        public decimal? WebsiteIdfk { get; set; }

        public virtual PharmaviteWebsite WebsiteIdfkNavigation { get; set; }
    }
}
